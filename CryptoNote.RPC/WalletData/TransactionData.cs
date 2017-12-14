using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.WalletData
{
    public class TransactionData
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("amount")]
        public ulong Amount { get; set; }

        [JsonProperty("blockIndex")]
        public ulong BlockIndex { get; set; }

        [JsonProperty("fee")]
        public ulong Fee { get; set; }

        [JsonProperty("output")]
        public ulong IsOutput { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("time")]
        public ulong Time { get; set; }

        [JsonProperty("unlockTime")]
        public ulong UnlockTime { get; set; }

        [JsonProperty("transactionHash")]
        public string TransactionHash { get; set; }
    }
}
