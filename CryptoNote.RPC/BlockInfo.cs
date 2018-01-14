using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class BlockInfo
    {
        public long Height { get; set; }

        public string Hash { get; set; }

        public string PreviousHash { get; set; }

        public DateTime Timestamp { get; set; }

        public int MajorVersion { get; set; }

        public int MinorVersion { get; set; }

        public long Difficulty { get; set; }

        public bool IsOrphan { get; set; }

        public long TransactionsSize { get; set; }

        public long BlockSize { get; set; }

        public long MedianSize { get; set; }

        public float RewardPenalty { get; set; }

        public long BaseReward { get; set; }

        public long Reward { get; set; }

        public long TotalFeeAmount { get; set; }

        public ulong TotalCoinsInNetwork { get; set; }

        public long TotalTransactionsInNetwork { get; set; }

        public List<string> TransactionsHashes { get; set; }
    }
}
