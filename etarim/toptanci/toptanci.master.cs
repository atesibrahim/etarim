using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

public partial class toptanci_toptanci : System.Web.UI.MasterPage
{
    dbConnection ver = new dbConnection("ConnectionString");
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

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {

            Session.Clear();
            Response.Redirect("~/");
        }
    }
}
