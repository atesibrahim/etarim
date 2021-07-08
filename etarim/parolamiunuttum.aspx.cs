using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using System.Net.NetworkInformation;

public partial class parolamiunuttum : System.Web.UI.Page
{
    dbConnection veritabani = new dbConnection("Connecting String");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String email = TextBox1.Text.Trim();
        if (email == "")
        {
            Response.Write("<script>alert('Email adresini giriniz.');</script>");
        }
        else
        {
            DataRow yoneticiDB = veritabani.GetDataRow("select sifre from giris_bilgileri where email= '" + email + "'");
            if (yoneticiDB == null)
            {


                Response.Write("<script>alert('Girdiğiniz mail adresi sistemde bulunmamaktadır. Lütfen mail adresinizi doğru giriniz');</script>");
            }
            else
            {
                String sifreal = yoneticiDB["sifre"].ToString();
                string sifre = Coz(sifreal);
                //            System.Diagnostics.Debug.WriteLine(sifre);
                //    SmtpClient client = new SmtpClient(); //host and port picked from web.config
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(System.Net.IPAddress.Parse("208.69.34.231"));

                if (pingStatus.Status != IPStatus.Success)
                {
                    Response.Write("<script>alert('İnternet bağlantısı olmadığından dolayı mail adresinize gönderilmemiştir. Bağlantıyı kontrol ediniz.');</script>");
                }
                else
                {

                    SmtpClient client = new SmtpClient("smtp.yandex.com", 587);
                    client.EnableSsl = true;
                    MailAddress from = new MailAddress("etarimsistemi@yandex.com", "E-Tarım Sistemi");
                    MailAddress to = new MailAddress(email, "");
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Şifreniz aşağıda gönderildiği gibidir  :\n\n" + sifre;
                    message.Subject = "E-Tarım Sistemi Parola Gönderme";
                    System.Net.NetworkCredential myCreds = new System.Net.NetworkCredential("etarimsistemi@yandex.com", "etarim", "");
                    client.Credentials = myCreds;

                    client.Send(message);




                    Response.Write("<script>alert('Parolanız mail adresinize gönderilmiştir.');</script>");
                    TextBox1.Text = "";
                    //Response.Redirect("~/login.aspx");

                }
            }   
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
    static public string Coz(string cozVeri)

{

    byte[] cozByteDizi = System.Convert.FromBase64String(cozVeri);

    string orjinalVeri= System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);

    return orjinalVeri;

}

    }