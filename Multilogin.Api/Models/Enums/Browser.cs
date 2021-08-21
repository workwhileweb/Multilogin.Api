using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Multilogin.Api.Models.Enums
{
    /// <summary>
    /// All browser types available in Mla
    /// </summary>
    public enum Browser
    {
        [EnumMember(Value = "stealthfox")]
        Stealthfox = 4,

        [EnumMember(Value = "mimic")]
        Mimic = 5,

        [EnumMember(Value = "mimic_mobile")]
        MimicMobile = 6,
    }
}
