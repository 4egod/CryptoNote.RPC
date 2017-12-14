using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoNote.RPC
{
    public class RpcResponse<T>
    {
        [JsonProperty(PropertyName = "error", Required = Required.Default)]
        public RpcError Error { get; set; }

        [JsonProperty(PropertyName = "result", Required = Required.Default)]
        public T Result { get; set; }
    }
}
