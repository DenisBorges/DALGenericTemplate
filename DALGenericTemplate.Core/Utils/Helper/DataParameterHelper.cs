using DALGenericTemplate.Core.Utils.Enums;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace DALGenericTemplate.Core.Utils.Helper
{
    public class DataParameterHelper
    {
        public static IDbDataParameter CreateParameter(EnumProvider provider, string name, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;

            switch (provider)
            {
                default:
                case EnumProvider.Oracle:
                    parameter = CreateOracleParameter(name, value, dbType, direction);
                    break;
            }

            return parameter;
        }

        public static IDbDataParameter CreateParameter(EnumProvider provider, string name, int size, object value, DbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            IDbDataParameter parameter = null;
            switch (provider)
            {
                default:
                case EnumProvider.Oracle:
                    parameter = CreateOracleParameter(name, size, value, dbType, direction);
                    break;
            }

            return parameter;
        }

        private static IDbDataParameter CreateOracleParameter(string name, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }

        private static IDbDataParameter CreateOracleParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return new OracleParameter
            {
                DbType = dbType,
                Size = size,
                ParameterName = name,
                Direction = direction,
                Value = value
            };
        }
    }
}
