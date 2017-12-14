using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.RpcWalletData
{
    using Newtonsoft.Json;

    public class GetBalanceData
    {
        public class Request
        {
            [JsonProperty("address")]
            public string Address { get; set; }
        }

        public class Response
        {
            [JsonProperty("availableBalance")]
            public ulong AvailableAmount { get; set; }

            [JsonProperty("lockedAmount")]
            public ulong LockedAmount { get; set; }
        }
    }
}
