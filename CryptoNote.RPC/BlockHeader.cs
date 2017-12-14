using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoNote.RPC
{
    public class BlockHeader
    {
        [JsonProperty("depth")]
        public ulong Depth { get; set; }

        [JsonProperty("difficulty")]
        public ulong Difficulty { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("major_version")]
        public int MajorVersion { get; set; }

        [JsonProperty("minor_version")]
        public int MinorVersion { get; set; }

        [JsonProperty("nonce")]
        public long Nonce { get; set; }

        [JsonProperty("orphan_status")]
        public bool IsOrphan { get; set; }

        [JsonProperty("prev_hash")]
        public string PrevHash { get; set; }

        [JsonProperty("reward")]
        public ulong Reward { get; set; }

        [JsonProperty("timestamp")]
        public ulong Timestamp { get; set; }
    }
}
