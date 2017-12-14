using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    public abstract class RpcClientBase
    {
        protected readonly string JsonRoot = "/json_rpc";

        public RpcClientBase(string uri)
        {
            Uri = uri;
        }

        protected HttpClient _client = new HttpClient();

        protected string Uri { get; set; }

        protected async Task<T> GetAsync<T>(string uri)
        {
            string response;
            using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                //string command = string.Format("token={0}&username={1}&password={2}", _token, _email, _password);
                //req.Content = new StringContent(requestCmd, Encoding.UTF8, "application/json");
                response = await (await _client.SendAsync(req)).Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(response);
        }

        protected async Task<T> PostAsync<T>(object request, string uri)
        {
            string requestCmd = JsonConvert.SerializeObject(request);

            string response;

            using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                req.Content = new StringContent(requestCmd, Encoding.UTF8, "application/json");
                response = await (await _client.SendAsync(req)).Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
