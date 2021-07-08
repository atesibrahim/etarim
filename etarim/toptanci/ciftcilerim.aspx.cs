using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class toptanci_ciftcilerim : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veritabani = new dbConnection("ConnectionString");
    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    dbConnection ver2 = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drtoptanci2 = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);

        if (adminid == 0 || drtoptanci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drtoptanci = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);
            if (!Page.IsPostBack)
            {
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;
                BindData();
            }
        }
    }
    public void BindData()
    {

        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT ciftci_toptanci.t_edilen, ciftci.ad, ciftci.soyad, ciftci.cep_tel, adres_il.ad as il FROM ciftci INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN ciftci_toptanci on ciftci_toptanci.t_edilen= ciftci.kod  and ciftci_toptanci.t_eden='" + kod + "' ", Conn);

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
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            GridView2.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Button3.Visible = false;
        }




    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            GridView2.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
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
    protected void sec(object sender, ImageClickEventArgs e)
    {
        
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        GridView2.Visible = true;
        Label6.Visible = true;
        Button1.Visible = true;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
       
        Button2.Visible = false;
        

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
        DataRow mail = veritabani.GetDataRow("select email from giris_bilgileri where kod = '" + takip + "'");
        String soyadi = soyad.Text.ToString();
        Label1.Text = adi;
        Label2.Text = soyadi;
        Label6.Text = mail["email"].ToString();
        

        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar,fiyat.fiyat, isim.ad, tur.tur_ad,urun.urun_kod,urun.tur_kod FROM ciftci_urun urun INNER JOIN ciftci_urun_fiyat fiyat on urun.ciftci_kod=fiyat.ciftci_kod and fiyat.tur_kod=urun.tur_kod and fiyat.urun_kod=urun.urun_kod INNER JOIN  urun_isimleri isim on urun.urun_kod= isim.kod and urun.tur_kod= isim.tur_kod INNER JOIN urun_turleri tur on urun.tur_kod= tur.kod WHERE urun.ciftci_kod='" +takip + "' ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "ciftci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView2.DataSource = DS;
        GridView2.DataBind();
        Conn.Close();
        if(GridView2.Rows.Count!=0){
        Label3.Text = "Çiftçinin Elindeki Ürünler";
        }else{
            Label3.Text = "Çiftçinin Ekli Ürünü Bulunmamaktadır!";
           
        }


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        Button1.Visible = false;
        Button2.Visible = true;
        Label7.Visible = true;
        Label8.Visible = true;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        // Response.Write("<script>alert('yönetici!'); </script>");

        String kimin = Label6.Text.ToString();
        String konusu = TextBox1.Text.ToString();
        String mesaji = TextBox2.Text.ToString();
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
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Button1.Visible = true;
                Button2.Visible = false;
                Label7.Visible = false;
                Label8.Visible = false;



            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {

            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            GridView2.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button1.Visible = false;
            Button2.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            Button3.Visible = true;

            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {

                    // Response.Write("<script>alert('"+dg.Cells.Equals("id").ToString();"'); </script>");


                    String kod = (String)Session["kod"];
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
                    BindData();

                }
            }
            BindData();
        }
    }
}