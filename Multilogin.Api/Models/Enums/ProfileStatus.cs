using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Multilogin.Api.Models.Enums
{
    /// <summary>
    /// Status of a profile status listing
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProfileStatus
    {
        [EnumMember(Value = "DOWNLOADING")]
        Downloading,

        [EnumMember(Value = "RUNNING")]
        Running,

        [EnumMember(Value = "SYNCING")]
        Syncing,
    }
}
