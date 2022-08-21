using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Tests.Mocks.HttpHelper
{
    public class AuthResponse
    {
            public int statusCode { get; set; }
            public string message { get; set; }
            public string data { get; set; }
    }
}
