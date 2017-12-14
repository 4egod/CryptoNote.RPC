using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.WalletData
{
    internal class GetTransfersData
    {
        public class Request { }

        public class Response
        {
            [JsonProperty("transfers")]
            public List<TransactionData> Transfers { get; set; }
        }
    }
}
