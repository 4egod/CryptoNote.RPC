using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetBlockHederByHeightData
    {
        public class Request
        {
            [JsonProperty("height")]
            public ulong Height { get; set; }
        }

        public class Response
        {
            [JsonProperty("block_header")]
            public BlockHeader BlockHeader { get; set; }
        }
    }
}
