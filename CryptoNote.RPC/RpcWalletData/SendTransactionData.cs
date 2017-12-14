using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.RpcWalletData
{
    public class SendTransactionData
    {
        public class Request
        {
            public class Transfer
            {
                [JsonProperty("address")]
                public string Address { get; set; }

                [JsonProperty("amount")]
                public ulong Amount { get; set; }
            }

            [JsonProperty("addresses")]
            public string[] Addresses { get; set; }

            [JsonProperty("transfers")]
            public Transfer[] Transfers { get; set; }

            [JsonProperty("paymentId")]
            public string PaymentId { get; set; }

            [JsonProperty("fee")]
            public ulong Fee { get; set; }

            [JsonProperty("anonymity")]
            public ulong Mixin { get; set; }

            [JsonProperty("unlockTime")]
            public ulong UnlockTime { get; set; }
        }

        public class Response
        {
            [JsonProperty("transactionHash")]
            public string TransactionHash { get; set; }
        }
    }
}
