using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ciftci_urun_ara : System.Web.UI.Page
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
        DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci = veritabani.GetDataRow("select * from ciftci where kod=" + adminid);

        if (adminid == 0 || drciftci == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            Label13.Visible = false;
            Label14.Visible = false;

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
        Button2.Visible = false;
        Button3.Visible = false;
        Button4.Visible = false;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        Label13.Visible = false;
        Label14.Visible = false;
        yukle();
    }
        public void yukle(){
        String ad = DropDownList1.SelectedValue; //tur
        String soyad = DropDownList2.SelectedValue; // isim
        String adresil = DropDownList3.SelectedValue; // adres il
        if (ad == "Seçiniz" && soyad == "Seçiniz" && adresil == "Seçiniz")
        {
            Label12.Visible = false;
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod ", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci_urun");
            Conn.Open();
            Cmd.ExecuteNonQuery();

            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();
            if (GridView1.Rows.Count == 0)
            {
                Label12.Visible = true;
                Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
            }
        }
        else if (ad != "Seçiniz" && soyad != "Seçiniz" && adresil != "Seçiniz")
        {

            Label12.Visible = false;

            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod  where (toptanci_urun.urun_kod='" + soyad + "') and (toptanci_urun.tur_kod='" + ad + "'  ) and (toptanci.adres_il='" + adresil + "')", Conn);
            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci_urun");
            Conn.Open();
            Cmd.ExecuteNonQuery();

            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();
            if (GridView1.Rows.Count == 0) {
                Label12.Visible = true;
                Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
            }


        }
        else
            if (ad != "Seçiniz")
            {
                if (soyad != "Seçiniz")
                {
                    //  Response.Write("<script>alert(' ada ve soyada göre ara!'); </script>");
                    Label12.Visible = false;
                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.urun_kod='" + soyad + "') and (toptanci_urun.tur_kod='" + ad + "'  ) ", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();

                    if (GridView1.Rows.Count == 0)
                    {
                        Label12.Visible = true;
                        Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                    }

                }
                else if (adresil != "Seçiniz")
                {
                    //  Response.Write("<script>alert('ada ve ile göre!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where  (toptanci_urun.tur_kod='" + ad + "'  ) and (toptanci.adres_il='" + adresil + "')", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();
                    Label12.Visible = false;
                    if (GridView1.Rows.Count == 0)
                    {
                        Label12.Visible = true;
                        Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                    }

                }
                else
                {
                    // Response.Write("<script>alert('ada  göre ara!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where  (toptanci_urun.tur_kod='" + ad + "'  ) ", Conn);
                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci_urun");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();

                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();

                    Label12.Visible = false;
                    if (GridView1.Rows.Count == 0)
                    {
                        Label12.Visible = true;
                        Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                    }

                }

            }
            else
                if (soyad != "Seçiniz")
                {
                    if (ad != "Seçiniz")
                    {
                        //Response.Write("<script>alert('soyad ve ada göre ara!'); </script>");

                        SqlConnection Conn = new SqlConnection(s);
                        SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.urun_kod='" + soyad + "') and (toptanci_urun.tur_kod='" + ad + "'  ) ", Conn);
                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DataSet DS = new DataSet();
                        DA.Fill(DS, "toptanci_urun");
                        Conn.Open();
                        Cmd.ExecuteNonQuery();

                        GridView1.DataSource = DS;
                        GridView1.DataBind();
                        Conn.Close();
                        Label12.Visible = false;
                        if (GridView1.Rows.Count == 0)
                        {
                            Label12.Visible = true;
                            Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                        }

                    }
                    else
                        if (adresil != "Seçiniz")
                        {
                            //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.urun_kod='" + soyad + "')  and (toptanci.adres_il='" + adresil + "')", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();
                            Label12.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label12.Visible = true;
                                Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                            }

                        }
                        else
                        {
                            //Response.Write("<script>alert('soyad  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.urun_kod='" + soyad + "') ", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();
                            Label12.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label12.Visible = true;
                                Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                            }

                        }

                }
                else
                    if (adresil != "Seçiniz")
                    {
                        if (ad != "Seçiniz")
                        {
                            //Response.Write("<script>alert('ile ve ada göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.tur_kod='" + ad + "'  ) and (toptanci.adres_il='" + adresil + "')", Conn);
                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci_urun");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();

                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();
                            Label12.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label12.Visible = true;
                                Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                            }

                        }
                        else
                            if (soyad != "Seçiniz")
                            {
                                //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where (toptanci_urun.urun_kod='" + soyad + "')  and (toptanci.adres_il='" + adresil + "')", Conn);
                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci_urun");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();

                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();
                                Label12.Visible = false;
                                if (GridView1.Rows.Count == 0)
                                {
                                    Label12.Visible = true;
                                    Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                                }

                            }
                            else
                            {
                                //Response.Write("<script>alert('ile göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT miktar , tur_ad , urun_isimleri.ad as isim, adres_il.ad as il, toptanci.kod as toptanci from toptanci INNER JOIN toptanci_urun on toptanci_urun.toptanci_kod= toptanci.kod INNER JOIN adres_il on toptanci.adres_il=adres_il.kod INNER JOIN urun_isimleri on toptanci_urun.urun_kod= urun_isimleri.kod and toptanci_urun.tur_kod= urun_isimleri.tur_kod INNER JOIN urun_turleri on  toptanci_urun.tur_kod=urun_turleri.kod where  (toptanci.adres_il='" + adresil + "')", Conn);
                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci_urun");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();

                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();
                                Label12.Visible = false;
                                if (GridView1.Rows.Count == 0)
                                {
                                    Label12.Visible = true;
                                    Label12.Text = "Aradığınız Kritere Uygun Ürün Bulunmamaktadır!";
                                }

                            }


                    }
    }

    protected void sec(object sender, ImageClickEventArgs e)
    {
        Button2.Visible = true;
        Button3.Visible = true;
        
        
        SqlConnection Conn = new SqlConnection(s);
        // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
        String kod = (String)Session["kod"];
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        System.Web.UI.WebControls.Label top = (System.Web.UI.WebControls.Label)row.FindControl("top");
        int top_id = Int32.Parse(top.Text);
    //    GridView1.Rows[].BackColor = System.Drawing.Color.Bisque;
        DataRow ciftciDB = veritabani.GetDataRow("select * from toptanci where kod = '" + top_id + "'");
        DataRow adresilDB = veritabani.GetDataRow("select * from adres_il where kod = '" + ciftciDB["adres_il"].ToString() + "'");
        DataRow ciftcimail = veritabani.GetDataRow("select email from giris_bilgileri  where kod = '" + top_id + "'");
        DataRow adresilceDB = veritabani.GetDataRow("select * from adres_ilce where kod = '" + ciftciDB["adres_ilce"].ToString() + "'");

        Label1.Text = "Ad      : " + ciftciDB["ad"].ToString() + " ";
        Label2.Text = "Soyadı  :" + ciftciDB["soyad"].ToString() + "";
        Label3.Text = "Cep Tel.:" + ciftciDB["cep_tel"].ToString() + "";
        Label4.Text = "İş Tel. :" + ciftciDB["is_tel"].ToString() + "";
        Label11.Text =  ciftcimail["email"].ToString();
        Label5.Text = "Adres   :" + ciftciDB["adres"].ToString() + " " + adresilceDB["ad"].ToString() + "/" + adresilDB["ad"].ToString() + "";
        Label6.Text = "Ürününe İhtiyaç Duyan Toptancının";

        DataRow toptanci= veritabani.GetDataRow("select id from ciftci_toptanci where t_edilen='" + top_id + "' and t_eden='" + kod + "' ");

        Button4.Enabled = true;
        if (toptanci != null)
        {
            Button3.Enabled = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
        Button3.Visible = true;
        Button4.Visible = true;
        TextBox1.Visible = true;
        TextBox2.Visible = true;
        Label13.Visible = true;
        Label14.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        String kimin = Label11.Text.ToString();
        String konusu = TextBox1.Text.ToString();
        String mesaji = TextBox2.Text.ToString();
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

        }
        else
        {
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
                Button3.Visible = true;
                Button2.Visible = true;
                Label13.Visible = false;
                Label14.Visible = false;
                Button4.Visible = false;
                Button2.Visible = true;

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                Response.Write("<script>alert('Mesaj Gönderilirken Bir Hata Oluştu! TEKRAR DENEYİN!'); </script>");
            }


        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        String mail = Label11.Text.ToString();
        DataRow toptanci = veritabani.GetDataRow("select kod from giris_bilgileri where email='" + mail + "' ");
        String kimden = toptanci["kod"].ToString();
        String kod = Session["kod"].ToString();


        DataRow ekle = veritabani.GetDataRow("insert into  ciftci_toptanci (t_eden, t_edilen) values ('" + kod + "' ,'" + kimden + "')");

        Response.Write("<script>alert('Toptancılarım listesine eklendi!'); </script>");
        Button3.Visible = true;
        Button2.Visible = true;
        Button3.Enabled = false;
    }
}
