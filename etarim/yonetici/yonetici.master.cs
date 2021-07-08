using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class yonetici_yonetici : System.Web.UI.MasterPage
{
    dbConnection ver = new dbConnection("ConnectionString");
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
            /* lblAdminName.Text = drciftci["ad"].ToString();*/

        }
    }
    protected void cikis_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {

            Session.Clear();
            Response.Redirect("~/");
        }

        

    }
}
