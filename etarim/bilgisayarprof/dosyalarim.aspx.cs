using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

public partial class bilgisayarprof_dosyalarim : System.Web.UI.Page
{

    dbConnection veritabani = new dbConnection("ConnectionString");
    dbConnection ver = new dbConnection("ConnectionString");
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



            DataRow dosyalar = veritabani.GetDataRow("select * from dosyalar");
            if (dosyalar == null)
            {
                Label2.Visible = true;
                Label2.Text = "Herhangi bir dosya yok.";
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Dwn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string fName = row.Cells[1].Text;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fName);
            Response.TransmitFile(Server.MapPath("~/Docs/" + fName));
            Response.End();
        }
        if (e.CommandName == "Del")
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String id = row.Cells[0].Text.ToString();
                int id2 = Int32.Parse(id);
                //String url = row.Cells[2].Text.ToString();
                //            String ytFormattedUrl = GetYouTubeID(url);
                String aciklama = row.Cells[1].Text.ToString();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("Delete from dosyalar where id='" + id2 + "'", con);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                Response.Write("<script>alert('Dosya Veritabanından silinmiştir. !');</script>");
                Response.Redirect("~/bilgisayarprof/dosyalarim.aspx");
            }
        }
    }
}