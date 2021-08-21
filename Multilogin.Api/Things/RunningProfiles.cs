using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    public class RunningProfiles
    {
        [JsonProperty("profiles")]
        public Dictionary<string, string> Profiles { get; set; } = new Dictionary<string, string>();

    }
}
