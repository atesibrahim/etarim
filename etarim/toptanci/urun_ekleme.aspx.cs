using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class toptanci_urun_ekleme : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("etarim");

    DataSet DS = new DataSet();
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drtoptanci2 = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);

        if (adminid == 0 || drtoptanci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drtoptanci = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);
            Label2.Visible = false;
            Label3.Visible = false;
            if (!IsPostBack)
            {
                SqlConnection Conn = new SqlConnection(s);
                SqlCommand Cmd = new SqlCommand("Select * From urun_turleri", Conn);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "urun_turleri");
                DropDownList1.DataSource = DS.Tables["urun_turleri"];
                DropDownList1.DataTextField = "tur_ad";
                DropDownList1.DataValueField = "kod";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Seçiniz");
                DropDownList2.Items.Insert(0, "Seçiniz");
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "Seçiniz")
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd1 = new SqlCommand("Select * From urun_isimleri Where tur_kod=" + DropDownList1.SelectedValue + "", Conn);
            SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
            DA1.Fill(DS, "urun_isimleri");
            DropDownList2.DataSource = DS.Tables["urun_isimleri"];
            DropDownList2.DataTextField = "ad";
            DropDownList2.DataValueField = "kod";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Seçiniz");
        }

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {

        int top_kod = Convert.ToInt32(Session["kod"]);
        string miktar = TextBox3.Text.Trim();
        string tur = DropDownList1.Text.Trim();
        string isim = DropDownList2.Text.Trim();





        if (miktar == "" || DropDownList1.SelectedValue == "Seçiniz" || DropDownList2.SelectedValue == "Seçiniz")
        {
            Label3.ForeColor = Color.Red;
            Label3.Visible = true;
        }
        else
        {


            DataRow kont = veritabani.GetDataRow("select * from toptanci_urun where toptanci_kod = '" + top_kod + "' and tur_kod='" + tur + "' and urun_kod='" + isim + "'");



            if (kont != null)
            {
                Label2.Visible = true;
                Label2.ForeColor = Color.Red;
                Label2.Text = "Bu Ürün Zaten Ekli!";
            }


            else
            {

                ver.CmdText = "Insert Into [toptanci_urun] (toptanci_kod,tur_kod,urun_kod,miktar) values ('" + top_kod + "','" + tur + "','" + isim + "','" + miktar + "')";

                if (ver.NonQuery > 0)
                {
                    Label2.Text = "Ürün Başarıyla Eklendi, Yeni Ürün Girişi Yapabilirsiniz.";
                    Label2.ForeColor = Color.Green;
                    Label2.Visible = true;
                    DropDownList1.SelectedValue = "Seçiniz";
                    DropDownList2.SelectedValue = "Seçiniz";
                    TextBox3.Text = "";
                }
                else
                    Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}