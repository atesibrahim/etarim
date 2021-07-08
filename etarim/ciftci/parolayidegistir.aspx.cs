using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ciftci_parolayidegistir : System.Web.UI.Page
{
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci2 = veritabani.GetDataRow("select * from ciftci where kod=" + adminid);

        if (adminid == 0 || drciftci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drciftci = veritabani.GetDataRow("select * from ciftci where kod=" + adminid);
            String kod = (String)Session["kod"];
            DataRow yoneticiDB = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod + "'");
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
        String kod = (String)Session["kod"];
        String eskiSifre1 = oldPassword.Text.ToString();
        String yeniSifre1 = newPassword.Text.ToString();
        int sifreUzunlugu = yeniSifre1.Length;
        String yeniSifreOnay1 = confPassword.Text.ToString();
        DataRow yoneticiDB = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod + "'");
        String vEskiSifre = yoneticiDB["sifre"].ToString();
      
        String eskiSifre = Sifrele(eskiSifre1);
        String yeniSifre = Sifrele(yeniSifre1);
        String yeniSifreOnay = Sifrele(yeniSifreOnay1);
       

        if (eskiSifre != vEskiSifre)
        {
            Response.Write("<script>alert('Eski Parolanızı yanlış girdiniz. Lütfen tekrar deneyiniz !');</script>");
        }
        else
        {
            if (sifreUzunlugu > 5)
            {

                if (yeniSifre == yeniSifreOnay)
                {
                    DataRow yoneticiUPD = veritabani.GetDataRow("UPDATE  giris_bilgileri SET sifre='" + yeniSifre + "' where kod = '" + kod + "'");
                    Response.Write("<script>alert('Parolanız başarıyla değiştirildi !');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Girdiğiniz yeni parolalar uyuşmuyor. Lütfen tekrar deneyiniz !');</script>");
                }
            }
            else {
                Response.Write("<script>alert('Şifre Uzunluğu 6 karakterden küçük olmamalı!'); </script>");
            
            }
        }


    }
}