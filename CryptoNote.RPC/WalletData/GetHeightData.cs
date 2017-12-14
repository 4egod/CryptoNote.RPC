using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.WalletData
{
    public class GetHeightData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("height")]
            public ulong Height { get; set; }
        }
    }
}
