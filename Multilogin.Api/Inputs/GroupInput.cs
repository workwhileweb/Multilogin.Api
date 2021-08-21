using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Inputs
{
    public partial class GroupInput
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("accessRights")]
        public List<object> AccessRights { get; set; }

        [JsonProperty("accessRightsModified")]
        public bool AccessRightsModified { get; set; }

        [JsonProperty("uuid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Uuid { get; set; }
    }
}
