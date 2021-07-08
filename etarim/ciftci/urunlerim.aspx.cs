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


public partial class ciftci_urunlerim : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
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
        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar,fiyat.fiyat, isim.ad, tur.tur_ad,urun.urun_kod,urun.tur_kod FROM ciftci_urun urun INNER JOIN ciftci_urun_fiyat fiyat on urun.ciftci_kod=fiyat.ciftci_kod and fiyat.tur_kod=urun.tur_kod and fiyat.urun_kod=urun.urun_kod INNER JOIN  urun_isimleri isim on urun.urun_kod= isim.kod and urun.tur_kod= isim.tur_kod INNER JOIN urun_turleri tur on urun.tur_kod= tur.kod WHERE urun.ciftci_kod='" + kod + "' ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "ciftci_urun");
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
            System.Web.UI.WebControls.TextBox fiyat = (System.Web.UI.WebControls.TextBox)GridView1.Rows[dg.RowIndex].FindControl("fiyat");
            fiyat.ReadOnly = true;



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
            System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("tur_kod");
            int tur = Int32.Parse(tur_kod.Text);
            System.Diagnostics.Debug.WriteLine(urun);

            SqlConnection Conn = new SqlConnection(s);

            SqlCommand db2 = new SqlCommand("Delete from ciftci_urun_fiyat where ciftci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
            Conn.Open();
            db2.ExecuteNonQuery();
            Conn.Close();
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("Delete from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            BindData();

        }
    }


    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("miktar");
        System.Web.UI.WebControls.TextBox txfiyat = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("fiyat");

        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar,fiyat.fiyat, isim.ad, tur.tur_ad,urun.urun_kod,urun.tur_kod FROM ciftci_urun urun INNER JOIN ciftci_urun_fiyat fiyat on urun.ciftci_kod=fiyat.ciftci_kod and fiyat.tur_kod=urun.tur_kod and fiyat.urun_kod=urun.urun_kod INNER JOIN  urun_isimleri isim on urun.urun_kod= isim.kod and urun.tur_kod= isim.tur_kod INNER JOIN urun_turleri tur on urun.tur_kod= tur.kod WHERE urun.ciftci_kod='" + kod + "' ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "ciftci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();

        GridView1.Rows[e.NewEditIndex].BackColor = System.Drawing.Color.Aquamarine;
        txfiyat.ReadOnly = false;
        txtmiktar.ReadOnly = false;
        Button1.Enabled = false;
          yukle();
         

    }

    protected void yukle() {
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("miktar");
        System.Web.UI.WebControls.TextBox txfiyat = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("fiyat");

        txfiyat.ReadOnly = false;
        txtmiktar.ReadOnly = false;
        Button1.Enabled = false;
    
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        string[] alfabe = { "q", "w", "e", "r", "t", "y","u","ı","o","p","ğ","ü","a","s", "d", "f", "g", "h", "j", "k", "l", "ş", "i", "<", ">", "z", "x", "c", "v", "b", "n", "m", "ö", "ç","#", "$", "&","|"};

        String kod = (String)Session["kod"];
        SqlConnection Conn = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand();
        System.Web.UI.WebControls.Label urun_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("urun_kod");
        int urun = Int32.Parse(urun_kod.Text);
        System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("tur_kod");
        int tur = Int32.Parse(tur_kod.Text);
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].FindControl("miktar");
        Decimal miktar = Convert.ToDecimal(txtmiktar.Text);



        System.Web.UI.WebControls.TextBox txtfiyat = (System.Web.UI.WebControls.TextBox)GridView1.Rows[e.RowIndex].FindControl("fiyat");
        //       double fiyat = Convert.ToDouble(txtfiyat.Text);

        string fiyat = String.Format("{0:0.##}", txtfiyat.Text.Trim());
        System.Diagnostics.Debug.WriteLine(fiyat);

        txtfiyat.ReadOnly = true;
        txtmiktar.ReadOnly = true;
        Button1.Enabled = true;
        int p = 0;
        for (int i = 0; i < 38; i++)
        {
            if (fiyat.Contains(alfabe[i]))
            {
                p = p + 1;
            }
        }
            if (p == 0)
            {

                cmd.Connection = Conn;
                cmd.CommandText = "UPDATE ciftci_urun SET miktar='" + miktar + "'  WHERE ciftci_kod='" + kod + "' AND urun_kod='" + urun + "' and tur_kod='" + tur + "'";
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                BindData();
                Conn.Close();
                cmd.CommandText = "UPDATE ciftci_urun_fiyat SET ciftci_urun_fiyat.fiyat='" + fiyat + "'  WHERE ciftci_urun_fiyat.ciftci_kod='" + kod + "' AND ciftci_urun_fiyat.urun_kod='" + urun + "' and ciftci_urun_fiyat.tur_kod='" + tur + "'";

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                BindData();
                Conn.Close();
            }
            else
            {

                Response.Write("<script>alert('Harf Kullanamazsınız!.Doğru format 123.123 olmalıdır.'); </script>");
            }
        }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        System.Web.UI.WebControls.TextBox txtmiktar = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("miktar");
        System.Web.UI.WebControls.TextBox txfiyat = (System.Web.UI.WebControls.TextBox)GridView1.Rows[GridView1.EditIndex].FindControl("fiyat");
        txfiyat.ReadOnly = false;
        txtmiktar.ReadOnly = false;
        Button1.Enabled = true;
        GridView1.EditIndex = -1;
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
        {
              System.Web.UI.WebControls.CheckBox checkbox;
            checkbox = ((System.Web.UI.WebControls.CheckBox)dg.FindControl("CheckBox"));
            if (checkbox.Checked == true)
            {
                //  Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                String kod = (String)Session["kod"];
                System.Web.UI.WebControls.Label urun_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("urun_kod");
                int urun = Int32.Parse(urun_kod.Text);
                System.Web.UI.WebControls.Label tur_kod = (System.Web.UI.WebControls.Label)GridView1.Rows[dg.RowIndex].FindControl("tur_kod");
                int tur = Int32.Parse(tur_kod.Text);
                System.Diagnostics.Debug.WriteLine(urun);

                SqlConnection Conn = new SqlConnection(s);

                SqlCommand db2 = new SqlCommand("Delete from ciftci_urun_fiyat where ciftci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
                Conn.Open();
                db2.ExecuteNonQuery();
                Conn.Close();
                //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
                SqlCommand db = new SqlCommand("Delete from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= '" + urun + "' and tur_kod='" + tur + "'", Conn);
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