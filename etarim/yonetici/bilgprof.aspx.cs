using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

public partial class yonetici_bilgprof : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veritabani = new dbConnection("ETARIM");
    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drYonetici2 = veritabani.GetDataRow("select * from yonetici where kod=" + adminid);

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
            /* lblAdminName.Text = drciftci["ad"].ToString();*/


        if (!Page.IsPostBack)
        {
            BindData();
        }
        }
    }

    public void BindData()
    {


        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT bilgisayar_prof.kod, bilgisayar_prof.ad, bilgisayar_prof.soyad, bilgisayar_prof.cep_tel, bilgisayar_prof.adres,adres_ilce.ad as adres_ilce, adres_il.ad as adres_il, giris_bilgileri.aktifpasif as ap, giris_bilgileri.email FROM bilgisayar_prof  INNER JOIN adres_il on (bilgisayar_prof.adres_il=adres_il.kod) INNER JOIN adres_ilce on (bilgisayar_prof.adres_ilce=adres_ilce.kod) INNER JOIN giris_bilgileri on bilgisayar_prof.kod= giris_bilgileri.kod  ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "bilgisayar_prof");
        Conn.Open();
        Cmd.ExecuteNonQuery();
        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        Label3.Visible = false;
        if (GridView1.Rows.Count == 0) {
            Button1.Visible = false;
            Label3.Visible = true;
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
       




    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            //  Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");

            System.Web.UI.WebControls.Label bil_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("kod");
            int bil = Int32.Parse(bil_kod.Text);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

            SqlCommand db3 = new SqlCommand("Delete from bilgisayar_prof where kod='" + bil + "' ", Conn);

            Conn.Open();
            db3.ExecuteNonQuery();
            Conn.Close();
            SqlCommand db = new SqlCommand("Delete from giris_bilgileri where kod='" + bil + "' and kim=3 ", Conn);

            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();

            BindData();
        }
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        System.Web.UI.WebControls.Label toptanci_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("kod");
        int toptanci = Int32.Parse(toptanci_kod.Text);

        SqlConnection Conn = new SqlConnection(s);
        SqlCommand db3 = new SqlCommand("UPDATE giris_bilgileri set  aktifpasif =0 where kod='" + toptanci + "' ", Conn);

        Conn.Open();
        db3.ExecuteNonQuery();
        Conn.Close();
        BindData();

        Response.Write("<script>alert('Kullanıcı başarılı bir şekilde pasif edildi.'); </script>");


    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        System.Web.UI.WebControls.Label toptanci_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("kod");
        int toptanci = Int32.Parse(toptanci_kod.Text);

        SqlConnection Conn = new SqlConnection(s);
        SqlCommand db3 = new SqlCommand("UPDATE giris_bilgileri set  aktifpasif =1 where kod='" + toptanci + "' ", Conn);

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
            //  Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");

            ImageButton img = (ImageButton)sender;
            GridViewRow row = (GridViewRow)img.Parent.Parent;
            System.Web.UI.WebControls.Label bil_kod = (System.Web.UI.WebControls.Label)row.FindControl("kod");
            int bil = Int32.Parse(bil_kod.Text);

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

            SqlCommand db3 = new SqlCommand("Delete from bilgisayar_prof where kod='" + bil + "' ", Conn);

            Conn.Open();
            db3.ExecuteNonQuery();
            Conn.Close();
            SqlCommand db = new SqlCommand("Delete from giris_bilgileri where kod='" + bil + "' and kim=3 ", Conn);

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
            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {

                    // Response.Write("<script>alert('"+dg.Cells.Equals("id").ToString();"'); </script>");


                    System.Web.UI.WebControls.Label id = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("kod");
                    int bil = Convert.ToInt32(id.Text);
                    SqlConnection Conn = new SqlConnection(s);
                    //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);

                    SqlCommand db3 = new SqlCommand("Delete from bilgisayar_prof where kod='" + bil + "' ", Conn);

                    Conn.Open();
                    db3.ExecuteNonQuery();
                    Conn.Close();
                    SqlCommand db = new SqlCommand("Delete from giris_bilgileri where kod='" + bil + "' and kim=3 ", Conn);

                    Conn.Open();
                    db.ExecuteNonQuery();
                    Conn.Close();

                }
            }
            BindData();
        }
    }
}