using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class Transaction
    {
        public List<Transfer> Transfers { get; set; }

        public string TransactionHash { get; set; }

        public long Amount { get; set; }

        public ulong Fee { get; set; }

        public DateTime Timestamp { get; set; }

        public ulong BlockIndex { get; set; }

        public string PaymentId { get; set; }

        //public ulong UnlockTime { get; set; }

        //public string Extra { get; set; }
        
    }
}
