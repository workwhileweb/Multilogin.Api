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
    /// Operating System
    /// </summary>
    public enum OS
    {
        [EnumMember(Value = "win")]
        Windows,

        [EnumMember(Value = "lin")]
        MacOS,

        [EnumMember(Value = "mac")]
        Linux,

        [EnumMember(Value = "android")]
        Android,
    }
}
