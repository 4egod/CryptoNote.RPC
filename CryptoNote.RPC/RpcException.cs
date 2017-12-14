using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class RpcException : Exception
    {
        public RpcException(string message) : base(message) { }
    }
}
