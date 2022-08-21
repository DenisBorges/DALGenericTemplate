using DALGenericTemplate.Core.Bases.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.DataAccess
{
    public class SqlDataAccess : IDatabaseHandler
    {
        private readonly string ConnectionString;

        public SqlDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void CloseConnection(IDbConnection connection)
        {
            var sqlConnection = (SqlConnection)connection;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new SqlCommand()
            {
                CommandText = commandText,
                CommandType = commandType,
                Connection = (SqlConnection)connection
            };
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            SqlCommand sqlCommand = (SqlCommand)command;
            return sqlCommand.CreateParameter();
        }
    }
}
