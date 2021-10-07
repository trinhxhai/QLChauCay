using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Data.Common;

namespace QuanLyChauCayCanh.Business
{
    public class DataBaseConnection
    {
        public static DbConnection GetDatabaseConnection()
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["data_base"];
            DbProviderFactory factory = DbProviderFactories.GetFactory(setting.ProviderName);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = setting.ConnectionString;
            return conn;

        }
    }
}
