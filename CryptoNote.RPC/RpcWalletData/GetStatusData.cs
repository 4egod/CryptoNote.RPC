using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.RpcWalletData
{
    using Newtonsoft.Json;

    internal class GetStatusData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("blockCount")]
            public uint CurrentBlockIndex { get; set; }

            [JsonProperty("knownBlockCount")]
            public uint LastBlockIndex { get; set; }

            [JsonProperty("lastBlockHash")]
            public string LastBlockHash { get; set; }

            [JsonProperty("peerCount")]
            public uint PeersCount { get; set; }
        }
    }
}
