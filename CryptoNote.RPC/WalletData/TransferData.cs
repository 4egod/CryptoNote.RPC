using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.WalletData
{
    internal class TransferData
    {
        public class Request
        {
            public class Destination
            {
                [JsonProperty("amount")]
                public ulong Amount { get; set; }

                [JsonProperty("address")]
                public string Address { get; set; }
            }

            [JsonProperty("destinations")]
            public Destination[] Destinations { get; set; }

            [JsonProperty("payment_id")]
            public string PaymentId { get; set; }

            [JsonProperty("fee")]
            public ulong Fee { get; set; }

            [JsonProperty("mixin")]
            public ulong Mixin { get; set; }

            [JsonProperty("unlock_time")]
            public ulong UnlockTime { get; set; }
        }

        public class Response
        {
            [JsonProperty("tx_hash")]
            public string Hash { get; set; }
        }
    }
}
