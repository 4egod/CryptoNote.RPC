using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetBlocksCountData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("count")]
            public ulong Count { get; set; }
        }
    }
}
