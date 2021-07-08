using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public class fonksiyonlar
{

    public static string Onay(string onay)
    {
        string deger;      
        if (Convert.ToInt32(onay) == 0)
        {
            deger = "../images/onaysiz.gif";
        }
        else
        {
            deger = "../images/onayli.gif";
        }
        return deger;
    }

    public static bool TarihKontrol(string tarih)
    {
        try
        {
            DateTime dt = Convert.ToDateTime(tarih);
            return false;
        }
        catch
        {
            return true;
        }        
    }

    public static bool RakamKontrol(int rakam)
    {
        try
        {
            int yrakam = Convert.ToInt32(rakam);
            return false;
        }
        catch
        {
            return true;
        }
    }


    public static string sqlKontrol(string metin)
    {
        string cikti = "false";
        int i,j;

        //metin = metin.Replace('"','/');// cift tırnaklar slaca cevriliyor       
        string[] yKarakter = {"=","#","%","&","'","\"","*","+","|",">","<","}","{","[","]","-","^","!"};//yabanci karakterlerimiz
        int yBoyut = yKarakter.Length;//yabanci karakterler dizimizin boyutu
       
        char[] diziMetin= metin.ToCharArray(); // metnimizi bir diziye atıyoruz
        int diziMetinBoyut = diziMetin.Length; // dizimizin boyutu bulunuyor
        
        for (i = 0; i <diziMetinBoyut ; i++ )
        {
            for (j = 0; j <yBoyut ; j++)
            { 
                if (diziMetin[i].ToString() == yKarakter[j])
                {
                    cikti = "true";
                }
            }
            
        }
        return cikti;
    }

    public static string karakterSinirla(int sinir, string metin)
    {
        string cikti = "false";
       
        char[] diziMetin = metin.ToCharArray();
        int diziMetinBoyut = diziMetin.Length;

        if (diziMetinBoyut < sinir)
        {
            cikti = "true";
        }
        return cikti;
    }

    public static string getGMUrl(string zipcode, string city) 
    {
        string gmurl = "http:"+""+"//maps.google.com/maps/api/staticmap?center=" + zipcode + "," + city + ",Turkey&markers=color:blue|label:P|" + zipcode + "," + city + ",Turkey&zoom=14&size=400x400&key=ABQIAAAAYS__SEee3eG9ald6A_TyAxQGKJ5s-tZ3nJhW5joKccjPxpgYjhQDtsc5Zq7WNS45hzUt7qSO4K5YyA&sensor=false";

        return gmurl;
    }


    static public bool verifyZip(string zipcode)
    {
        dbConnection dbc = new dbConnection();

        SqlConnection baglanti = new SqlConnection(@"Data Source=BRAHIMPC;Database=ETARIM;User ID=sa;Password=12345;Connect Timeout=200; pooling='true'; Max Pool Size=200;");
        baglanti.Open();

        SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_zip where zip = '" + zipcode + "'", baglanti);
        DataTable dt = new DataTable();

        try
        {
            adapter.Fill(dt);
            DataTableReader dtr = dt.CreateDataReader();

            if (dtr.Read())
                return true;

        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (select * from tbl_zip where zip =");
        }
        finally
        {
            adapter.Dispose();
            baglanti.Close();
        }

        return false;

    }
   
}
