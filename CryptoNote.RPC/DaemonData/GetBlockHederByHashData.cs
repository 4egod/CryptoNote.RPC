using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetBlockHederByHashData
    {
        public class Request
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }
        }

        public class Response
        {
            [JsonProperty("block_header")]
            public BlockHeader BlockHeader { get; set; }
        }
    }
}
