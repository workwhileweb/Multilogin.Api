using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    public partial class BaseResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
