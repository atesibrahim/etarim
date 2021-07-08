using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ciftci_Default : System.Web.UI.Page
{
    dbConnection ver = new dbConnection("ConnectionString");
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

        }
    }
    protected void sistemvideolari_Click(object sender, EventArgs e)
    {

            Response.Redirect("~/videolar.aspx");


    }
    protected void mevzuatlar_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/mevzuatlar.aspx");


    }
}