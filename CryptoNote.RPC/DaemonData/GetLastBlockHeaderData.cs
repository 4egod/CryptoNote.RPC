using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetLastBlockHeaderData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("block_header")]
            public BlockHeader BlockHeader { get; set; }
        }

    }
}
