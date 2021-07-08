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

public partial class yonetici_ciftciler : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veritabani = new dbConnection("ETARIM");
    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drYonetici2 = ver.GetDataRow("select * from yonetici where kod=" + adminid);

        if (adminid == 0 || drYonetici2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drYonetici = ver.GetDataRow("select * from yonetici where kod=" + adminid);
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
    }

    public void BindData()
    {


        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT ciftci.kod, ciftci.ad, ciftci.soyad, ciftci.cep_tel,ciftci.ev_tel, adres_il.ad as adres, giris_bilgileri.aktifpasif as ap, giris_bilgileri.email FROM ciftci INNER JOIN adres_il on (ciftci.adres_il=adres_il.kod) INNER JOIN giris_bilgileri on giris_bilgileri.kod=ciftci.kod", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "ciftci");
        Conn.Open();
        Cmd.ExecuteNonQuery();
        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        Label13.Visible = false;
        if (GridView1.Rows.Count == 0) {
            Button1.Visible = false;
            Label13.Visible = true;
        }
        foreach (GridViewRow dg in GridView1.Rows)
        {    //for (int i = 0; i < GridView1.Rows.Count; i++ )



            // Response.Write("<script>alert('"+dg.Cells.Equals("id").ToString();"'); </script>");


            System.Web.UI.WebControls.ImageButton id = (System.Web.UI.WebControls.ImageButton)GridView1.Rows[dg.RowIndex].FindControl("ap");

            int m_id = Int32.Parse(id.AlternateText);
            if (m_id == 0)
            {
                id.ImageUrl = "~/image/pasive.ico";

                GridView1.Rows[dg.RowIndex].BackColor = System.Drawing.Color.Aqua;
            }
            else
            {
                //GridView1.Rows[dg.RowIndex].Cells.Equals("okundu");
                id.ImageUrl = "~/image/active.ico";
            }
            }
        if (GridView1.Rows.Count == 0)
        {
            
            Label12.Text = "Sisteme kayıtlı çiftçi yok.";
        }



    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {

            System.Web.UI.WebControls.Label ciftci_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("kod");
            int ciftci = Int32.Parse(ciftci_kod.Text);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

            SqlCommand db3 = new SqlCommand("Delete from ciftci_urun_fiyat where ciftci_kod='" + ciftci + "' ", Conn);

            Conn.Open();
            db3.ExecuteNonQuery();
            Conn.Close();

            SqlCommand db2 = new SqlCommand("Delete from ciftci_urun where ciftci_kod='" + ciftci + "' ", Conn);

            Conn.Open();
            db2.ExecuteNonQuery();
            Conn.Close();


            SqlCommand db = new SqlCommand("Delete from ciftci where kod='" + ciftci + "' ", Conn);
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();

            SqlCommand db4 = new SqlCommand("Delete from giris_bilgileri where kod='" + ciftci + "' and kim=0 ", Conn);
            Conn.Open();
            db4.ExecuteNonQuery();
            Conn.Close();



            BindData();
        }
    }
   
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        System.Web.UI.WebControls.Label ciftci_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("kod");
        int ciftci = Int32.Parse(ciftci_kod.Text);

        SqlConnection Conn = new SqlConnection(s);
        SqlCommand db3 = new SqlCommand("UPDATE giris_bilgileri set  aktifpasif =1 where kod='" + ciftci + "' ", Conn);

        Conn.Open();
        db3.ExecuteNonQuery();
        Conn.Close();
        BindData();

        Response.Write("<script>alert('Kullanıcı başarılı bir şekilde aktif edildi.'); </script>");

    }

    protected void ap(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        SqlConnection Conn = new SqlConnection(s);
        System.Web.UI.WebControls.Label m_id = (System.Web.UI.WebControls.Label)row.FindControl("kod");
        int id = Int32.Parse(m_id.Text);

        DataRow ap = veritabani.GetDataRow("select aktifpasif from giris_bilgileri where kod='" + id + "'   ");
        String bak = ap["aktifpasif"].ToString();
        if (bak == "0")
        {
            SqlConnection Conn1 = new SqlConnection(s);
            SqlCommand db3 = new SqlCommand("UPDATE giris_bilgileri set  aktifpasif =1 where kod='" + id + "' ", Conn1);

            Conn1.Open();
            db3.ExecuteNonQuery();
            Conn1.Close();
            BindData();

            Response.Write("<script>alert('Kullanıcı başarılı bir şekilde aktif edildi.'); </script>");
        }
        else
        {

            SqlConnection Conn2 = new SqlConnection(s);
            SqlCommand db3 = new SqlCommand("UPDATE giris_bilgileri set  aktifpasif =0 where kod='" + id + "' ", Conn2);

            Conn2.Open();
            db3.ExecuteNonQuery();
            Conn2.Close();
            BindData();

            Response.Write("<script>alert('Kullanıcı başarılı bir şekilde pasif edildi.'); </script>");
        }

    }

    protected void delete(object sender, ImageClickEventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;
            
            System.Web.UI.WebControls.Label ciftci_kod = (System.Web.UI.WebControls.Label)row.FindControl("kod");

            
            int ciftci = Int32.Parse(ciftci_kod.Text);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

            SqlCommand db3 = new SqlCommand("Delete from ciftci_urun_fiyat where ciftci_kod='" + ciftci + "' ", Conn);

            Conn.Open();
            db3.ExecuteNonQuery();
            Conn.Close();

            SqlCommand db2 = new SqlCommand("Delete from ciftci_urun where ciftci_kod='" + ciftci + "' ", Conn);

            Conn.Open();
            db2.ExecuteNonQuery();
            Conn.Close();


            SqlCommand db = new SqlCommand("Delete from ciftci where kod='" + ciftci + "' ", Conn);
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();

            SqlCommand db4 = new SqlCommand("Delete from giris_bilgileri where kod='" + ciftci + "' and kim=0 ", Conn);
            Conn.Open();
            db4.ExecuteNonQuery();
            Conn.Close();



            BindData();
        }
     
    
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Çiftçileri Silmek İstiyormusunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {

                    System.Web.UI.WebControls.Label id = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("kod");
                    int ciftci = Convert.ToInt32(id.Text);

                    SqlConnection Conn = new SqlConnection(s);
                    //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

                    SqlCommand db3 = new SqlCommand("Delete from ciftci_urun_fiyat where ciftci_kod='" + ciftci + "' ", Conn);

                    Conn.Open();
                    db3.ExecuteNonQuery();
                    Conn.Close();

                    SqlCommand db2 = new SqlCommand("Delete from ciftci_urun where ciftci_kod='" + ciftci + "' ", Conn);

                    Conn.Open();
                    db2.ExecuteNonQuery();
                    Conn.Close();


                    SqlCommand db = new SqlCommand("Delete from ciftci where kod='" + ciftci + "' ", Conn);
                    Conn.Open();
                    db.ExecuteNonQuery();
                    Conn.Close();

                    SqlCommand db4 = new SqlCommand("Delete from giris_bilgileri where kod='" + ciftci + "' and kim=0 ", Conn);
                    Conn.Open();
                    db4.ExecuteNonQuery();
                    Conn.Close();



                    
                }
            }
            BindData();
        }
    }
}