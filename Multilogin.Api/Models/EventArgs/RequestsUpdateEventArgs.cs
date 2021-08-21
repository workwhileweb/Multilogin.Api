using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Models.EventArgs
{
    /// <summary>
    /// Keep different models sync with same requests
    /// </summary>
    public class RequestsUpdateEventArgs
    {
        public List<DateTime> Requests { get; set; }
    }
}
