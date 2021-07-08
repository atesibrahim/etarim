using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;

public partial class bilgisayarprof_videoekle : System.Web.UI.Page
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

        }
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
    protected void btnAddLink_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

        
        string url = TextBox1.Text;
        String aciklama = TextBox2.Text;
        String urlKontrol = TextBox1.Text.ToString();
        string ytFormattedUrl = GetYouTubeID(url);
        DataRow videoKontrol = veritabani.GetDataRow("select * from videolar where url='" + ytFormattedUrl + "'");
       
        if (url != "" && url.Contains("youtube.com"))
        {

            if (videoKontrol == null)
            {
                SqlCommand cmd = new SqlCommand("Insert into videolar(url, aciklama)  values ('" + ytFormattedUrl + "', '" + aciklama + "')", con);
                using (con)
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != -1)
                    {
                        DataBind();
                    }
                    else { Response.Write("Video eklenirken hata oluştu!"); }
                }

                Response.Write("<script>alert('Video başarılı bir şekilde yüklendi.'); </script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else { Response.Write("<script>alert('Bu video daha önceden veritabanına eklenmiştir. !'); </script>"); }
        }
        else
        {
            Response.Write("<script>alert('Eklediğiniz videonun adresi geçersizdir. Lütfen doğru video adresi girdiğinizden emin olunuz. !'); </script>");
        }

 
    }
    public bool CheckDuplicate(string youTubeUrl)
    {
        bool exists = false;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand(String.Format("select * from videolar where url='{0}'", youTubeUrl), con);
        using (con)
        {
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            exists = (dr.HasRows) ? true : false;
        }
            return false;
        
    }
    protected void btnDosyaEkle_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            String name = Path.GetFileName(FileUpload1.PostedFile.FileName);
            String location = Server.MapPath("~/Docs/" + name);
            String aciklama = TextBox3.Text;
            FileUpload1.SaveAs(location);

            //Create SQL Connection and Command to Save File name in DataBase

            String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(connectionString);
            String strInsert = "INSERT INTO dosyalar(dosyaadresi, aciklama) VALUES('" + name + "','" + aciklama + "')";
            SqlCommand command = new SqlCommand(strInsert, sqlCon);
            command.Parameters.AddWithValue("@dosyaadresi", name);
            sqlCon.Open();
            int result = command.ExecuteNonQuery();
            sqlCon.Close();

            if (result > 0)
                Response.Write("<script>alert('Dosya başarılı bir şekilde yüklendi.'); </script>");
        }
        DataBind();
    }
}