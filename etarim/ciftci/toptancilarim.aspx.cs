using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ciftci_toptancilarim : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    dbConnection ver2 = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
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
            Label8.Visible = false;
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }
    public void BindData()
    {
        Button3.Visible = false;
        Button4.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT ciftci_toptanci.t_edilen, toptanci.ad, toptanci.soyad, toptanci.is_tel, adres_il.ad as il, email FROM toptanci , adres_il ,ciftci_toptanci,giris_bilgileri WHERE  ciftci_toptanci.t_eden='" + kod + "' AND toptanci.kod = ciftci_toptanci.t_edilen AND toptanci.adres_il = adres_il.kod and giris_bilgileri.kod=ciftci_toptanci.t_edilen  ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "ciftci_toptanci");
        Conn.Open();
        Cmd.ExecuteNonQuery();
        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        Label5.Visible = false;
        if (GridView1.Rows.Count == 0) {
            Label5.Visible = true;
            Label5.Text = "Ekli Toptancınız Bulunmamaktadır!";
            Button5.Visible = false;
        
        }



    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            Label t_edilen = (Label)GridView1.Rows[e.RowIndex].FindControl("t_edilen");
            int takip = Int32.Parse(t_edilen.Text);
            System.Diagnostics.Debug.WriteLine(takip);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("Delete from ciftci_toptanci where t_eden='" + kod + "' and t_edilen= '" + takip + "'", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            BindData();
        }
    }
    protected void select(object sender, GridViewSelectEventArgs e)
    {
        Button3.Visible = true;
        Button4.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        SqlConnection Conn = new SqlConnection(s);
        Label t_edilen = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("t_edilen");
        int takip = Int32.Parse(t_edilen.Text);
        Label ad = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("ad");
        String adi = Convert.ToString(ad.Text);
        Label soyad = (Label)GridView1.Rows[e.NewSelectedIndex].FindControl("soyad");
        String soyadi = soyad.Text.ToString();
        Label1.Text = adi;
        Label2.Text = soyadi;
       
       // Label6.Text = "Toptancının Ekli Ürünü Yok";
        System.Diagnostics.Debug.WriteLine(takip);
        // Response.Write("<script>alert('select !');</script>");

        SqlCommand cmd2 = new SqlCommand("SELECT  ad, soyad FROM toptanci WHERE kod='" + takip + "'  ", Conn);


        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar, isim.ad, tur.tur_ad FROM toptanci_urun urun , urun_isimleri isim, urun_turleri tur WHERE urun.toptanci_kod='" + takip + "'  AND urun.urun_kod= isim.kod AND isim.tur_kod=tur.kod AND urun.tur_kod=tur.kod ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "toptanci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView2.DataSource = DS;
        GridView2.DataBind();
        Conn.Close();

        if (GridView2.Rows.Count != 0)
        {
            Label3.Text = "İhtiyaç Duyduğu Ürünler";
        }
        else {
            Label3.Text = "Toptancının Ekli Ürünü Yok!";
        }

    }

    protected void delete(object sender, ImageClickEventArgs e)
    {
        
     
     

        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;
            System.Web.UI.WebControls.Label t_edilen = (System.Web.UI.WebControls.Label)row.FindControl("t_edilen");
           
            int takip = Int32.Parse(t_edilen.Text);
            System.Diagnostics.Debug.WriteLine(takip);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("Delete from ciftci_toptanci where t_eden='" + kod + "' and t_edilen= '" + takip + "'", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            BindData();
        }

    }
    protected void sec(object sender, ImageClickEventArgs e)
    {
        Button3.Visible = true;
        Button4.Visible = false;
        TextBox3.Visible = false;
        TextBox4.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        SqlConnection Conn = new SqlConnection(s); 
            // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;
            System.Web.UI.WebControls.Label t_edilen = (System.Web.UI.WebControls.Label)row.FindControl("t_edilen");
            int takip = Int32.Parse(t_edilen.Text);
            System.Web.UI.WebControls.Label ad = (System.Web.UI.WebControls.Label)row.FindControl("ad");

            System.Web.UI.WebControls.Label soyad = (System.Web.UI.WebControls.Label)row.FindControl("soyad");
            String adi = Convert.ToString(ad.Text);
           
            String soyadi = soyad.Text.ToString();
            Label1.Text = adi;
            Label2.Text = soyadi;
            Label3.Text = "İhtiyaç Duyduğu Ürünler";
            DataRow mail = veritabani.GetDataRow("select email from giris_bilgileri where kod = '" + takip + "'");
            Label8.Text = mail["email"].ToString();

            SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar, isim.ad, tur.tur_ad FROM toptanci_urun urun , urun_isimleri isim, urun_turleri tur WHERE urun.toptanci_kod='" + takip + "'  AND urun.urun_kod= isim.kod AND isim.tur_kod=tur.kod AND urun.tur_kod=tur.kod ", Conn);

            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci_urun");
            Conn.Open();
            Cmd.ExecuteNonQuery();

            GridView2.DataSource = DS;
            GridView2.DataBind();
            Conn.Close();

           
        }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {// sayfalar arası geçiş yapmak için pageindex changing eventı altına kodları yazıoruz.
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = DS;
        BindData();
    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Button3.Visible = false;
        Button4.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        String kimin = Label8.Text.ToString();
        String konusu = TextBox3.Text.ToString();
        String mesaji = TextBox4.Text.ToString();
        String kod = Session["kod"].ToString();
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


            DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
            String kimden = gon["email"].ToString();



            ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
            ver2.CmdText = "Insert Into [mesaj_gonderilen] (kimden,kime,tarih,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "','" + konusu + "','" + mesaji + "')";

            if (ver.NonQuery > 0 && ver2.NonQuery > 0)
            {
                Response.Write("<script>alert('MESAJ GÖNDERİLDİ!'); </script>");
                TextBox3.Visible = false;
                TextBox4.Visible = false;
                TextBox3.Text = "";
                TextBox4.Text = "";
                Button3.Visible = true;
                Button4.Visible = false;
                Label7.Visible = false;
                Label6.Visible = false;



            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Label7.Visible = false;
            Label6.Visible = false;
            GridView2.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label8.Visible = false;
            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {
                    // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                    String kod = (String)Session["kod"];
                  //  ImageButton img = (ImageButton)sender;
                   // GridViewRow row = (GridViewRow)img.Parent.Parent;
                    Label t_edilen = (Label)GridView1.Rows[dg.RowIndex].FindControl("t_edilen");
                    int takip = Int32.Parse(t_edilen.Text);
                    System.Diagnostics.Debug.WriteLine(takip);

                    SqlConnection Conn = new SqlConnection(s);
                    //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
                    SqlCommand db = new SqlCommand("Delete from ciftci_toptanci where t_eden='" + kod + "' and t_edilen= '" + takip + "'", Conn);
                    //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
                    Conn.Open();
                    db.ExecuteNonQuery();
                    Conn.Close();

                }
            }
            BindData();
        }
    }
}