using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

public partial class yonetici_bilgprofekleme : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ConnectionString");
    DataSet DS = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drYonetici = veritabani.GetDataRow("select * from yonetici where kod=" + adminid);

        if (adminid == 0 || drYonetici == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
//            DataRow drAdmin = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
//            DataRow drYonetici = ver.GetDataRow("select * from yonetici where kod=" + adminid);

            if (!IsPostBack)
            {
                SqlConnection Conn = new SqlConnection(s);
                SqlCommand Cmd = new SqlCommand("Select * From adres_il", Conn);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "ad");
                DropDownList1.DataSource = DS.Tables["ad"];
                DropDownList1.DataTextField = "ad";
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
            String ilid = DropDownList1.SelectedValue;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select ad,kod from adres_ilce where il_kod =" + ilid, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "ad";
            DropDownList2.DataValueField = "kod";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Seçiniz");
        }

    }
    static public string Sifrele(string veri)
    {
        // gelen veri byte dizisine aktarılıyor 
        byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
        // base64 şifreleme algoritmasına göre şifreleniyor.
        string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
        return sifrelenmisVeri;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kod = TextBox1.Text.Trim();
        string adi = TextBox2.Text.Trim();
        string soyadi = TextBox3.Text.Trim();
        string email = TextBox4.Text.Trim();
        string ceptel = TextBox8.Text.Trim();
        string adres = TextBox5.Text.Trim();
        string adresil = DropDownList1.SelectedValue;
        string adresilce = DropDownList2.SelectedValue;
        string sifre = TextBox6.Text.Trim();
        int sifreUzunlugu = sifre.Length;
        string sifretekrar = TextBox7.Text.Trim();
        int kim = 3,aktifpasif=1;
        DataRow bilgprof = veritabani.GetDataRow("select * from bilgisayar_prof where kod = '" + kod + "'");
        DataRow girisBilgileri = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + email + "'");
        DataRow girisBilgileri2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod + "'");
        if (bilgprof == null)
        {
            if(girisBilgileri2 == null)
            {
            if (girisBilgileri == null)
            {

                if (kod != "" && adi != "" && soyadi != "" && email != "" && ceptel != "" && adres != "" && adresil != "Seçiniz" && adresilce != "Seçiniz" && sifre != "" && sifretekrar != "")
                {
                    if (sifreUzunlugu > 5)
                    {
                        if (sifre == sifretekrar)
                        {
                            sifre = Sifrele(sifre);
                            ver.CmdText = "Insert Into [bilgisayar_prof] (kod,ad,soyad,cep_tel,adres,adres_il,adres_ilce) values ('" + kod + "','" + adi + "','" + soyadi + "','" + ceptel + "','" + adres + "','" + adresil + "','" + adresilce + "')";
                            ver2.CmdText = "Insert Into [giris_bilgileri] (kod,email,sifre,kim,aktifpasif) values ('" + kod + "','" + email + "','" + sifre + "','" + kim + "','" + aktifpasif + "')";
                            if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                            {
                                Response.Write("<script>alert('Kullanıcı başarılı bir şekilde eklendi!'); </script>");
                                TextBox1.Text = String.Empty;
                                TextBox2.Text = String.Empty;
                                TextBox3.Text = String.Empty;
                                TextBox4.Text = String.Empty;
                                TextBox5.Text = String.Empty;
                                TextBox6.Text = String.Empty;
                                TextBox8.Text = String.Empty;
                                DropDownList1.Items.Insert(0, "Seçiniz");
                                DropDownList2.Items.Insert(0, "Seçiniz");

                            }
                            else
                                Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Şifreler Uyuşmuyor!'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Şifre Uzunluğu 5 karakterden küçük olmamalı!'); </script>");
                    
                    }
                }
                else
                {
                    Response.Write("<script>alert('Boş alan bırakmayınız!'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Lütfen farklı bir e-amil adresi giriniz. !'); </script>");
            }
            }
            else
            {
                Response.Write("<script>alert('Lütfen farklı bir kod giriniz. !'); </script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Aynı Sicil numarasıyla farklı kayıt yapamazsınız. !'); </script>");
        }
        
    }
}