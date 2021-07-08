using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class yonetici_profilim : System.Web.UI.Page
{
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
            Response.Write("<script>alert('Sisteme önce giriş yapmanız gerekir. Giriş sayfasına yönlendiriliyorsunuz. ');</script>");
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drYonetici = veritabani.GetDataRow("select * from yonetici where kod=" + adminid);

            String kod2 = (String)Session["kod"];
            DataRow yoneticiDB = veritabani.GetDataRow("select * from yonetici where kod = '" + kod2 + "'");

            LabelAd.Text = yoneticiDB["ad"].ToString();
            LabelSoyad.Text = yoneticiDB["soyad"].ToString();
            DataRow loginDB = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod2 + "'");
            LabelMail.Text = loginDB["email"].ToString();
            //        LabelSifre.Text = loginDB["sifre"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBoxAd.Enabled = true;
        TextBoxEmail.Enabled = true;
//        TextBoxSifre.Enabled = true;
        TextBoxSoyad.Enabled = true;
        Button2.Visible = true;
        TextBoxAd.Visible = true;
        TextBoxEmail.Visible = true;
//        TextBoxSifre.Visible = true;
        TextBoxSoyad.Visible = true;
        Button1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String textMail, mailkontrol;
        String yoneticiAdi = TextBoxAd.Text;
        String yoneticiSoyadi = TextBoxSoyad.Text;
        String yoneticiMail = TextBoxEmail.Text;
//        String yoneticiSifre = TextBoxSifre.Text;
        String kod3 = (String)Session["kod"];
        DataRow loginDB2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod3 + "'");
        mailkontrol = loginDB2["email"].ToString();
        if (TextBoxAd.Text == "")
        {
            TextBoxAd.Text = LabelAd.Text;
        }
        if (TextBoxSoyad.Text == "")
        {
            TextBoxSoyad.Text = LabelSoyad.Text;
        } 
/*        if (TextBoxSifre.Text == "")
        {
            TextBoxSifre.Text = LabelSifre.Text;
        }*/

        if (TextBoxEmail.Text == "")
        {
            TextBoxEmail.Text = LabelMail.Text;

            textMail = LabelMail.Text;

            DataRow emailKontrol = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + yoneticiMail + "'");
            if (emailKontrol == null && textMail == mailkontrol)
            {
            DataRow yoneticiDB = veritabani.GetDataRow("UPDATE  yonetici SET ad='" + TextBoxAd.Text + "', soyad='" + TextBoxSoyad.Text + "' where kod = '" + kod3 + "'");
            DataRow loginDB = veritabani.GetDataRow("UPDATE  giris_bilgileri SET email='" + TextBoxEmail.Text + "' where kod = '" + kod3 + "'");
            Response.Write("<script>alert('Profil bilgileriniz başarıyla değiştirildi. ');</script>");
            Response.Redirect("~/yonetici/profilim.aspx");
        }
        else
        {
            Response.Write("<script>alert('Sisteme Daha önce bu mail adresi ile kayıt yapılmıştır. Lütfen mail adresini tekrar giriniz. ');</script>");
        }
        }
        else
        {

            textMail = TextBoxEmail.Text;

            DataRow emailKontrol = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + yoneticiMail + "'");
            if (emailKontrol != null && textMail == mailkontrol)
            {
                DataRow yoneticiDB = veritabani.GetDataRow("UPDATE  yonetici SET ad='" + TextBoxAd.Text + "', soyad='" + TextBoxSoyad.Text + "' where kod = '" + kod3 + "'");
                DataRow loginDB = veritabani.GetDataRow("UPDATE  giris_bilgileri SET email='" + TextBoxEmail.Text + "' where kod = '" + kod3 + "'");
                Response.Write("<script>alert('Profil bilgileriniz başarıyla değiştirildi. ');</script>");
                Response.Redirect("~/yonetici/profilim.aspx");
            }

            else
            {
                Response.Write("<script>alert('Sisteme Daha önce bu mail adresi ile kayıt yapılmıştır. Lütfen mail adresini tekrar giriniz. ');</script>");
            }
        }
    }
}