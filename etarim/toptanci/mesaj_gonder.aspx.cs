using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class toptanci_mesaj_gonder : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ETARIM");
    dbConnection veritabani2 = new dbConnection("Connectionstring");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani2.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drtoptanci2 = veritabani2.GetDataRow("select * from toptanci where kod=" + adminid);

        if (adminid == 0 || drtoptanci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani2.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drtoptanci = veritabani2.GetDataRow("select * from toptanci where kod=" + adminid);
        }
    }
    protected void digerleri(object sender, EventArgs e)
    {
        kime.Visible = true;

    }
    protected void yon_teknik(object sender, EventArgs e)
    {
        kime.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (yonetici.Checked)
        {

            // Response.Write("<script>alert('yönetici!'); </script>");
            kime.Visible = True;
            String kimin = "SİSTEM YÖNETİCİSİ";
            String konusu = konu.Text.ToString();
            String mesaji = mesaj.Text.ToString();
            String kod = Session["kod"].ToString();
            String zaman = DateTime.Now.ToString();

            if (konusu == "" && mesaji == "")
            {
                Response.Write("<script>alert('Mesaj ve Konusu Boş Bırakılamaz!'); </script>");
            }
            else
            {

                if (konusu == "")
                {
                    konusu = "KONU YOK";
                }
                DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
                String kimden = gon["email"].ToString();



                ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
                ver2.CmdText = "Insert Into [mesaj_gonderilen] (kimden,kime,tarih,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "','" + konusu + "','" + mesaji + "')";

                if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                {
                    Response.Write("<script>alert('MESAJ YÖNETİCİYE GÖNDERİLDİ!'); </script>");
                    kime.Text = "";
                    konu.Text = "";
                    mesaj.Text = "";
                }
                else
                {
                    Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
                }


            }
        }
        else
            if (teknik.Checked)
            {
                //Response.Write("<script>alert('Teknik!'); </script>");
                kime.Visible = True;
                String kimin = "SİSTEM DESTEK PERSONELİ";
                String konusu = konu.Text.ToString();
                String mesaji = mesaj.Text.ToString();
                String kod = Session["kod"].ToString();
                String zaman = DateTime.Now.ToString();
                if (konusu == "" && mesaji == "")
                {
                    Response.Write("<script>alert('Mesaj ve Konusu Boş Bırakılamaz!'); </script>");
                }
                else
                {

                    if (konusu == "")
                    {
                        konusu = "KONU YOK";
                    }
                    DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
                    String kimden = gon["email"].ToString();



                    ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
                    ver2.CmdText = "Insert Into [mesaj_gonderilen] (kimden,kime,tarih,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "','" + konusu + "','" + mesaji + "')";

                    if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                    {
                        Response.Write("<script>alert('MESAJ TEKNİK DESTEĞE GÖNDERİLDİ!'); </script>");
                        kime.Text = "";
                        konu.Text = "";
                        mesaj.Text = "";

                    }
                    else
                    {
                        Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
                    }


                }
            }
            else
                if (diger.Checked)
                {
                    kime.Visible = True;
                    String kimin = kime.Text.ToString();
                    String konusu = konu.Text.ToString();
                    String mesaji = mesaj.Text.ToString();
                    String kod = Session["kod"].ToString();
                    String zaman = DateTime.Now.ToString();
                    if (konusu == "" && mesaji == "")
                    {
                        Response.Write("<script>alert('Mesaj ve Konusu Boş Bırakılamaz!'); </script>");
                    }
                    else
                    {

                        if (konusu == "")
                        {
                            konusu = "KONU YOK";
                        }
                        DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
                        String kimden = gon["email"].ToString();

                        DataRow mail_kont = veritabani.GetDataRow("select * from giris_bilgileri where email='" + kimin + "' ");

                        if (mail_kont != null)
                        {

                            ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
                            ver2.CmdText = "Insert Into [mesaj_gonderilen] (kimden,kime,tarih,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "','" + konusu + "','" + mesaji + "')";

                            if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                            {
                                Response.Write("<script>alert('MESAJ GÖNDERİLDİ!'); </script>");
                                kime.Text = "";
                                konu.Text = "";
                                mesaj.Text = "";

                            }
                            else
                            {
                                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('Alıcı Mailini Yanlış Girdiniz!'); </script>");
                        }



                        //   Response.Write("<script>alert('gonderiyor!'); </script>");

                    }
                }
    }

    public bool True { get; set; }
}