using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

public partial class yonetici_urun_istatistigi : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("etarim");

    DataSet DS = new DataSet();
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("Select * From urun_turleri", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DA.Fill(DS, "urun_turleri");
            DropDownList1.DataSource = DS.Tables["urun_turleri"];
            DropDownList1.DataTextField = "tur_ad";
            DropDownList1.DataValueField = "kod";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Seçiniz");
            DropDownList2.Items.Insert(0, "Seçiniz");
        }
    }
   
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "Seçiniz")
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd1 = new SqlCommand("Select * From urun_isimleri Where tur_kod=" + DropDownList1.SelectedValue + "", Conn);
            SqlDataAdapter DA1 = new SqlDataAdapter(Cmd1);
            DA1.Fill(DS, "urun_isimleri");
            DropDownList2.DataSource = DS.Tables["urun_isimleri"];
            DropDownList2.DataTextField = "ad";
            DropDownList2.DataValueField = "kod";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Seçiniz");
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        string tur = DropDownList1.Text.Trim();
        string isim = DropDownList2.Text.Trim();

        if (tur != "Seçiniz" && isim != "Seçiniz")
        {
            DataRow ciftciDB = veritabani.GetDataRow("select sum(miktar) as mik from ciftci_urun where tur_kod='" + tur + "' and urun_kod='"+isim+"'");
            string tur_miktar = ciftciDB["mik"].ToString();
            if (tur_miktar == "") {
                tur_miktar = "0";
            }
            int ciftci_miktar= Convert.ToInt32(tur_miktar);

            DataRow toptanciDB = veritabani.GetDataRow("select sum(miktar) as mik from toptanci_urun where tur_kod='" + tur + "' and urun_kod='" + isim + "'");
            string tur_miktar2 = toptanciDB["mik"].ToString();
            if (tur_miktar2 == "") {
                tur_miktar2 = "0";
            }
            int toptanci_miktar = Convert.ToInt32(tur_miktar2);

           
            TextBox1.Text = ciftci_miktar.ToString();
            TextBox2.Text = toptanci_miktar.ToString();
            
            
        }
        else if (tur != "Seçiniz") {


            DataRow ciftciDB = veritabani.GetDataRow("select sum(miktar) as mik from ciftci_urun where tur_kod='" + tur + "' ");
            string tur_miktar = ciftciDB["mik"].ToString();
            if (tur_miktar == "") {
                tur_miktar = "0";
            }
            int ciftci_miktar = Convert.ToInt32(tur_miktar);

            DataRow toptanciDB = veritabani.GetDataRow("select sum(miktar) as mik from toptanci_urun where tur_kod='" + tur + "' ");
            string tur_miktar2 = toptanciDB["mik"].ToString();
            if (tur_miktar2 == "") {
                tur_miktar2 = "0";
            }
            int toptanci_miktar = Convert.ToInt32(tur_miktar2);

            TextBox1.Text = ciftci_miktar.ToString();
            TextBox2.Text = toptanci_miktar.ToString();
        }
    }


   

}