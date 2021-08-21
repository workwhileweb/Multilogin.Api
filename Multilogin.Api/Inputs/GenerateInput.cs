using Multilogin.Api.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Inputs
{
    public partial class GenerateInput
    {
        [JsonProperty("os")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OS Os { get; set; }

        [JsonProperty("maxWidth")]
        public long MaxWidth { get; set; }

        [JsonProperty("maxHeight")]
        public long MaxHeight { get; set; }

        [JsonProperty("minWidth")]
        public long MinWidth { get; set; }

        [JsonProperty("minHeight")]
        public long MinHeight { get; set; }

        [JsonProperty("nativeWidth")]
        public long NativeWidth { get; set; }

        [JsonProperty("nativeHeight")]
        public long NativeHeight { get; set; }

        [JsonProperty("browser")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Browser Browser { get; set; }

        [JsonProperty("versions")]
        public Versions Versions { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("webRtcLocalIps")]
        public string WebRtcLocalIps { get; set; }

        [JsonProperty("googleServices", NullValueHandling = NullValueHandling.Ignore)]
        public bool GoogleServices { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public partial class Versions
    {
        [JsonProperty("minVersion")]
        public long MinVersion { get; set; }

        [JsonProperty("maxVersion")]
        public long MaxVersion { get; set; }
    }
}
