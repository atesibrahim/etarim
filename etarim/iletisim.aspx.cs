using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class iletisim : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

   
   
    dbConnection ver = new dbConnection("ConnectionString");
     Veri con = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ETARIM");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String kimin = "SİSTEM YÖNETİCİSİ";
        String kimden = TextBox3.Text.ToString();
        String konusu = TextBox4.Text.ToString();
        String mesaji = TextBox5.Text.ToString()+"\n"+TextBox1.Text.ToString()+" "+TextBox2.Text.ToString();
      
        String zaman = DateTime.Now.ToString();
        
        if (konusu == "" && mesaji == "")
        {
            Response.Write("<script>alert('Mesaj Konsu ve Mesaj Boş Bırakılamaz!'); </script>");
        }
        else
        {
            if (konusu == "")
            {
                konusu = "KONU YOK";
            }

            

            ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
          

            if (ver.NonQuery > 0 )
            {
                Response.Write("<script>alert('MESAJ GÖNDERİLDİ!'); </script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
               
            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }
    }
}