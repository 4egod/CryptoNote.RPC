using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class TransactionInfo
    {
        public class Block
        {
            public long Height { get; set; }

            public string Hash { get; set; }

            public DateTime Timestamp { get; set; }
        }

        public class VINItem
        {
            public long Amount { get; set; }

            public string Image { get; set; }
        }

        public class VOUTItem
        {
            public long Amount { get; set; }

            public string Key { get; set; }
        }

        public string Hash { get; set; }

        public long AmountOut { get; set; }

        public long Fee { get; set; }

        public long Size { get; set; }

        public long Mixin { get; set; }

        public string PaymentId { get; set; }

        public Block FromBlock { get; set; }

        public List<VINItem> VIN { get; set; }

        public List<VOUTItem> VOUT { get; set; }
    }
}
