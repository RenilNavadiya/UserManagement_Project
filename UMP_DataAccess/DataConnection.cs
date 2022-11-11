using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMP_DataAccess
{
    public class DataConnection
    {
        public DataConnection(SqlTransaction trans = null)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["UserManagementDsn"].ToString();
            _trans = trans;
        }

        private string _connectionString { get; set; }
        public string ConnectionString => _connectionString;

        private SqlTransaction _trans { get; set; }
        public SqlTransaction Trans => _trans;
    }
}
