using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;
using System.Data;

public partial class bilgisayarprof_videolarim : System.Web.UI.Page
{
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
            if (GridView1.Rows.Count == 0)
            {
                Label2.Text = "Kayıtlı video bulunamadı.";
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Del")
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                String id = row.Cells[0].Text.ToString();
                int id2 = Int32.Parse(id);
                String url = row.Cells[2].Text.ToString();
                //            String ytFormattedUrl = GetYouTubeID(url);
                String aciklama = row.Cells[1].Text.ToString();
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("Delete from videolar where id='" + id2 + "'", con);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();



                Response.Write("<script>alert('Video Veritabanından silinmiştir. !');</script>");
                Response.Redirect("~/bilgisayarprof/videolarim.aspx");
            }
        }
/*        if (CheckBox1.Checked)
        {
            if (MessageBox.Show("Hepsini silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand("Delete from videolar", con);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        
        
        }*/
    }

    private string GetYouTubeID(string youTubeUrl)
    {
        //RegEx to Find YouTube ID
        Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                           RegexOptions.IgnoreCase);
        if (regexMatch.Success)
        {
            return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value +
                   "&hl=en&fs=1";
        }
        return youTubeUrl;
    }
}