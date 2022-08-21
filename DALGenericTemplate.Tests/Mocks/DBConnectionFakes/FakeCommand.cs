using System.Data;

namespace DALGenericTemplate.Tests.Mocks.DBConnectionFakes
{
    public class FakeCommand : IDbCommand
    {
        public string CommandText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CommandTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CommandType CommandType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDbConnection? Connection { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDataParameterCollection Parameters => throw new NotImplementedException();

        public IDbTransaction? Transaction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public UpdateRowSource UpdatedRowSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Cancel(){}

        public IDbDataParameter CreateParameter()
        {
            throw new NotImplementedException();
        }

        public void Dispose(){}

        public int ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        public IDataReader ExecuteReader(CommandBehavior behavior)
        {
            throw new NotImplementedException();
        }

        public object? ExecuteScalar()
        {
            throw new NotImplementedException();
        }

        public void Prepare(){}
    }
}
