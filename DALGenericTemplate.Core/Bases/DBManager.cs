using DALGenericTemplate.Core.Bases.Interfaces;
using DALGenericTemplate.Core.Utils.Enums;
using DALGenericTemplate.Core.Utils.Extensions;
using DALGenericTemplate.Core.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.Bases
{
    public class DBManager : IDisposable
    {
        private DatabaseHandlerFactory dbFactory;
        private IDatabaseHandler database;
        private EnumProvider provider;

        public DBManager(string connectionStringName,
            EnumProvider providerEnum = EnumProvider.Oracle)
        {
            dbFactory = new DatabaseHandlerFactory(connectionStringName, providerEnum);
            database ??= dbFactory.CreateDatabase();
            provider = providerEnum;
        }

        public DBManager(string connectionStringName, IDatabaseHandler _database) : this(connectionStringName)
        {
            this.database = _database;
        }

        public IDbConnection GetDatabaseConnection()
        {
            return database.CreateConnection();
        }

        public void CloseConnection(IDbConnection connection)
        {
            database.CloseConnection(connection);
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdapter = database.CreateAdapter(command);
                        dataAdapter.Fill(dataset);

                        return dataset.Tables[0];
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        var dataset = new DataSet();
                        var dataAdapter = database.CreateAdapter(command);
                        dataAdapter.Fill(dataset);

                        return dataset;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection)
        {
            IDataReader reader = null;
            connection = database.CreateConnection();
            connection.Open();

            var command = database.CreateCommand(commandText, commandType, connection);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            reader = command.ExecuteReader();

            return reader;
        }

        #region INSERT

        public void Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int lastId)
        {
            lastId = 0;
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        object? newId = command.ExecuteScalar();
                        lastId = Convert.ToInt32(newId);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

            return lastId;
        }

        public long Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out long lastId)
        {
            lastId = 0;
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        object? newId = command.ExecuteScalar();
                        lastId = Convert.ToInt64(newId);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            }

            return lastId;
        }

        public void InsertWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction();

                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void InsertWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction(isolationLevel);

                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void InsertWithTransaction(Action<IDbConnection, IDbTransaction> func)
        {
            IDbTransaction? transactionScope = null;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction();

                try
                {
                    func(connection,transactionScope);
                    transactionScope.Commit();
                }
                catch (Exception)
                {
                    transactionScope.Rollback();
                }
                finally
                {
                    connection.Close();
                }

            }

        }

        #endregion

        #region UPDATE

        public void Update(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void UpdateWithTransaction(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            IDbTransaction? transactionScope = null;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction();

                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void UpdateWithTransaction(string commandText, CommandType commandType, IsolationLevel isolationLevel, IDbDataParameter[] parameters)
        {
            IDbTransaction transactionScope = null;
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                transactionScope = connection.BeginTransaction(isolationLevel);

                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    try
                    {
                        command.ExecuteNonQuery();
                        transactionScope.Commit();
                    }
                    catch (Exception)
                    {
                        transactionScope.Rollback();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        #endregion

        #region DELETE

        public void Delete(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();
                try
                {
                    using (var command = database.CreateCommand(commandText, commandType, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var parameter in parameters)
                            {
                                command.Parameters.Add(parameter);
                            }
                        }

                        command.ExecuteNonQuery();
                    }

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        #endregion

        #region PARAMETERS

        public IDbDataParameter CreateParameter(string name, object value, DbType dbType)
        {
            return DataParameterHelper.CreateParameter(provider, name, value, dbType, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return DataParameterHelper.CreateParameter(provider, name, size, value, dbType, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return DataParameterHelper.CreateParameter(provider, name, size, value, dbType, direction);
        }


        #endregion

        public object? GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = database.CreateConnection())
            {
                connection.Open();

                using (var command = database.CreateCommand(commandText, commandType, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
