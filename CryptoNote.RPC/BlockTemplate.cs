using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class BlockTemplate
    {
        [JsonProperty("blocktemplate_blob")]
        public string Blob { get; set; }

        [JsonProperty("difficulty")]
        public ulong Difficulty { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("reserved_offset")]
        public int ReservedOffset { get; set; }
    }
}
