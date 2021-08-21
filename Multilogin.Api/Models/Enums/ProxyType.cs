using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Models.Enums
{
    /// <summary>
    /// Proxy mode
    /// </summary>
    public enum ProxyType
    {
        None = 0,
        Https = 1,
        Socks4 = 2,
        Socks5 = 3,
    }
}
 