using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Inputs
{
    public class SaveInput
    {

        [JsonProperty("tabs")]
        public List<string> Tabs { get; set; } = new List<string>();

    }
}
