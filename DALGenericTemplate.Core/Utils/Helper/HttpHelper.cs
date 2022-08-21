using Flurl;
using Flurl.Http;
using DALGenericTemplate.Core.Utils.Helper.Interfaces;

namespace DALGenericTemplate.Core.Utils.Helper
{
    public class HttpHelper : IHttpHelper
    {
        private readonly string BaseUrl;
        public HttpHelper(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }
        public Task<T> Delete<T>(string url, string body, Dictionary<string, string> headers = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string url, Dictionary<string, string> headers = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Patch<T>(string url, string body, Dictionary<string, string> headers = null) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Post<T>(string url, string body, Dictionary<string, string> headers = null) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> Post<T>(string url, object body, Dictionary<string, string> headers = null) where T : class
        {
            try
            {
                return await BaseUrl
                    .AppendPathSegment(url)
                    .PostJsonAsync(body)
                    .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<T> Put<T>(string url, string body, Dictionary<string, string> headers = null) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
