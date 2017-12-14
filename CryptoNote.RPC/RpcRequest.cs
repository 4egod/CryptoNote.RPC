using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    public class RpcRequest<T>
    {
        [JsonProperty("jsonrpc")]
        public static string Version { get { return "2.0"; } }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public T Arguments { get; set; }
    }
}
