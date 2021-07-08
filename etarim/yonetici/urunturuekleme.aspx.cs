using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

public partial class yonetici_urunturuekleme : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veribase = new dbConnection("BAKANLIKDEMO");
    dbConnection veritabani = new dbConnection("ConnectionString");

    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drYonetici2 = veritabani.GetDataRow("select * from yonetici where kod=" + adminid);

        if (adminid == 0 || drYonetici2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drYonetici = veritabani.GetDataRow("select * from yonetici where kod=" + adminid);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "Ürün Ailesi Ekleme")
        {
            Label1.Visible = true;
            Button1.Visible = true;
            TextBox1.Visible = true;
            Label4.Visible = false;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            Button1.Visible = true;
            TextBox2.Visible = false;
        }
        else if (DropDownList1.SelectedValue == "Ürün İsmi Ekleme")
        {
            //String urunturleri = DropDownList1.SelectedValue;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select tur_ad,kod from urun_turleri ", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "tur_ad";
            DropDownList2.DataValueField = "kod";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Seçiniz");
            Label1.Visible = false;
            Label4.Visible = true;
            Button1.Visible = false;
            TextBox1.Visible = false;
            Label2.Visible = true;
            DropDownList2.Visible = true;
            Button1.Visible = true;
            TextBox2.Visible = true;
        }
        else
        {
            Label1.Visible = false;
            Button1.Visible = false;
            TextBox1.Visible = false;
            Label2.Visible = false;
            DropDownList2.Visible = false;
            Button1.Visible = false;
            TextBox2.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string turIsim = TextBox1.Text.Trim();
        string urunIsim = TextBox2.Text.Trim();
        string turIsmi = turIsim.ToUpper();
        string urunIsmi = urunIsim.ToUpper();






        /*        DataRow urunKodKontrol = veritabani.GetDataRow("select MAX(kod) from urun_turleri");

                urunKodu = urunKodKontrol["kod"].ToString();
                int urunkod = Convert.ToInt32(urunKodu) + 1;

                DataRow urunIsimKodKontrol = veritabani.GetDataRow("select MAX(kod) from urun_isimleri");
                urunIsimKodu = urunIsimKodKontrol.ToString();
                int urunisimkod = Convert.ToInt32(urunIsimKodu) + 1;*/

        if (DropDownList1.SelectedValue == "Ürün Ailesi Ekleme")
        {

            DataRow urunTurKontrol = veritabani.GetDataRow("select * from urun_turleri where tur_ad = '" + turIsmi + "'");
            DataRow urunIsimKontrol = veritabani.GetDataRow("select * from urun_isimleri where ad = '" + urunIsmi + "'");
            if (urunTurKontrol == null)
            {
                int urunTurKod = 0, urunIsimKod = 0;
                String sql = "select MAX(kod) from urun_turleri";
                SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                connect.Open();
                SqlCommand command = new SqlCommand(sql, connect);

                if (command.ExecuteScalar() != null && urunTurKontrol == null)
                {
                    urunTurKod = (Int32)command.ExecuteScalar() + 1;
                }
                else
                {
                    urunTurKod = 1;
                }
                DataRow urunTurEkleme = veritabani.GetDataRow("Insert Into [urun_turleri] (kod,tur_ad) values ('" + urunTurKod + "','" + turIsmi + "')");
                //DataRow urunIsimEkleme = veritabani.GetDataRow("Insert Into [urun_isimleri] (tur_kod, kod, ad) values ('" + urunTurKod + "','" + urunIsimKod + "','" + urunIsmi + "')");
                Response.Write("<script>alert('Ürün başarıyla eklendi.');</script>");
                TextBox1.Text = "";
                //TextBox2.Text = "";


            }
            else
            {
                Response.Write("<script>alert('Ürün türü daha önce eklenmiştir.');</script>");
            }

        }
        else if (DropDownList1.SelectedValue == "Ürün İsmi Ekleme")
        {
            int urunTurKod, urunIsimKod;
            DataRow urunIsimKontrol = veritabani.GetDataRow("select * from urun_isimleri where ad = '" + urunIsmi + "'");
            String urunTuru = DropDownList2.SelectedValue;
            System.Diagnostics.Debug.WriteLine(urunTuru);
            String sql = "select ut.kod from urun_turleri ut where ut.kod ='" + DropDownList2.SelectedValue + "'";
            SqlConnection connect = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            connect.Open();
            SqlCommand command = new SqlCommand(sql, connect);

            urunTurKod = (Int32)command.ExecuteScalar();

            String sql2 = "select MAX(kod) from urun_isimleri where tur_kod =" + urunTurKod + "";
            SqlConnection connect2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            connect2.Open();

            SqlCommand command2 = new SqlCommand(sql2, connect2);
            if (urunIsimKontrol == null)
            {
                if (command2.ExecuteScalar() == null)
                {
                    urunIsimKod = (Int32)command2.ExecuteScalar() + 1;
                }
                else
                {
                    urunIsimKod = 1;
                }

                //            DataRow urunTurEkleme = veritabani.GetDataRow("Insert Into [urun_turleri] (kod,tur_ad) values ('" + urunTurKod + "','" + turIsmi + "')");
                DataRow urunIsimEkleme = veritabani.GetDataRow("Insert Into [urun_isimleri] (tur_kod, kod, ad) values ('" + urunTurKod + "','" + urunIsimKod + "','" + urunIsmi + "')");
                Response.Write("<script>alert('Ürün ismi başarıyla eklendi.');</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Ürün ismi daha önce eklenmiştir.');</script>");
            }

        }
    }
}