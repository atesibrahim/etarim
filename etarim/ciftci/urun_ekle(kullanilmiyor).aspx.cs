using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ciftci_urun_ekle : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("etarim");

    DataSet DS = new DataSet();
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {

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

        int ciftcikod = Convert.ToInt32(Session["kod"]);
        string miktar = TextBox3.Text.Trim();
        string fiyat = TextBox2.Text.Trim();
        string tur = DropDownList1.Text.Trim();
        string isim = DropDownList2.Text.Trim();





        if (miktar == "" || fiyat == "" || DropDownList1.SelectedValue == "Seçiniz" || DropDownList2.SelectedValue == "Seçiniz")
        {
            Response.Write("<script>alert('Boş alan bırakmayınız !');</script>");
        }
        else
        {

            String kod2 = (String)Session["kod"];
            DataRow kont = veritabani.GetDataRow("select * from ciftci_urun where ciftci_kod = '" + kod2 + "' and tur_kod='" + tur + "' and urun_kod='" + isim + "'");



            if (kont != null)
            {
                Response.Write("<script>alert('Bu ürün zaten ekli!'); </script>");
            }


            else
            {

                ver.CmdText = "Insert Into [ciftci_urun] (ciftci_kod,tur_kod,urun_kod,miktar) values ('" + ciftcikod + "','" + tur + "','" + isim + "','" + miktar + "')";
                ver2.CmdText = "Insert Into [ciftci_urun_fiyat] (ciftci_kod,urun_kod,fiyat,tur_kod) values ('" + ciftcikod + "','" + isim + "','" + fiyat + "','" + tur + "')";
                if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                {
                    Response.Write("<script>alert('Urun eklendi!'); </script>");
                }
                else
                    Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            }
        }
    }
}