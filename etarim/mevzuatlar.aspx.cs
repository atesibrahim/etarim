using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class mevzuatlar : System.Web.UI.Page
{

    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        DataRow dosyalar = veritabani.GetDataRow("select * from dosyalar");
        if (dosyalar == null)
        {
            Label2.Visible = true;
            Label2.Text = "Herhangi bir dosya yok.";
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dwn")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            string fName = row.Cells[2].Text;
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fName);
            Response.TransmitFile(Server.MapPath("~/Docs/" + fName));
            Response.End();
        }
    }
}