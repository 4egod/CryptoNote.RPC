using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class DaemonInfo
    {
        [JsonProperty("difficulty")]
        public long Difficulty { get; set; }

        [JsonProperty("height")]
        public long BlocksCount { get; set; }

        [JsonProperty("tx_count")]
        public long TransactionsCount { get; set; }

        [JsonProperty("last_known_block_index")]
        public long LastBlockIndex { get; set; }

        [JsonProperty("incoming_connections_count")]
        public int InConnectionsCount { get; set; }

        [JsonProperty("outgoing_connections_count")]
        public int OutConnectionsCount { get; set; }
    }
}
