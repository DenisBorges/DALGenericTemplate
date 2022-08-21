using DALGenericTemplate.Core.Bases.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.DataAccess
{
    public class OracleDataAccess : IDatabaseHandler
    {
        private readonly string ConnectionString;

        public OracleDataAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void CloseConnection(IDbConnection connection)
        {
            var oracleConnection = (OracleConnection)connection;
            oracleConnection.Close();
            oracleConnection.Dispose();
        }

        public IDataAdapter CreateAdapter(IDbCommand command)
        {
            return new OracleDataAdapter((OracleCommand)command);
        }

        public IDbCommand CreateCommand(string commandText, CommandType commandType, IDbConnection connection)
        {
            return new OracleCommand()
            {
                CommandText = commandText,
                CommandType = commandType,
                Connection = (OracleConnection)connection
            };
        }

        public IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }

        public IDbDataParameter CreateParameter(IDbCommand command)
        {
            OracleCommand oracleCommand = (OracleCommand)command;
            return oracleCommand.CreateParameter();
        }
    }
}
