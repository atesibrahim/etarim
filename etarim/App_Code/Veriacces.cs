using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.OleDb;
using System.Collections.Generic;

/// <summary>
/// Summary description for Veri
/// </summary>
public class Veriacces
{
    private string _Baglanti;
    public Veriacces(string baglanti)
	{
        _Baglanti = ConfigurationManager.AppSettings[baglanti];
	}
    private List<object> Values = new List<object>();
    public void AddParameters(object val)
    {
        Values.Add(val);
    }
    private OleDbConnection _Con;
    private OleDbConnection Con
    {
        get 
        {
            if (_Con == null)
                _Con = new OleDbConnection(_Baglanti);
            return _Con;
        }
    }
    private string _CmdText;
    public string CmdText
    {
        get { return _CmdText; }
        set { _CmdText = value; }
    }
    private OleDbCommand _Cmd;
    private OleDbCommand Cmd
    {
        get 
        {
            if (_Cmd == null)
            {
                _Cmd = new OleDbCommand();
                _Cmd.Connection = Con;
                _Cmd.CommandType = CommandType.Text;
            }
            if (Values.Count > 0)
            {
                for(int i=0;i<Values.Count;i++)
                {
                    _Cmd.Parameters.AddWithValue("?",Values[i]);
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
    public object Scalar
    {
        get
        {
            Con.Open();
            object donen = Cmd.ExecuteScalar();
            Con.Close();
            return donen;
        }
    }
    public DataRow GetDataRow(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }

    private DataTable GetDataTable(string sql)
    {
        OleDbConnection baglan = this.Con;
        OleDbDataAdapter adapter = new OleDbDataAdapter(sql, baglan);
        DataTable dt = new DataTable();

        try
        {
            adapter.Fill(dt);

        }
        catch (OleDbException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        finally
        {
            adapter.Dispose();
            baglan.Close();
        }
        return dt;
    }
    public IDataReader Reader
    {
        get
        {
            Con.Open();
            IDataReader donen = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return donen;
        }
    }
    private OleDbDataAdapter _Adapter;
    private OleDbDataAdapter Adapter
    {
        get 
        {
            if (_Adapter == null)
                _Adapter = new OleDbDataAdapter(Cmd);
            return _Adapter; 
        }
    }
    public DataSet Source
    {
        get
        {
            DataSet set = new DataSet();
            Adapter.Fill(set);
            return set;
        }
    }
}
