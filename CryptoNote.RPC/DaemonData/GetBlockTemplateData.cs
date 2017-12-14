using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetBlockTemplateData
    {
        public class Request
        {
            [JsonProperty("reserve_size")]
            public int ReserveSize { get; set; }

            [JsonProperty("wallet_address")]
            public string WalletAddress { get; set; }
        }

        public class Response
        {
            [JsonProperty("blocktemplate_blob")]
            public string Blob { get; set; }

            [JsonProperty("difficulty")]
            public ulong Difficulty { get; set; }

            [JsonProperty("height")]
            public ulong Height { get; set; }

            [JsonProperty("reserved_offset")]
            public int ReservedOffset { get; set; }
        }
    }
}
