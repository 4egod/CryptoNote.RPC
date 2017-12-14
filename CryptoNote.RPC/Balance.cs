using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class Balance
    {
        public ulong Available { get; set; }

        public ulong Locked { get; set; }

        public ulong Total { get { return Available + Locked; } }
    }
}
