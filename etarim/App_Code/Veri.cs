using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Veri
/// </summary>
public class Veri
{
    private string _Baglanti;
	public Veri(string baglanti)
	{
        _Baglanti = ConfigurationManager.AppSettings[baglanti];
	}
    private List<object> Values = new List<object>();
    public void AddParameters(object val)
    {
        Values.Add(val);
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
    public IDataReader Reader
    {
        get
        {
            Con.Open();
            IDataReader donen = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return donen;
        }
    }
    private SqlDataAdapter _Adapter;
    private SqlDataAdapter Adapter
    {
        get 
        {
            if (_Adapter == null)
                _Adapter = new SqlDataAdapter(Cmd);
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


    public DataRow GetDataRow(string p)
    {
        throw new NotImplementedException();
    }
}
