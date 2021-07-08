using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

public partial class bilgisayarprof_profilim : System.Web.UI.Page
{
    dbConnection veritabani = new dbConnection("ConnectionString");
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veribase = new dbConnection("BAKANLIKDEMO");
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("BAKANLIKDEMO");
    DataSet DS = new DataSet();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci2 = veritabani.GetDataRow("select * from bilgisayar_prof where kod=" + adminid);
        if (adminid == 0 || drciftci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drciftci = veritabani.GetDataRow("select * from bilgisayar_prof where kod=" + adminid);
            if (!IsPostBack)
            {
                SqlConnection Conn = new SqlConnection(s);
                SqlCommand Cmd = new SqlCommand("Select * From adres_il", Conn);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "ad");
                DropDownListAdresIl.DataSource = DS.Tables["ad"];
                DropDownListAdresIl.DataTextField = "ad";
                DropDownListAdresIl.DataValueField = "kod";
                DropDownListAdresIl.DataBind();
                DropDownListAdresIl.Items.Insert(0, "Seçiniz");
                DropDownListIlce.Items.Insert(0, "Seçiniz");

                String kod2 = (String)Session["kod"];
                DataRow bilgisayarProfDB = veritabani.GetDataRow("select * from bilgisayar_prof where kod = '" + kod2 + "'");
                DataRow adresilDB = veritabani.GetDataRow("select * from adres_il where kod = '" + bilgisayarProfDB["adres_il"].ToString() + "'");

                DataRow adresilceDB = veritabani.GetDataRow("select * from adres_ilce where kod = '" + bilgisayarProfDB["adres_ilce"].ToString() + "'");
                System.Diagnostics.Debug.WriteLine(adresilceDB["ad"]);
                LabelAd.Text = bilgisayarProfDB["ad"].ToString();
                LabelSoyad.Text = bilgisayarProfDB["soyad"].ToString();
                TextBox1.Text = bilgisayarProfDB["adres"].ToString();
                LabelCepTel.Text = bilgisayarProfDB["cep_tel"].ToString();
                LabelAdresIl.Text = adresilDB["ad"].ToString();
                LabelAdresIlce.Text = adresilceDB["ad"].ToString();
                DataRow loginDB = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod2 + "'");
                LabelMail.Text = loginDB["email"].ToString();
                //        LabelSifre.Text = loginDB["sifre"].ToString();
            }
        }
    }

    protected void DropDownListAdresIl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListAdresIl.SelectedValue != "Seçiniz")
        {
            String ilid = DropDownListAdresIl.SelectedValue;
            SqlConnection con = new SqlConnection(s);
            SqlCommand cmd = new SqlCommand("select ad,kod from adres_ilce where il_kod =" + ilid, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DropDownListIlce.DataSource = ds;
            DropDownListIlce.DataTextField = "ad";
            DropDownListIlce.DataValueField = "kod";
            DropDownListIlce.DataBind();
            DropDownListIlce.Items.Insert(0, "Seçiniz");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button2.Visible = true;
        TextBoxAd.Visible = true;
        TextBoxEmail.Visible = true;
        TextBoxCepTel.Visible = true;
        TextBoxSoyad.Visible = true;
        TextBoxAdres.Visible = true;
        DropDownListAdresIl.Visible = true;
        DropDownListIlce.Visible = true;
        Button1.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        String kod2 = (String)Session["kod"];
        String adresilcekod, adresilkod, mailkontrol, textMail;
        int adresilkodu, adresilcekodu;
        DataRow bilgisayarProfDB = veritabani.GetDataRow("select * from bilgisayar_prof where kod = '" + kod2 + "'");
        DataRow adresilDB = veritabani.GetDataRow("select * from adres_il where kod = '" + bilgisayarProfDB["adres_il"].ToString() + "'");
        DataRow loginDB2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + kod2 + "'");
        DataRow adresilceDB = veritabani.GetDataRow("select * from adres_ilce where kod = '" + bilgisayarProfDB["adres_ilce"].ToString() + "'");
        mailkontrol = loginDB2["email"].ToString();
        
        String adresiladi = adresilDB["ad"].ToString();
        System.Diagnostics.Debug.WriteLine(adresiladi);
        System.Diagnostics.Debug.WriteLine(adresilceDB["ad"]);
        String yoneticiAdi = TextBoxAd.Text;
        String yoneticiSoyadi = TextBoxSoyad.Text;
        String yoneticiMail = TextBoxEmail.Text;
        if (DropDownListAdresIl.SelectedValue != "Seçiniz" && DropDownListIlce.SelectedValue == "Seçiniz")
        {
            Response.Write("<script>alert('İlçeyi boş bırakamazsınız! ');</script>");
        }
        else if (DropDownListAdresIl.SelectedValue == "Seçiniz" && DropDownListIlce.SelectedValue != "Seçiniz")
        {
            Response.Write("<script>alert('İli boş bırakamazsınız! ');</script>");
        }
        else
        {
            String kod3 = (String)Session["kod"];
            if (TextBoxAd.Text == "")
            {
                TextBoxAd.Text = LabelAd.Text;
            }
            if (TextBoxSoyad.Text == "")
            {
                TextBoxSoyad.Text = LabelSoyad.Text;
            }
            if (TextBoxCepTel.Text == "")
            {
                TextBoxCepTel.Text = LabelCepTel.Text;
            }
            if (TextBoxAdres.Text == "")
            {
                TextBoxAdres.Text = TextBox1.Text;
            }
            if (DropDownListAdresIl.SelectedValue == "Seçiniz")
            {
                //adresilkod = adresiladi;
                DataRow adresiliDB = veritabani.GetDataRow("select * from adres_il where ad = '" + adresiladi + "'");
                adresilkod = adresiliDB["kod"].ToString();
                adresilkodu = Convert.ToInt32(adresilkod);

            }
            else
            {
                adresilkod = DropDownListAdresIl.SelectedValue;
                adresilkodu = Convert.ToInt32(adresilkod);
            }
            if (DropDownListIlce.SelectedValue == "Seçiniz")
            {
                adresilcekod = adresilceDB["ad"].ToString();
                DataRow adresilcesiDB = veritabani.GetDataRow("select * from adres_ilce where ad = '" + adresilcekod + "'");
                adresilcekod = adresilcesiDB["kod"].ToString();
                adresilcekodu = Convert.ToInt32(adresilcekod);
            }
            else
            {
                adresilcekod = DropDownListIlce.SelectedValue;

                adresilcekodu = Convert.ToInt32(adresilcekod);
            }

            if (TextBoxEmail.Text == "")
            {
                TextBoxEmail.Text = LabelMail.Text;
                textMail = LabelMail.Text;
                System.Diagnostics.Debug.WriteLine(textMail);

                DataRow emailKontrol = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + yoneticiMail + "'");
                if (emailKontrol == null && textMail == mailkontrol)
                {
                    DataRow bilgisayarProf = veritabani.GetDataRow("UPDATE  bilgisayar_prof SET ad='" + TextBoxAd.Text + "', soyad='" + TextBoxSoyad.Text + "', cep_tel='" + TextBoxCepTel.Text + "', adres='" + TextBoxAdres.Text + "', adres_il='" + adresilkodu + "', adres_ilce='" + adresilcekodu + "' where kod = '" + kod3 + "'");
                    DataRow loginDB = veritabani.GetDataRow("UPDATE  giris_bilgileri SET email='" + TextBoxEmail.Text + "' where kod = '" + kod3 + "'");
                    Response.Write("<script>alert('Profil bilgileriniz başarıyla değiştirildi. ');</script>");
                    Response.Redirect("~/bilgisayarprof/profilim.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Sisteme Daha önce bu mail adresi ile kayıt yapılmıştır. Lütfen mail adresini tekrar giriniz. ');</script>");
                }
            }
            else
            {
                
                textMail = TextBoxEmail.Text;

                DataRow emailKontrol = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + yoneticiMail + "'");
                if (emailKontrol != null && textMail == mailkontrol)
                {
                    DataRow bilgisayarProf = veritabani.GetDataRow("UPDATE  bilgisayar_prof SET ad='" + TextBoxAd.Text + "', soyad='" + TextBoxSoyad.Text + "', cep_tel='" + TextBoxCepTel.Text + "', adres='" + TextBoxAdres.Text + "', adres_il='" + adresilkodu + "', adres_ilce='" + adresilcekodu + "' where kod = '" + kod3 + "'");
                    DataRow loginDB = veritabani.GetDataRow("UPDATE  giris_bilgileri SET email='" + TextBoxEmail.Text + "' where kod = '" + kod3 + "'");
                    Response.Write("<script>alert('Profil bilgileriniz başarıyla değiştirildi. ');</script>");
                    Response.Redirect("~/bilgisayarprof/profilim.aspx");
                }

                else
                {
                    Response.Write("<script>alert('Sisteme Daha önce bu mail adresi ile kayıt yapılmıştır. Lütfen mail adresini tekrar giriniz. ');</script>");
                }
            }
        }
    }
}