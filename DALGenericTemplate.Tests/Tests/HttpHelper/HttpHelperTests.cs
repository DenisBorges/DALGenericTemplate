using DALGenericTemplate.Core.Utils.Helper.Interfaces;
using DALGenericTemplate.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DALGenericTemplate.Core.Utils.Helper;
using DALGenericTemplate.Tests.Mocks.HttpHelper;

namespace DALGenericTemplate.Tests.Tests.HttpHelperTests
{
    public class HttpHelperTests
    {
        [Fact]
        public async Task ValidHttpHelper_Post_FullSuccess()
        {
            string baseUrl = "http://localhost:5000/api";

            IHttpHelper _httpHelper = new HttpHelper(baseUrl);

            var response = await _httpHelper.Post<AuthResponse>("/Auth/Login",new {  email = "admin@carwash.com", password = "12345678" });

            Assert.IsType<AuthResponse>(response);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ValidHttpHelper_Post_FailedCredentials()
        {
            string baseUrl = "http://localhost:5000/api";

            IHttpHelper _httpHelper = new HttpHelper(baseUrl);

            var response = await _httpHelper.Post<AuthResponse>("/Auth/Login", new { email = "", password = "" });

            Assert.IsType<AuthResponse>(response);
            Assert.NotNull(response);
        }
    }
}
