using DALGenericTemplate.Core.Bases.Interfaces;
using DALGenericTemplate.Tests.Mocks.DBConnectionFakes;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Tests.Mocks
{
    public class DatabaseHandlerFakeBuild
    {
        private Mock<IDatabaseHandler> handler;
        public DatabaseHandlerFakeBuild()
        {
            handler = new Mock<IDatabaseHandler>();
        }

        public DatabaseHandlerFakeBuild SetConnection_Success()
        {
            handler.Setup(x => x.CreateConnection())
                .Returns(new FakeConnection());

            return this;
        }

        public DatabaseHandlerFakeBuild SetCommand_Success()
        {
            handler.Setup(x => x.CreateCommand(It.IsAny<string>(),
                It.IsAny<CommandType>(),
                It.IsAny<IDbConnection>()))
                .Returns(new FakeCommand());

            return this;
        }

        public DatabaseHandlerFakeBuild SetAdapter_Success()
        {
            handler.Setup(x => x.CreateAdapter(It.IsAny<IDbCommand>()))
                .Returns(new FakeDataAdapter());

            return this;
        }

        public DatabaseHandlerFakeBuild SetCommand_ThrowException()
        {
            handler.Setup(x => x.CreateCommand(It.IsAny<string>(),
                     It.IsAny<CommandType>(),
                     It.IsAny<IDbConnection>()))
                     .Throws(new Exception());

            return this;
        }

        public Mock<IDatabaseHandler> Build()
        {
            return handler;
        }
    }
}
