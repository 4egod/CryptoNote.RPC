using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class Transfer
    {
        public long Amount { get; set; }

        public string Address { get; set; }

        public int Type { get; set; }
    }
}
