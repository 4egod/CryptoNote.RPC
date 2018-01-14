using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetBlockInfoData
    {
        public class Request
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }
        }

        public class Response
        {
            public class TransactionShortInfo
            {
                [JsonProperty("amount_out")]
                public long AmountOut { get; set; }

                [JsonProperty("fee")]
                public long Fee { get; set; }

                [JsonProperty("hash")]
                public string Hash { get; set; }

                [JsonProperty("size")]
                public long Size { get; set; }
            }

            public class Block
            {
                [JsonProperty("height")]
                public long Height { get; set; }

                [JsonProperty("hash")]
                public string Hash { get; set; }

                [JsonProperty("prev_hash")]
                public string PreviousHash { get; set; }

                [JsonProperty("timestamp")]
                public long Timestamp { get; set; }

                [JsonProperty("major_version")]
                public int MajorVersion { get; set; }

                [JsonProperty("minor_version")]
                public int MinorVersion { get; set; }

                [JsonProperty("difficulty")]
                public long Difficulty { get; set; }

                [JsonProperty("orphan_status")]
                public bool IsOrphan { get; set; }

                [JsonProperty("transactionsCumulativeSize")]
                public long TransactionsSize { get; set; }

                [JsonProperty("blockSize")]
                public long BlockSize { get; set; }

                [JsonProperty("sizeMedian")]
                public long MedianSize { get; set; }

                [JsonProperty("penalty")]
                public float RewardPenalty { get; set; }

                [JsonProperty("baseReward")]
                public long BaseReward { get; set; }

                [JsonProperty("reward")]
                public long Reward { get; set; }

                [JsonProperty("totalFeeAmount")]
                public long TotalFeeAmount { get; set; }

                [JsonProperty("alreadyGeneratedCoins")]
                public ulong TotalCoinsInNetwork { get; set; }

                [JsonProperty("alreadyGeneratedTransactions")]
                public long TotalTransactionsInNetwork { get; set; }

                public long TotalTransactionsInBlock
                {
                    get
                    {
                        if (Transactions != null)
                        {
                            return Transactions.Count;
                        }

                        else return 0;
                    }
                }

                [JsonProperty("transactions")]
                public List<TransactionShortInfo> Transactions { get; set; }
            }

            [JsonProperty("block")]
            public Block Data { get; set; }
        }
    }
}
