using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.RpcWalletData
{
    internal class CreateAddressData
    {
        public class Request
        {
        }

        public class Response
        {
            [JsonProperty("address")]
            public string Address { get; set; }
        }
    }
}
