using Multilogin.Api.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    /// <summary>
    /// Profiles being listed
    /// </summary>
    public partial class Profile
    {
        [JsonProperty("sid")]
        public Guid Sid { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("group")]
        public Guid Group { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lock")]
        public bool Lock { get; set; }

        [JsonProperty("browserType")]
        public Browser BrowserType { get; set; }

        [JsonProperty("browserTypeVersion")]
        public long BrowserTypeVersion { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }
    }
}
