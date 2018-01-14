using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC.DaemonData
{
    internal class GetTransactionInfoData
    {
        public class Request
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }
        }

        public class Response
        {
            [JsonProperty("block")]
            public BlockInfo BlockInfo { get; set; }

            [JsonProperty("txDetails")]
            public TXDetails TXDetails { get; set; }

            [JsonProperty("tx")]
            public TX TX { get; set; }
        }

        public class BlockInfo
        {
            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }
        }

        public class TXDetails
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }

            [JsonProperty("amount_out")]
            public long AmountOut { get; set; }

            [JsonProperty("fee")]
            public long Fee { get; set; }

            [JsonProperty("size")]
            public long Size { get; set; }

            [JsonProperty("mixin")]
            public long Mixin { get; set; }

            [JsonProperty("paymentId")]
            public string PaymentId { get; set; }
        }

        public class TX
        {
            [JsonProperty("vin")]
            public List<VINItem> VIN { get; set; }

            [JsonProperty("vout")]
            public List<VOUTItem> VOUT { get; set; }
        }

        public class VINValue
        {
            [JsonProperty("amount")]
            public long Amount { get; set; }

            [JsonProperty("k_image")]
            public string Image { get; set; }
        }

        public class VINItem
        {
            [JsonProperty("value")]
            public VINValue Value { get; set; }
        }

        public class VOUTData
        {
            [JsonProperty("key")]
            public string Key { get; set; }
        }

        public class VOUTTarget
        {
            [JsonProperty("data")]
            public VOUTData Data { get; set; }
        }

        public class VOUTItem
        {
            [JsonProperty("amount")]
            public long Amount { get; set; }

            [JsonProperty("target")]
            public VOUTTarget Target { get; set; }
        }
    }
}
