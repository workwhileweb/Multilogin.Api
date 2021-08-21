using Multilogin.Api.Things.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Multilogin.Api.Things
{

    public partial class Generate
    {
        [JsonProperty("navigator")]
        public Navigator Navigator { get; set; }

        [JsonProperty("screen")]
        public Screen Screen { get; set; }

        [JsonProperty("webgl")]
        public Webgl Webgl { get; set; }

        [JsonProperty("webgl2")]
        public Webgl Webgl2 { get; set; }

        [JsonProperty("languages")]
        public Languages Languages { get; set; }

        [JsonProperty("fonts")]
        public List<string> Fonts { get; set; }

        [JsonProperty("webRtcLocalIps")]
        public string WebRtcLocalIps { get; set; }
    }

    public partial class Languages
    {
        [JsonProperty("acceptLanguage")]
        public string AcceptLanguage { get; set; }
    }

    public partial class Navigator
    {
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("hardwareConcurrency")]
        public long HardwareConcurrency { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("maxTouchPoints")]
        public long MaxTouchPoints { get; set; }

        [JsonProperty("buildID", NullValueHandling = NullValueHandling.Ignore)]
        public long? BuildId { get; set; }

        [JsonProperty("oscpu", NullValueHandling = NullValueHandling.Ignore)]
        public string OsCPU { get; set; }
    }

    public partial class Screen
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("pixelRatio")]
        public long PixelRatio { get; set; }
    }

    public partial class Webgl
    {
        [JsonProperty("unmaskedVendor")]
        public string UnmaskedVendor { get; set; }

        [JsonProperty("unmaskedRenderer")]
        public string UnmaskedRenderer { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }
}
