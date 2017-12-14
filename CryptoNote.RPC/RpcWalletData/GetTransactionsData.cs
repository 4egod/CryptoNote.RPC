using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.RpcWalletData
{
    public class GetTransactionsData
    {
        public class Request
        {
            [JsonProperty("addresses")]
            public List<string> Addresses { get; set; }

            //[JsonProperty("blockHash ")]
            //public string BlockHash { get; set; }

            [JsonProperty("firstBlockIndex")]
            public uint FirstBlockIndex { get; set; }

            [JsonProperty("blockCount")]
            public uint BlockCount { get; set; }

            [JsonProperty("payment_id")]
            public string PaymentId { get; set; }
        }

        public class Response
        {
            public class Transfer
            {
                [JsonProperty("amount")]
                public long Amount { get; set; }

                [JsonProperty("address")]
                public string Address { get; set; }

                [JsonProperty("type")]
                public int Type { get; set; }
            }

            public class Transaction
            {
                [JsonProperty("transactionHash")]
                public string TransactionHash { get; set; }

                [JsonProperty("blockIndex")]
                public ulong BlockIndex { get; set; }

                [JsonProperty("timestamp")]
                public ulong Timestamp { get; set; }

                [JsonProperty("isBase")]
                public bool IsBase { get; set; }

                [JsonProperty("unlockTime ")]
                public ulong UnlockTime { get; set; }

                [JsonProperty("amount")]
                public long Amount { get; set; }

                [JsonProperty("fee")]
                public ulong Fee { get; set; }

                [JsonProperty("extra")]
                public string Extra { get; set; }

                [JsonProperty("paymentId")]
                public string PaymentId { get; set; }

                [JsonProperty("transfers")]
                public Transfer[] Transfers { get; set; }
            }
            
            public class Block
            {
                [JsonProperty("blockHash")]
                public string BlockHash { get; set; }

                [JsonProperty("transactions")]
                public List<Transaction> Transactions { get; set; }
            }

            [JsonProperty("items")]
            public List<Block> Blocks { get; set; }
        }
    }
}
