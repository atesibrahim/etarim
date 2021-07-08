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

public partial class bilgisayarprof_gonderilenler : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    DataSet DS = new DataSet();
    dbConnection ver = new dbConnection("ConnectionString");
    Veri con = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ETARIM");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci2 = ver.GetDataRow("select * from bilgisayar_prof where kod=" + adminid);
        if (adminid == 0 || drciftci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = ver.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drciftci = ver.GetDataRow("select * from bilgisayar_prof where kod=" + adminid);
            /* lblAdminName.Text = drciftci["ad"].ToString();*/

        
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
        String kimden = gon["email"].ToString();

        SqlConnection Conn = new SqlConnection(s);
        SqlCommand Cmd = new SqlCommand("SELECT kime, tarih , konu,id FROM mesaj_gonderilen WHERE  kimden='" + kimden + "' or kimden='SİSTEM DESTEK PERSONELİ' order by id DESC", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "mesaj_gonderilen");
        Conn.Open();
        Cmd.ExecuteNonQuery();
        GridView1.DataSource = DS;
        GridView1.DataBind();
        Conn.Close();
        if (GridView1.Rows.Count == 0)
        {
            Button1.Visible = false;
            Label3.Text = "Gönderilenler Kutusu boş.";
        }


    }
    protected void select(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        SqlConnection Conn = new SqlConnection(s);
        System.Web.UI.WebControls.Label m_id = (System.Web.UI.WebControls.Label)row.FindControl("id");
        int id = Int32.Parse(m_id.Text);

        /// Response.Write("<script>alert('select !');</script>");

        // SqlCommand cmd2 = new SqlCommand("SELECT  mesaj FROM mesajlar WHERE id='" + id + "'  ", Conn);

        DataRow mesaji = veritabani.GetDataRow("select * from mesaj_gonderilen where id='" + id + "'   ");
        mesaj.Text = mesaji["mesaj"].ToString();
        Label4.Text = mesaji["konu"].ToString();





    }

    /* protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {
          if (MessageBox.Show("Mesajı Silmek İstiyormusunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {


            //  Response.Redirect("~/");
              // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
              String kod = (String)Session["kod"];
              System.Web.UI.WebControls.Label id = (System.Web.UI.WebControls.Label)GridView1.Rows[e.RowIndex].FindControl("id");
              int m_id = Int32.Parse(id.Text);


              SqlConnection Conn = new SqlConnection(s);
              //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
              SqlCommand db = new SqlCommand("Delete from mesaj_gonderilen where id='" + m_id + "'", Conn);
              //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
              Conn.Open();
              db.ExecuteNonQuery();
              Conn.Close();
              BindData();
          }
      }*/


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Mesajı Silmek İstiyormusunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
            Label4.Visible = false;
            mesaj.Visible = false;
            // Response.Write("<script>alert(burda) </script>");
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
                    SqlCommand db = new SqlCommand("Delete from mesaj_gonderilen where id='" + m_id + "'", Conn);

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
}