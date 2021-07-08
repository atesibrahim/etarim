using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class yonetici_kisi_istatistigi : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("etarim");

    DataSet DS = new DataSet();
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string kisi = DropDownList1.Text.Trim();

        if (kisi == "0") {
            DataRow ciftciaktif = veritabani.GetDataRow("select count(id) as ciftci_aktif from giris_bilgileri where kim=0 and aktifpasif=1");
            string ciftci_aktif = ciftciaktif["ciftci_aktif"].ToString();
            if (ciftci_aktif == "")
            {
                ciftci_aktif = "0";
            }
            int ciftci_ak = Convert.ToInt32(ciftci_aktif);

            DataRow ciftcipasif = veritabani.GetDataRow("select count(id) as ciftci_pasif from giris_bilgileri where kim=0 and aktifpasif=0");
            string cifci_pasif = ciftcipasif["ciftci_pasif"].ToString();
            if (cifci_pasif == "")
            {
                cifci_pasif = "0";
            }
            int ciftci_pas = Convert.ToInt32(cifci_pasif);
            
            TextBox1.Text = ciftci_ak.ToString();
            TextBox2.Text = ciftci_pas.ToString();

        }
        else if (kisi == "1")
        {
            DataRow toptanciaktif = veritabani.GetDataRow("select count(id) as toptanci_aktif from giris_bilgileri where kim=1 and aktifpasif=1");
            string toptanci_aktif =toptanciaktif["toptanci_aktif"].ToString();
            if (toptanci_aktif == "")
            {
                toptanci_aktif = "0";
            }
            int toptanci_ak = Convert.ToInt32(toptanci_aktif);

            DataRow toptancipasif = veritabani.GetDataRow("select count(id) as toptanci_pasif from giris_bilgileri where kim=1 and aktifpasif=0");
            string toptanci_pasif = toptancipasif["toptanci_pasif"].ToString();
            if (toptanci_pasif == "")
            {
                toptanci_pasif = "0";
            }
            int toptanci_pas = Convert.ToInt32(toptanci_pasif);

            TextBox1.Text = toptanci_ak.ToString();
            TextBox2.Text = toptanci_pas.ToString();
        }
        else {
            DataRow kisiaktif = veritabani.GetDataRow("select count(id) as kisi_aktif from giris_bilgileri where (kim=0 or kim=1) and  aktifpasif=1");
            string kisi_aktif = kisiaktif["kisi_aktif"].ToString();
            if (kisi_aktif == "")
            {
                kisi_aktif = "0";
            }
            int kisi_ak = Convert.ToInt32(kisi_aktif);

            DataRow kisipasif = veritabani.GetDataRow("select count(id) as kisi_pasif from giris_bilgileri where (kim=0 or kim=1) and aktifpasif=0");
            string kisi_pasif = kisipasif["kisi_pasif"].ToString();
            if (kisi_pasif == "")
            {
                kisi_pasif = "0";
            }
            int kisi_pas = Convert.ToInt32(kisi_pasif);

            TextBox1.Text = kisi_ak.ToString();
            TextBox2.Text = kisi_pas.ToString();
        }
    }
}