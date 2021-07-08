using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

public partial class kayit2 : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    dbConnection veribase = new dbConnection("BAKANLIKDEMO");
    dbConnection veritabani = new dbConnection("ConnectionString");
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("BAKANLIKDEMO");

    DataSet DS = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("Select * From adres_il", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DA.Fill(DS, "ad");
            DropDownList1.DataSource = DS.Tables["ad"];
            DropDownList1.DataTextField = "ad";
            DropDownList1.DataValueField = "kod";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Seçiniz");
            DropDownList2.Items.Insert(0, "Seçiniz");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue != "Seçiniz")
        {
        String ilid = DropDownList1.SelectedValue;
        SqlConnection con = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand("select ad,kod from adres_ilce where il_kod =" + ilid, con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "ad";
        DropDownList2.DataValueField = "kod";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Seçiniz");
    }
    }

    static public string Sifrele(string veri)
    {
        // gelen veri byte dizisine aktarılıyor 
        byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
        // base64 şifreleme algoritmasına göre şifreleniyor.
        string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
        return sifrelenmisVeri;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ciftci.Checked)
        {
            String numara = TextBox1.Text.ToString();
            String kullaniciAdi = TextBox2.Text.Trim();
            String kullaniciSoyad = TextBox3.Text.Trim();
            String email = TextBox4.Text.Trim();
            String ceptel = TextBox5.Text.Trim();
            String evtel = TextBox6.Text.Trim();
            String adres = TextBox7.Text.Trim();
            String adresil = DropDownList1.SelectedValue;
            String adresilce = DropDownList2.SelectedValue;
            String sifre = TextBox8.Text.Trim();
            int sifreUzunlugu = sifre.Length;
            String sifretekrar = TextBox9.Text.Trim();

            DataRow girisBilgileri = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + email + "'");
            DataRow girisBilgileri2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + numara + "'");


            DataRow registerKodKontrol = veribase.GetDataRow("select kod from [BAKANLIKDEMO].[dbo].[ciftci] where kod= '" + numara + "'");

            
                if (registerKodKontrol != null)
                {
                    string kodKont = registerKodKontrol["kod"].ToString();
                    System.Diagnostics.Debug.WriteLine(kodKont);
                    if (girisBilgileri2 == null)
                    {
                    if (girisBilgileri == null)
                    {
                        if (sifreUzunlugu > 5)
                        {
                            if (sifre == sifretekrar)
                            {
                                sifre = Sifrele(sifre);
                                ver.CmdText = "Insert Into [ciftci] (kod,ad,soyad,cep_tel,ev_tel,adres,adres_il,adres_ilce) values ('" + numara + "','" + kullaniciAdi + "','" + kullaniciSoyad + "','" + ceptel + "','" + evtel + "','" + adres + "','" + adresil + "','" + adresilce + "')";
                                ver2.CmdText = "Insert Into [giris_bilgileri] (kod,email,sifre,kim,aktifpasif) values ('" + numara + "','" + email + "','" + sifre + "','0', '1')";
                                if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                                {
                                    if (MessageBox.Show("Kaydınız Başarılı Bir Şekilde Yapıldı.\n Şimdi Giriş Yapmak İstiyor Musunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                     //   Response.Write("<script>alert('Kullanıcı başarılı bir şekilde eklendi!'); </script>");
                                        TextBox1.Text = "";
                                        TextBox2.Text = "";
                                        TextBox3.Text = "";
                                        TextBox4.Text = "";
                                        TextBox5.Text = "";
                                        TextBox6.Text = "";
                                        TextBox7.Text = "";
                                        //                        DropDownList1.SelectedValue = "Seçiniz";
                                        //                        DropDownList2.SelectedValue = "Seçiniz";
                                        TextBox8.Text = "";
                                        TextBox9.Text = "";
                                        Response.Redirect("~/login.aspx");
                                    }
                                    else
                                    {

                                        Response.Redirect("~/Default.aspx");
                                    }
                                }
                                else
                                    Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Şifreler Uyuşmuyor!'); </script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Şifre Uzunluğu 6 karakterden küçük olmamalı!'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Daha önce bu e-mail adresi ile kayıt yapılmıştır. !'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Girdiğiniz çiftçi kodu ile daha önce kayıt yapılmıştır. Lütfen yeni bir kod giriniz. !'); </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Girdiğiniz ciftci kodu geçerli değildir.'); </script>");
            }
        }
        else if (toptanci.Checked)
        {
            string numara = TextBox1.Text.Trim();
            string kullaniciAdi = TextBox2.Text.Trim();
            string kullaniciSoyad = TextBox3.Text.Trim();
            string email = TextBox4.Text.Trim();
            var sRegex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            /*if (sRegex.IsMatch(email) == true)
            {
                System.Diagnostics.Debug.WriteLine("dogru");
            }*/
            string ceptel = TextBox5.Text.Trim();
            string istel = TextBox6.Text.Trim();
            string adres = TextBox7.Text.Trim();
            string adresil = DropDownList1.SelectedValue;
            string adresilce = DropDownList2.SelectedValue;
            string sifre = TextBox8.Text.Trim();
            int sifreUzunlugu = sifre.Length;
            string sifretekrar = TextBox9.Text.Trim();

            /*           Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
  
           md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(sifre);
            encodedBytes = md5.ComputeHash(originalBytes);
*/
            DataRow girisBilgileri2 = veritabani.GetDataRow("select * from giris_bilgileri where kod = '" + numara + "'");


            DataRow registerKodKontrol = veribase.GetDataRow("select kod from [BAKANLIKDEMO].[dbo].[toptanci] where kod= '" + numara + "'");
            DataRow girisBilgileri = veritabani.GetDataRow("select * from giris_bilgileri where email = '" + email + "'");
            if (registerKodKontrol != null)
            {
                string kodKont = registerKodKontrol["kod"].ToString();
                System.Diagnostics.Debug.WriteLine(kodKont);
                if (girisBilgileri2 == null)
                {
                    if (girisBilgileri == null)
                    {
                        if (sifreUzunlugu > 5)
                        {
                            if (sifre == sifretekrar)
                            {
                                sifre = Sifrele(sifre);
                                ver.CmdText = "Insert Into [toptanci] (kod,ad,soyad,cep_tel,is_tel,adres,adres_il,adres_ilce) values ('" + numara + "','" + kullaniciAdi + "','" + kullaniciSoyad + "','" + ceptel + "','" + istel + "','" + adres + "','" + adresil + "','" + adresilce + "')";
                                ver2.CmdText = "Insert Into [giris_bilgileri] (kod,email,sifre,kim,aktifpasif) values ('" + numara + "','" + email + "','" + sifre + "','1', '1')";
                                if (ver.NonQuery > 0 && ver2.NonQuery > 0)
                                {
                                  //  Response.Write("<script>alert('Kullanıcı başarılı bir şekilde eklendi!'); </script>");
                                    if (MessageBox.Show("Kaydınız Başarılı Bir Şekilde Yapıldı, Şimdi Giriş Yapmak İstiyor Musunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        TextBox1.Text = "";
                                        TextBox2.Text = "";
                                        TextBox3.Text = "";
                                        TextBox4.Text = "";
                                        TextBox5.Text = "";
                                        TextBox6.Text = "";
                                        TextBox7.Text = "";
                                        DropDownList1.SelectedValue = "Seçiniz";
                                        DropDownList2.SelectedValue = "Seçiniz";
                                        TextBox8.Text = "";
                                        TextBox9.Text = "";
                                        Response.Redirect("~/login.aspx");
                                    }
                                    else {

                                        Response.Redirect("~/Default.aspx");
                                    }
                                }
                                else
                                    Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                            }
                            else
                            {
                                Response.Write("<script>alert('Şifreler Uyuşmuyor!'); </script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Şifre Uzunluğu 6 karakterden küçük olmamalı!'); </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Daha önce bu e-mail adresi ile farklı bir toptancı kaydedilmiştir. !'); </script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Daha önce bu kod ile farklı bir toptancı kaydedilmiştir. !'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Girdiğiniz toptancı kodu geçerli değildir.'); </script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Çiftçi yada Toptancıdan birini seçmelisiniz!'); </script>");
        }
    }
}