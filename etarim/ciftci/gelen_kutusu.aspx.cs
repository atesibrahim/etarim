using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class ciftci_gelen_kutusu : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    SqlCommand cmd = new SqlCommand();
    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    dbConnection ver2 = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ETARIM");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci2 = ver.GetDataRow("select * from ciftci where kod=" + adminid);

        if (adminid == 0 || drciftci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drciftci = ver.GetDataRow("select * from ciftci where kod=" + adminid);
            Label4.Visible = false;
            Label5.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Label3.Visible = false;
            Label2.Visible = false;

            if (!Page.IsPostBack)
            {
                BindData();


            }
        }
    }

    public void BindData()
    {
        
        GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
        String kod = (String)Session["kod"];
        DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
        String kime = gon["email"].ToString();


        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT kimden, tarih , konu,okundu,id FROM mesajlar WHERE  kime='" + kime + "' order by okundu, id DESC  ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "mesajlar");
        Conn.Open();
        Cmd.ExecuteNonQuery();
        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        // String[] idler = new String[GridView1.Columns.Count/2];

        if (GridView1.Rows.Count == 0)
        {
            Label4.Visible = false;
            Label5.Visible = false;
            Label3.Visible = false;
            Button1.Visible = false;
            mesaj.Visible = false;
            Label2.Visible = true;
            Button1.Visible = false;
            
        }

        foreach (GridViewRow dg in GridView1.Rows)
        {    //for (int i = 0; i < GridView1.Rows.Count; i++ )



            // Response.Write("<script>alert('"+dg.Cells.Equals("id").ToString();"'); </script>");


            System.Web.UI.WebControls.ImageButton id = (System.Web.UI.WebControls.ImageButton)GridView1.Rows[dg.RowIndex].FindControl("okundu");

            int m_id = Int32.Parse(id.AlternateText);
            if (m_id == 0)
            {
                id.ImageUrl = "~/image/unread.ico";

                GridView1.Rows[dg.RowIndex].BackColor = System.Drawing.Color.Bisque;
            }
            else
            {
                //GridView1.Rows[dg.RowIndex].Cells.Equals("okundu");
                id.ImageUrl = "~/image/read.ico";
            }

           
         /*   string text = GridView1.Rows[dg.RowIndex].Cells[2].Text;
            int say = text.Length;
            if (text.Length > 3) {

                text = text.Substring(0, 3);
            }*/

            

        }


    }
    protected void select(object sender, ImageClickEventArgs e)
    {
        Label4.Visible = false;
        Label5.Visible = false;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        Button2.Visible = true;
        Button3.Visible = false;
        mesaj.Visible = true;
       
        Label1.Visible = true;
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        SqlConnection Conn = new SqlConnection(s);
        System.Web.UI.WebControls.Label m_id = (System.Web.UI.WebControls.Label)row.FindControl("id");
        int id = Int32.Parse(m_id.Text);

        /// Response.Write("<script>alert('select !');</script>");

        // SqlCommand cmd2 = new SqlCommand("SELECT  mesaj FROM mesajlar WHERE id='" + id + "'  ", Conn);

        DataRow mesaji = veritabani.GetDataRow("select * from mesajlar where id='" + id + "'   ");
        mesaj.Text =  mesaji["mesaj"].ToString();
        Label1.Text = mesaji["konu"].ToString();
        System.Web.UI.WebControls.Label mail = (System.Web.UI.WebControls.Label)row.FindControl("kimden");
        String email = Convert.ToString(mail.Text);
        Label3.Text = email;


        cmd.Connection = Conn;
        cmd.CommandText = "UPDATE mesajlar SET okundu=1  WHERE id='" + id + "'  ";

        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        BindData();
        Conn.Close();


    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (MessageBox.Show("Mesajı Silmek İstiyormusunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;


            mesaj.Visible = false;
            Label2.Visible = false;

            //  Response.Redirect("~/");

            // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            System.Web.UI.WebControls.Label id = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("id");
            int m_id = Int32.Parse(id.Text);


            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("Delete from mesajlar where id='" + m_id + "'", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            BindData();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Mesajı Silmek İstiyormusunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            mesaj.Visible = false;
            Label2.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label1.Visible = false;

            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {

                    // Response.Write("<script>alert('"+dg.Cells.Equals("id").ToString();"'); </script>");


                    System.Web.UI.WebControls.Label id = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("id");
                    int m_id = Convert.ToInt32(id.Text);


                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand db = new SqlCommand("Delete from mesajlar where id='" + m_id + "'", Conn);

                    Conn.Open();
                    db.ExecuteNonQuery();
                    Conn.Close();

                }
            }
            BindData();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {// sayfalar arası geçiş yapmak için pageindex changing eventı altına kodları yazıoruz.
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = DS;
        BindData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        Button2.Visible = false;
        Button3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        TextBox1.Text = Label1.Text.ToString();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        
        TextBox2.Visible = false;
        Button2.Visible = true;
        Button3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;

        String kimin = Label3.Text.ToString();
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

                TextBox1.Text = "";
                TextBox2.Text = "";
                Button2.Visible = true;
               



            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }

    
    }
}