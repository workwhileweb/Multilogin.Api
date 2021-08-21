using Multilogin.Api.Models.Internal;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Models
{
    /// <summary>
    /// Common reusables
    /// </summary>
    public abstract class BaseModel : Request
    {

        internal override RestClient RestClient { get; set; }

        internal override Uri LocalUrl { get; set; }

        internal override Uri RemoteUrl { get; set; }

        internal override string Token { get; set; }

        internal override int BasePort { get; set; }

        internal override Random Rnd { get; set; }

        internal override List<DateTime> Requests { get; set; }

        public BaseModel(ref RestClient client, ref Random rnd, string token, int mlaPort, string remoteUrl) : base(ref client, ref rnd, token, mlaPort, remoteUrl)
        {

        }


    }
}
