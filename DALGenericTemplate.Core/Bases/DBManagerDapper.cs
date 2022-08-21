using DALGenericTemplate.Core.Bases.Interfaces;
using System.Data;
using Dapper;

namespace DALGenericTemplate.Core.Bases
{
    public partial class DBManager : IDapperBaseRepository
    {
        public T Get<T>(string query)
        {
            T parameter;

            using (var connection = database.CreateConnection())
            {
                try
                {
                    parameter = connection.QueryFirst<T>(query);
                    return parameter;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<T> GetList<T>(string query)
        {
            IEnumerable<T> parameter;

            using (var connection = database.CreateConnection())
            {
                try
                {
                    parameter = connection.Query<T>(query);
                    return parameter;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
