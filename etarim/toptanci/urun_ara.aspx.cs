using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class toptanci_urun_ara : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    Veri ver3 = new Veri("etarim");

    DataSet DS = new DataSet();
    dbConnection veritabani = new dbConnection("ConnectionString");
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drtoptanci2 = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);

        if (adminid == 0 || drtoptanci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drtoptanci = veritabani.GetDataRow("select * from toptanci where kod=" + adminid);
            GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            Label10.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Button3.Visible = false;
            Button2.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Button4.Visible = false;
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
            if (!IsPostBack)
            {
                SqlConnection Conn = new SqlConnection(s);
                SqlCommand Cmd = new SqlCommand("Select * From adres_il", Conn);
                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                DA.Fill(DS, "ad");
                DropDownList3.DataSource = DS.Tables["ad"];
                DropDownList3.DataTextField = "ad";
                DropDownList3.DataValueField = "kod";
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, "Seçiniz");

            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
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
        BindData();
        if (GridView1.Rows.Count == 0) {
            Label10.Visible = true;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label8.Visible = false;
            Button2.Visible = false;
            TextBox1.Visible = false;
            Button3.Visible = false;
            Label11.Visible = false;
            Label12.Visible = false;
            Button4.Visible = false;

        }
    }
    private void BindData()
    {
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        Button3.Visible = false;
        Button2.Visible = false;
        Label11.Visible = false;
        Label12.Visible = false;
        Button4.Visible = false;


        String ad = DropDownList1.SelectedValue; //tur
        String soyad = DropDownList2.SelectedValue; // isim
        String adresil = DropDownList3.SelectedValue; // adres il
        if (ad == "Seçiniz" && soyad == "Seçiniz" && adresil == "Seçiniz")
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "ciftci_urun");
            Conn.Open();
            Cmd.ExecuteNonQuery();

            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();
        }
        else if (ad != "Seçiniz" && soyad != "Seçiniz" && adresil != "Seçiniz")
        {



            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " and ciftci_urun.urun_kod=" + soyad + " and adres_il.kod=" + adresil + "", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci_urun");
            Conn.Open();
            Cmd.ExecuteNonQuery();

            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();


        }
        else
            if (ad != "Seçiniz")
            {
                if (soyad != "Seçiniz")
                {
                    //  Response.Write("<script>alert(' ada ve soyada göre ara!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " and ciftci_urun.urun_kod=" + soyad + " ", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();



                }
                else if (adresil != "Seçiniz")
                {
                    //  Response.Write("<script>alert('ada ve ile göre!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " and  adres_il.kod=" + adresil + "", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();


                }
                else
                {
                    // Response.Write("<script>alert('ada  göre ara!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " ", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();



                }

            }
            else
                if (soyad != "Seçiniz")
                {
                    if (ad != "Seçiniz")
                    {
                        //Response.Write("<script>alert('soyad ve ada göre ara!'); </script>");

                        SqlConnection Conn = new SqlConnection(s);
                        SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " and ciftci_urun.urun_kod=" + soyad + " ", Conn);
                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DataSet DS = new DataSet();
                        DA.Fill(DS, "toptanci_urun");
                        Conn.Open();
                        Cmd.ExecuteNonQuery();

                        GridView1.DataSource = DS;
                        GridView1.DataBind();
                        Conn.Close();


                    }
                    else
                        if (adresil != "Seçiniz")
                        {
                            //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where  ciftci_urun.urun_kod=" + soyad + " and adres_il.kod=" + adresil + "", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();


                        }
                        else
                        {
                            //Response.Write("<script>alert('soyad  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where  ciftci_urun.urun_kod=" + soyad + "", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();


                        }

                }
                else
                    if (adresil != "Seçiniz")
                    {
                        if (ad != "Seçiniz")
                        {
                            //Response.Write("<script>alert('ile ve ada göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where ciftci_urun.tur_kod=" + ad + " and adres_il.kod=" + adresil + "", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();


                        }
                        else
                            if (soyad != "Seçiniz")
                            {
                                //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where  ciftci_urun.urun_kod=" + soyad + " and adres_il.kod=" + adresil + "", Conn);
                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci_urun");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();

                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();


                            }
                            else
                            {
                                //Response.Write("<script>alert('ile göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, ciftci.kod as ciftci, ciftci_urun_fiyat.fiyat From ciftci INNER JOIN ciftci_urun on ciftci_urun.ciftci_kod= ciftci.kod INNER JOIN adres_il on ciftci.adres_il=adres_il.kod INNER JOIN urun_isimleri on ciftci_urun.urun_kod= urun_isimleri.kod and ciftci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  ciftci_urun.tur_kod=urun_turleri.kod INNER JOIN ciftci_urun_fiyat on ciftci_urun_fiyat.urun_kod=ciftci_urun.urun_kod and ciftci_urun_fiyat.tur_kod=ciftci_urun.tur_kod and ciftci_urun_fiyat.ciftci_kod=ciftci.kod where  adres_il.kod=" + adresil + "", Conn);
                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci_urun");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();

                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();


                            }


                    }
    }

    protected void sec(object sender, ImageClickEventArgs e)
    {

        
        Button2.Visible = true;
        SqlConnection Conn = new SqlConnection(s);
        // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
          String kod = (String)Session["kod"];
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        System.Web.UI.WebControls.Label ciftci = (System.Web.UI.WebControls.Label)row.FindControl("ciftci");
        int ciftci_id = Int32.Parse(ciftci.Text);

        DataRow ciftciDB = veritabani.GetDataRow("select * from ciftci where kod = '" + ciftci_id + "'");
        DataRow adresilDB = veritabani.GetDataRow("select * from adres_il where kod = '" + ciftciDB["adres_il"].ToString() + "'");
        DataRow emailDB = veritabani.GetDataRow("select email from giris_bilgileri where kod = '" + ciftci_id + "'");
        DataRow adresilceDB = veritabani.GetDataRow("select * from adres_ilce where kod = '" + ciftciDB["adres_ilce"].ToString() + "'");
        Label1.Visible = true;
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        Label8.Visible = true;
        Button2.Visible = true;
        Button4.Visible = true;

        Label1.Text = "Ad      : " + ciftciDB["ad"].ToString() + " ";
        Label2.Text = "Soyadı  :" + ciftciDB["soyad"].ToString() + "";
        Label3.Text = "Cep Tel.:" + ciftciDB["cep_tel"].ToString() + "";
        Label4.Text = "Ev Tel. :" + ciftciDB["ev_tel"].ToString() + "";
        Label8.Text =  emailDB["email"].ToString();
        Label5.Text = "Adres   :" + ciftciDB["adres"].ToString() + " " + adresilceDB["ad"].ToString() + "/" + adresilDB["ad"].ToString() + "";
        Label6.Text = "Ürünü Satan Çiftçinin";

        DataRow cift = veritabani.GetDataRow("select id from ciftci_toptanci where t_edilen='" + ciftci_id + "' and t_eden='"+kod +"' ");

        Button4.Enabled = true;
        if (cift != null)
        {
            Button4.Enabled = false;
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {// sayfalar arası geçiş yapmak için pageindex changing eventı altına kodları yazıoruz.
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = DS;
        //  GridView1.DataBind();
        BindData();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        Button3.Visible = true;
        Label11.Visible = true;
        Label12.Visible = true;
        Button4.Visible = true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        // Response.Write("<script>alert('yönetici!'); </script>");

        String kimin = Label8.Text.ToString();
        String konusu = TextBox2.Text.ToString();
        String mesaji = TextBox1.Text.ToString();
        String kod = Session["kod"].ToString();
        String zaman = DateTime.Now.ToString();
       
        if (konusu == "" && mesaji == "")
        {
            Response.Write("<script>alert('Mesaj Konsu ve Mesaj Boş Bırakılamaz!'); </script>");
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            Button2.Visible = false;
            Button3.Visible = true;
            Button4.Visible = true;

        }else{
            if (konusu == "")
            {
                konusu = "KONU YOK";
            }

            DataRow gon = veritabani.GetDataRow("select email from giris_bilgileri where kod='" + kod + "' ");
            String kimden = gon["email"].ToString();



            ver.CmdText = "Insert Into [mesajlar] (kimden,kime,tarih,okundu,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "',0,'" + konusu + "','" + mesaji + "')";
            ver2.CmdText = "Insert Into [mesaj_gonderilen] (kimden,kime,tarih,konu,mesaj) values ('" + kimden + "','" + kimin + "','" + zaman + "','" + konusu + "','" + mesaji + "')";

            if (ver.NonQuery > 0 && ver2.NonQuery > 0)
            {
                 Response.Write("<script>alert('MESAJ GÖNDERİLDİ!'); </script>");
                TextBox1.Visible = false;
                TextBox2.Visible = false;

                TextBox1.Text = "";
                TextBox2.Text = "";
                Button3.Visible = false;
                Button2.Visible = true;
                Label11.Visible = false;
                Label12.Visible = false;
                Button4.Visible = true;
                Button2.Visible = true;

            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String mail = Label8.Text.ToString();
        DataRow ciftci = veritabani.GetDataRow("select kod from giris_bilgileri where email='" + mail + "' ");
        String kimden = ciftci["kod"].ToString();
        String kod = Session["kod"].ToString();
       

            DataRow ekle = veritabani.GetDataRow("insert into  ciftci_toptanci (t_eden, t_edilen) values ('" + kod + "' ,'" + kimden + "')");

              Response.Write("<script>alert('çiftçilerim listesine eklendi!'); </script>");
              Button4.Visible = true;
              Button2.Visible = true;
              Button4.Enabled = false;


    }
}