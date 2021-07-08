using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// Admin paneli için bağlantı ekleme silme ve update fonksiyonlarının bulunacağı sınıf.
/// </summary>
public class dbConnection {

    //Veri Tabanı Bağlantısı
    public SqlConnection baglan() {
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection baglanti = new SqlConnection(connStr);
        baglanti.Open();
        return (baglanti);
    }

    //Sql Sorgu Çalıştırma
    public int trans(string sqlcumle) {
        SqlConnection baglan = this.baglan();
        SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
        int sonuc = 0;
        try {
            sonuc = sorgu.ExecuteNonQuery();
        } catch (SqlException ex) {
            throw new Exception(ex.Message + " (" + sqlcumle + ")");
        } finally {
            sorgu.Connection.Close();
        }
        return (sonuc);
    }

    //Kayıt Sayısı Bulma
    public string GetDataCell(string sql) {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0)
            return null;
        return table.Rows[0][0].ToString();
    }

    //Kayıt Çekme
    public DataRow GetDataRow(string sql) {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }

    //DataTable ye veri çekme
    public DataTable GetDataTable(string sql) {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataTable dt = new DataTable();

        try {
            adapter.Fill(dt);

        } catch (SqlException ex) {
            throw new Exception(ex.Message + " (" + sql + ")");
        } finally {
            adapter.Dispose();
            baglan.Close();
        }
        return dt;
    }
    private List<object> Values = new List<object>();
    public void AddParameters(object val)
    {
        Values.Add(val);
    }
    //Datasete veri çekme
    public DataSet GetDataSet(string sql) {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataSet ds = new DataSet();
        try {
            adapter.Fill(ds);
        } catch (SqlException ex) {
            throw new Exception(ex.Message + " (" + sql + ")");
        } finally {
            ds.Dispose();
            adapter.Dispose();
            baglan.Close();
        }
        return ds;
    }
        private string _Baglanti;
        public dbConnection(string baglanti)
	{
        _Baglanti = ConfigurationManager.AppSettings[baglanti];
	}

        public dbConnection()
        {
            // TODO: Complete member initialization
        }

    private SqlConnection _Con;
    private SqlConnection Con
    {
        get
        {
            if (_Con == null)
                _Con = new SqlConnection(_Baglanti);
            return _Con;
        }
    }
    private string _CmdText;
    public string CmdText
    {
        get { return _CmdText; }
        set { _CmdText = value; }
    }
    private SqlCommand _Cmd;
    private SqlCommand Cmd
    {
        get
        {
            if (_Cmd == null)
            {
                _Cmd = new SqlCommand();
                _Cmd.Connection = Con;
                _Cmd.CommandType = CommandType.Text;
            }
            if (Values.Count > 0)
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    _Cmd.Parameters.AddWithValue("?", Values[i]);
                }
            }
            _Cmd.CommandText = _CmdText;
            return _Cmd;
        }
    }
    public int NonQuery
    {
        get
        {
            Con.Open();
            int donen = Cmd.ExecuteNonQuery();
            Con.Close();
            return donen;
        }
    }

    public IDataReader Reader
    {
        get
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(connStr);
            baglanti.Open();
            IDataReader donen = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return donen;
        }
    }
    // sayfalayarak veri çekme 
    public DataSet GetDataSetSayfalama(string sql, int baslangickaydi, int sayfadakikayitsayisi, string table)
    {
        SqlConnection baglan = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglan);
        DataSet ds = new DataSet();
        try
        {
            adapter.Fill(ds, baslangickaydi, sayfadakikayitsayisi, table);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            ds.Dispose();
            adapter.Dispose();
            baglan.Close();
        }
        return ds;
    }


}



