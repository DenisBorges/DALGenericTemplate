using System.Data;

namespace DALGenericTemplate.Tests.Mocks.DBConnectionFakes
{
    public class FakeConnection : IDbConnection
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int ConnectionTimeout => throw new NotImplementedException();

        public string Database => throw new NotImplementedException();

        public ConnectionState State => throw new NotImplementedException();

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName) { }

        public void Close() { }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Dispose() { }

        public void Open() { }
    }
}
