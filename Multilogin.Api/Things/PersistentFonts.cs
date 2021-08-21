using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    public partial class PersistentFonts
    {
        [JsonProperty("windows")]
        public string[] Windows { get; set; }

        [JsonProperty("mac")]
        public string[] Mac { get; set; }

        [JsonProperty("linux")]
        public string[] Linux { get; set; }
    }
}
