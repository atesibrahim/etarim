using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ciftci_toptanci_ara : System.Web.UI.Page
{
    string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    Veri ver = new Veri("etarim");
    Veri ver2 = new Veri("etarim");
    dbConnection veritabani = new dbConnection("ConnectionString");

    DataSet DS = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        int adminid = Convert.ToInt32(Session["kod"]);
        DataRow drAdmin2 = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
        DataRow drciftci2 = veritabani.GetDataRow("select * from ciftci where kod=" + adminid);

        if (adminid == 0 || drciftci2 == null)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
        else
        {
            DataRow drAdmin = veritabani.GetDataRow("select * from giris_bilgileri where kod=" + adminid);
            DataRow drciftci = veritabani.GetDataRow("select * from ciftci where kod=" + adminid);
            Label8.Visible = false;
            BindData();
            yukle();
        }
    }
    public void BindData()
    {
        GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
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

        }
    }
    public void yukle() {
        foreach (GridViewRow dg in GridView1.Rows)
        {
            // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
            String kod = (String)Session["kod"];
            Label ciftcikod = (Label)GridView1.Rows[dg.RowIndex].FindControl("kodu");
            String cift = Convert.ToString(ciftcikod.Text);
            //System.Diagnostics.Debug.WriteLine(takip);
            DataRow kont = veritabani.GetDataRow("select * from ciftci_toptanci where t_eden = '" + kod + "' and t_edilen='" + cift + "'");
            System.Web.UI.WebControls.ImageButton delete = (System.Web.UI.WebControls.ImageButton)GridView1.Rows[dg.RowIndex].FindControl("ekle");


            if (kont != null)
            {
                delete.ImageUrl = "~/image/sub.ico";
            }
            else
            {


                delete.ImageUrl = "~/image/plus.ico";
            }

        }
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        arama();
        if (GridView1.Rows.Count == 0)
        {
            Label8.Visible = true;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            GridView2.Visible = false;

        }
        yukle();
    }
        public void arama(){
        string ad = TextBox1.Text.Trim();
        string soyad = TextBox2.Text.Trim();
        string adresil = DropDownList1.SelectedValue;
        if (ad == "" && soyad == "" && adresil == "Seçiniz")
        {
            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod", Conn);

            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci");
            Conn.Open();
            Cmd.ExecuteNonQuery();
            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();
            Label8.Visible = false;
            if (GridView1.Rows.Count == 0) {
                Label8.Visible = true;

            }
        }
        else if (ad != "" && soyad != "" && adresil != "Seçiniz")
        {



            SqlConnection Conn = new SqlConnection(s);
            SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "' ) and (t.soyad='" + soyad + "'  ) and (t.adres_il='" + adresil + "')", Conn);

            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS, "toptanci");
            Conn.Open();
            Cmd.ExecuteNonQuery();
            GridView1.DataSource = DS;
            GridView1.DataBind();
            Conn.Close();
            Label8.Visible = false;
            if (GridView1.Rows.Count == 0)
            {
                Label8.Visible = true;

            }


        }
        else
            if (ad != "")
            {
                if (soyad != "")
                {
                    //  Response.Write("<script>alert(' ada ve soyada göre ara!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "') and (t.soyad='" + soyad + "'  ) ", Conn);

                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();
                    Label8.Visible = false;
                    if (GridView1.Rows.Count == 0)
                    {
                        Label8.Visible = true;

                    }



                }
                else if (adresil != "Seçiniz")
                {
                    //  Response.Write("<script>alert('ada ve ile göre!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "')  and (t.adres_il='" + adresil + "')", Conn);

                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();

                    Label8.Visible = false;
                    if (GridView1.Rows.Count == 0)
                    {
                        Label8.Visible = true;

                    }
                }
                else
                {
                    // Response.Write("<script>alert('ada  göre ara!'); </script>");

                    SqlConnection Conn = new SqlConnection(s);
                    SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "') ", Conn);

                    SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS, "toptanci");
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                    GridView1.DataSource = DS;
                    GridView1.DataBind();
                    Conn.Close();

                    Label8.Visible = false;
                    if (GridView1.Rows.Count == 0)
                    {
                        Label8.Visible = true;

                    }

                }

            }
            else
                if (soyad != "")
                {
                    if (ad != "")
                    {
                        //Response.Write("<script>alert('soyad ve ada göre ara!'); </script>");

                        SqlConnection Conn = new SqlConnection(s);
                        SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "') and (t.soyad='" + soyad + "'  )", Conn);

                        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                        DataSet DS = new DataSet();
                        DA.Fill(DS, "toptanci");
                        Conn.Open();
                        Cmd.ExecuteNonQuery();
                        GridView1.DataSource = DS;
                        GridView1.DataBind();
                        Conn.Close();

                        Label8.Visible = false;
                        if (GridView1.Rows.Count == 0)
                        {
                            Label8.Visible = true;

                        }
                    }
                    else
                        if (adresil != "Seçiniz")
                        {
                            //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where  (t.soyad='" + soyad + "'  ) and (t.adres_il='" + adresil + "')", Conn);

                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();
                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();
                            Label8.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label8.Visible = true;

                            }

                        }
                        else
                        {
                            //Response.Write("<script>alert('soyad  göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where  (t.soyad='" + soyad + "'  ) ", Conn);

                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();
                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();

                            Label8.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label8.Visible = true;

                            }
                        }

                }
                else
                    if (adresil != "Seçiniz")
                    {
                        if (ad != "")
                        {
                            //Response.Write("<script>alert('ile ve ada göre ara!'); </script>");

                            SqlConnection Conn = new SqlConnection(s);
                            SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where (t.ad='" + ad + "')  and (t.adres_il='" + adresil + "')", Conn);

                            SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                            DataSet DS = new DataSet();
                            DA.Fill(DS, "toptanci");
                            Conn.Open();
                            Cmd.ExecuteNonQuery();
                            GridView1.DataSource = DS;
                            GridView1.DataBind();
                            Conn.Close();

                            Label8.Visible = false;
                            if (GridView1.Rows.Count == 0)
                            {
                                Label8.Visible = true;

                            }
                        }
                        else
                            if (soyad != "")
                            {
                                //Response.Write("<script>alert('soyad ve ile  göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where  (t.soyad='" + soyad + "'  ) and (t.adres_il='" + adresil + "')", Conn);

                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();
                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();
                                Label8.Visible = false;
                                if (GridView1.Rows.Count == 0)
                                {
                                    Label8.Visible = true;

                                }

                            }
                            else
                            {
                                //Response.Write("<script>alert('ile göre ara!'); </script>");

                                SqlConnection Conn = new SqlConnection(s);
                                SqlCommand Cmd = new SqlCommand("SELECT t.ad as adi , soyad ,t.kod as kodu, t.cep_tel as cep, il.ad as adres  From toptanci t INNER JOIN adres_il il on t.adres_il= il.kod where  (t.adres_il='" + adresil + "')", Conn);

                                SqlDataAdapter DA = new SqlDataAdapter(Cmd);
                                DataSet DS = new DataSet();
                                DA.Fill(DS, "toptanci");
                                Conn.Open();
                                Cmd.ExecuteNonQuery();
                                GridView1.DataSource = DS;
                                GridView1.DataBind();
                                Conn.Close();

                                Label8.Visible = false;
                                if (GridView1.Rows.Count == 0)
                                {
                                    Label8.Visible = true;

                                }
                            }


                    }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
        String kod = (String)Session["kod"];
        Label topkod = (Label)GridView1.Rows[e.RowIndex].FindControl("kodu");
        String top = Convert.ToString(topkod.Text);
        //System.Diagnostics.Debug.WriteLine(takip);
        DataRow kont = veritabani.GetDataRow("select * from ciftci_toptanci where t_eden = '" + kod + "' and t_edilen='" + top + "'");

        if (kont != null)
        {
            Response.Write("<script>alert('Bu kişi zaten ekli!'); </script>");
        }
        else
        {

            SqlConnection Conn = new SqlConnection(s);
            //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
            SqlCommand db = new SqlCommand("insert into  ciftci_toptanci (t_eden, t_edilen) values ('" + kod + "' ,'" + top + "')", Conn);
            //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
            Conn.Open();
            db.ExecuteNonQuery();
            Conn.Close();
            Response.Write("<script>alert('toptancılarım listesine eklendi!'); </script>");
        }

    }

    protected void eklesil(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
        String kod = (String)Session["kod"];
        System.Web.UI.WebControls.Label ciftcikod = (System.Web.UI.WebControls.Label)row.FindControl("kodu");
        int ciftci = Int32.Parse(ciftcikod.Text);
        //System.Diagnostics.Debug.WriteLine(takip);
        DataRow kont = veritabani.GetDataRow("select * from ciftci_toptanci where t_eden = '" + kod + "' and t_edilen='" + ciftci + "'");

        if (kont != null)
        {
            if (System.Windows.Forms.MessageBox.Show("Listenizden Silmek İstediğinize Emin Misiniz?", "Silme Onayı", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
                // String kod = (String)Session["kod"];


                SqlConnection Conn = new SqlConnection(s);
                //    SqlCommand db = new SqlCommand("select* from ciftci_urun where ciftci_kod='" + kod + "' and urun_kod= " + urun + "", Conn);
                SqlCommand db = new SqlCommand("Delete from ciftci_toptanci where t_eden='" + kod + "' and t_edilen= '" + ciftci + "'", Conn);
                //cmd.CommandText = "Delete from StudentRecord where StId='" + lbldeleteID.Text + "'";
                Conn.Open();
                db.ExecuteNonQuery();
                Conn.Close();
                yukle();
            }
        }
        else
        {

            DataRow ekle = veritabani.GetDataRow("insert into  ciftci_toptanci (t_eden, t_edilen) values ('" + kod + "' ,'" + ciftci + "')");

            yukle();

            //   Response.Write("<script>alert('çiftçilerim listesine eklendi!'); </script>");
        }
    }

    protected void sec(object sender, ImageClickEventArgs e)
    {

      //  GridView2.BackColor = System.Drawing.Color.Bisque;
        SqlConnection Conn = new SqlConnection(s);
        // Response.Write("<script>alert('Bir Hata Oluştu!'); </script>");
        String kod = (String)Session["kod"];
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.Parent.Parent;
        System.Web.UI.WebControls.Label t_edilen = (System.Web.UI.WebControls.Label)row.FindControl("kodu");
        int takip = Int32.Parse(t_edilen.Text);
        System.Web.UI.WebControls.Label ad = (System.Web.UI.WebControls.Label)row.FindControl("adi");
        String adi = Convert.ToString(ad.Text);
        System.Web.UI.WebControls.Label soyad = (System.Web.UI.WebControls.Label)row.FindControl("soyad");
        

        String soyadi = soyad.Text.ToString();
        Label1.Text = adi;
        Label2.Text = soyadi;
        

        SqlCommand Cmd = new SqlCommand("SELECT  urun.miktar, isim.ad, tur.tur_ad FROM toptanci_urun urun , urun_isimleri isim, urun_turleri tur WHERE urun.toptanci_kod='" + takip + "'  AND urun.urun_kod= isim.kod AND isim.tur_kod=tur.kod AND urun.tur_kod=tur.kod ", Conn);

        SqlDataAdapter DA = new SqlDataAdapter(Cmd);
        DataSet DS = new DataSet();
        DA.Fill(DS, "toptanci_urun");
        Conn.Open();
        Cmd.ExecuteNonQuery();

        GridView2.DataSource = DS;
        GridView2.DataBind();
        Conn.Close();
        if (GridView2.Rows.Count != 0)
        {
            Label3.Text = "İhtiyaç Duyduğu Ürünler";
        }
        else {
            Label3.Text = "Toptancının Ekli Ürünü Yok!";
        }


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {// sayfalar arası geçiş yapmak için pageindex changing eventı altına kodları yazıoruz.
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = DS;
        BindData();
    }

}