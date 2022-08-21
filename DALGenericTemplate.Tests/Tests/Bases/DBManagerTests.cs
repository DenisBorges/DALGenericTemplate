﻿using DALGenericTemplate.Core.Bases;
using DALGenericTemplate.Core.Bases.Interfaces;
using DALGenericTemplate.Tests.Mocks;
using DALGenericTemplate.Tests.Mocks.DBConnectionFakes;
using Moq;
using System.Data;
using Xunit;

namespace DALGenericTemplate.Tests.Bases
{
    public class DBManagerTests
    {
        #region GetDataTable

        [Fact]
        public void ValidDBManager_FullSuccess()
        {
            var dbManagerMock = new DatabaseHandlerFakeBuild()
                .SetConnection_Success()
                .SetCommand_Success()
                .SetAdapter_Success()
                .Build();

            var dbManager = new DBManager("", dbManagerMock.Object);

            var dt = dbManager.GetDataTable("", CommandType.Text);

            Assert.NotNull(dt);

        }


        [Fact]
        public void ValidDBManager_ThrowException()
        {

            var dbManagerMock = new DatabaseHandlerFakeBuild()
                .SetConnection_Success()
                .SetAdapter_Success()
                .SetCommand_ThrowException()
                .Build();

            var dbManager = new DBManager("", dbManagerMock.Object);

            var exception = Record.Exception(() => dbManager.GetDataTable("", CommandType.Text));

            Assert.NotNull(exception);

        }

        #endregion

    }
}
