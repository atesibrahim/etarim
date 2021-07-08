using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class login : System.Web.UI.Page
{
    dbConnection ver = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        string email = txtUsername.Text.Trim();
        string passwordal = txtPassword.Text.Trim();
        string password = Sifrele(passwordal);

        if (email == "" || password == "")
        {
            Response.Write("<script>alert('Boş alan bırakmayınız !');</script>");
        }
        else
        {
            
            DataRow drLogin = ver.GetDataRow("select * from giris_bilgileri where email='" + email + "' and sifre='" + password + "' ");
            
            if (drLogin != null)
            {

                 
                Session["kod"] = drLogin["kod"].ToString();
                string kim = drLogin["kim"].ToString();
                string aktifpasif = drLogin["aktifpasif"].ToString();
                System.Diagnostics.Debug.WriteLine(aktifpasif);
                if (aktifpasif != "0")
                {
                    if (kim == "0")
                    {
                        Response.Redirect("~/ciftci/Default.aspx");
                    }
                    else if (kim == "1")
                    {
                        Response.Redirect("~/toptanci/Default.aspx");
                    }
                    else if (kim == "2")
                    {
                        Response.Redirect("~/yonetici/Default.aspx");
                    }
                    else if (kim == "3")
                    {
                        Response.Redirect("~/bilgisayarprof/Default.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Hesabınız kullanıma kapatılmıştır. Lütfen yöneticiye başvurunuz.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Girdiğiniz bilgiler yanlış !');</script>");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/parolamiunuttum.aspx");
    }
    static public string Sifrele(string veri)
    {
        // gelen veri byte dizisine aktarılıyor 
        byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
        // base64 şifreleme algoritmasına göre şifreleniyor.
        string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
        return sifrelenmisVeri;
    }
}