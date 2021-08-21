using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Models.EventArgs
{
    /// <summary>
    /// Keep different models sync with same token
    /// </summary>
    public class TokenUpdatedEventArgs
    {
        public string Token { get; set; }
    }
}
