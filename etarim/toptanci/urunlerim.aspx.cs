using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class toptanci_urunlerim : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drtoptanci2 = ver.GetDataRow("select * from toptanci where kod=" + adminid);

        if (adminid == 0 || drtoptanci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drtoptanci = ver.GetDataRow("select * from toptanci where kod=" + adminid);
            if (!Page.IsPostBack)
            {
                BindData();

            }
        }
    }
    public void BindData()
    {

        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar, isim.ad, tur.tur_ad, urun.urun_kod ,urun.tur_kod FROM toptanci_urun urun , urun_isimleri isim, urun_turleri tur WHERE urun.toptanci_kod='" + kod + "' AND  urun.urun_kod= isim.kod AND isim.tur_kod=tur.kod AND urun.tur_kod=tur.kod ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "toptanci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        Label2.Visible = false;
        if (GridView1.Rows.Count == 0)
        {
            Label2.Visible = true;
            Button1.Visible = false;
        }


        foreach (GridViewRow dg in GridView1.Rows)
        {

            System.Web.UI.WebControls.TextBox miktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[dg.RowIndex].FindControl("miktar");
            miktar.ReadOnly = true;

        }

    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindData();
    }



    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {

            //  Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            System.Web.UI.WebControls.Label urun_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("urun_kod");
            int urun = Int32.Parse(urun_kod.Text);
            System.Diagnostics.Debug.WriteLine(urun);
            System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("tur_kod");
            int tur = Int32.Parse(tur_kod.Text);
            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("Delete from toptanci_urun where toptanci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            BindData();

        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {


        GridView1.Rows[e.NewEditIndex].BackColor = System.Drawing.Color.Aquamarine;
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.Rows[e.NewEditIndex].BackColor = System.Drawing.Color.Aquamarine;
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[e.NewEditIndex].FindControl("miktar");
        txtmiktar.ReadOnly = false;
        Button1.Enabled = false;
        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar, isim.ad, tur.tur_ad, urun.urun_kod ,urun.tur_kod FROM toptanci_urun urun , urun_isimleri isim, urun_turleri tur WHERE urun.toptanci_kod='" + kod + "' AND  urun.urun_kod= isim.kod AND isim.tur_kod=tur.kod AND urun.tur_kod=tur.kod ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "toptanci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
       
         yukle();
    }

    protected void yukle() {
        GridView1.Rows[GridView1.EditIndex].BackColor = System.Drawing.Color.Aquamarine;
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("miktar");
        txtmiktar.ReadOnly = false;
        Button1.Enabled = false;
    
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand();
        System.Web.UI.WebControls.Label urun_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("urun_kod");
        int urun = Int32.Parse(urun_kod.Text);
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].FindControl("miktar");
        System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("tur_kod");
        int tur = Int32.Parse(tur_kod.Text);
        // double fiyat = Convert.ToDouble(txtfiyat.Text);
        txtmiktar.ReadOnly = true;
        Button1.Enabled = true;
        cmd.Connection = Conn;
        cmd.CommandText = "UPDATE toptanci_urun SET miktar='" + txtmiktar.Text + "'  WHERE toptanci_kod='" + kod + "' AND urun_kod='" + urun + "' AND tur_kod='" + tur + "'  ";
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();


        GridView1.EditIndex = -1;
        BindData();
        Conn.Close();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Button1.Enabled = true;
        GridView1.EditIndex = -1;
        //   Response.Redirect("~/toptanci/urunlerim.aspx");
        BindData();
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (System.Windows.Forms.MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        {
            foreach (GridViewRow dg in GridView1.Rows)
            {    // for (int i = 0; i < GridView1.Rows.Count; i++)

                System.Web.UI.WebControls.CheckBox checkbox;
                checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
                if (checkbox.Checked == true)
                {

                    //  Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                    String kod = (String)Session["kod"];
                    System.Web.UI.WebControls.Label urun_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("urun_kod");
                    int urun = Int32.Parse(urun_kod.Text);
                    System.Diagnostics.Debug.WriteLine(urun);
                    System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("tur_kod");
                    int tur = Int32.Parse(tur_kod.Text);
                    SqlConnection Conn = new SqlConnection(s);
                    //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
                    SqlCommand db = new SqlCommand("Delete from toptanci_urun where toptanci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
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