using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALGenericTemplate.Core.Utils.Helper.Interfaces
{
    public interface IHttpHelper
    {
        Task<T> Get<T>(string url, Dictionary<string, string> headers = null) where T : class;
        Task<T> Post<T>(string url, string body, Dictionary<string, string> headers = null) where T : class;
        Task<T> Post<T>(string url, T body, Dictionary<string, string> headers = null) where T : class;
        Task<T> Put<T>(string url, string body, Dictionary<string, string> headers = null) where T : class;
        Task<T> Delete<T>(string url, string body, Dictionary<string, string> headers = null) where T : class;
        Task<T> Patch<T>(string url, string body, Dictionary<string, string> headers = null) where T : class;
    }
}
