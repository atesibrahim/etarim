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



public partial class yonetici_yoneticiekleme : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ConnectionString");
    DataSet DS = new DataSet();
    dbConnection veri = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veri.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drYonetici2 = veri.GetDataRow("select * from yonetici where kod=" + adminid);
        if (adminid == 0 || drYonetici2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {

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
        string sifre = TextBox6.Text.Trim();
        int sifreUzunlugu = sifre.Length;
        string sifretekrar = TextBox7.Text.Trim();
        int kim = 2, aktifpasif = 1;
        DataRow yonetici = veritabani.GetDataRow("select * from yonetici where kod = '" + kod + "'");
        DataRow girisBilgileri = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + email + "'");
        DataRow girisBilgileri2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod + "'");
        if (yonetici == null)
        {
            if (girisBilgileri2 == null)
            {
                if (girisBilgileri == null)
                {

                    if (kod != "" && adi != "" && soyadi != "" && email != "" && sifre != "" && sifretekrar != "")
                    {
                        if (sifreUzunlugu > 5)
                        {
                            if (sifre == sifretekrar)
                            {
                                sifre = Sifrele(sifre);
                                ver.CmdText = "Insert Into [yonetici] (kod,ad,soyad) values ('" + kod + "','" + adi + "','" + soyadi + "')";
                                ver2.CmdText = "Insert Into [giris_bilgileri] (kod,email,sifre,kim,aktifpasif) values ('" + kod + "','" + email + "','" + sifre + "','" + kim + "','" + aktifpasif + "')";
                                if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                                {
                                    Response.Write("<script>alert('Kullanıcı başarılı bir şekilde eklendi!'); </script>");
                                    TextBox1.Text = String.Empty;
                                    TextBox2.Text = String.Empty;
                                    TextBox3.Text = String.Empty;
                                    TextBox4.Text = String.Empty;

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
                    Response.Write("<script>alert('Lütfen farklı bir e-mail adresi giriniz. !'); </script>");
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