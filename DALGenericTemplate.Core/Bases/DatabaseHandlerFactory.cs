using DALGenericTemplate.Core.Bases.Interfaces;
using DALGenericTemplate.Core.DataAccess;
using DALGenericTemplate.Core.Utils.Enums;
using DALGenericTemplate.Core.Utils.Extensions;
using System.Configuration;

namespace DALGenericTemplate.Core.Bases
{
    public class DatabaseHandlerFactory
    {

        private string connectionString;
        private EnumProvider provider;


        public DatabaseHandlerFactory(string connectionStringName, EnumProvider provider)
        {
            connectionString = connectionStringName;
            this.provider = provider;
        }

        public IDatabaseHandler CreateDatabase()
        {
            IDatabaseHandler? database = null;

            switch (provider)
            {
                default:
                case EnumProvider.Oracle:
                    database = new OracleDataAccess(connectionString);
                    break;
                case EnumProvider.SqlServer:
                    database = new SqlDataAccess(connectionString);
                    break;
            }

            return database;
        }
    }
}
