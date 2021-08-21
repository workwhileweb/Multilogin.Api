using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things.Base
{
    public partial class Param
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public long? Code { get; set; }

        [JsonProperty("ext", NullValueHandling = NullValueHandling.Ignore)]
        public string Ext { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public object Value { get; set; }
    }
}
