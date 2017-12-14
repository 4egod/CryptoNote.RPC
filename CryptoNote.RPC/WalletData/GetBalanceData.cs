using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.WalletData
{
    internal class GetBalanceData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("available_balance")]
            public ulong AvailableAmount { get; set; }

            [JsonProperty("locked_amount")]
            public ulong LockedAmount { get; set; }
        }
    }
}
