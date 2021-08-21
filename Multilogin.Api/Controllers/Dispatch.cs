using Multilogin.Api.Models.EventArgs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Controllers
{
    public class Dispatch
    {
        public Models.Local Local { get; set; }

        public Models.Remote Remote { get; set; }


        public string Uuid;

        internal RestClient Client;
        internal Random Rnd;
        

        public Dispatch(RestClient client, Random rnd, int mlaPort, string remoteUrl, string token = null)
        {
            this.Client = client;
            this.Rnd = rnd;

            Local = new Models.Local(ref Client, ref Rnd, token, mlaPort, remoteUrl);
            Remote = new Models.Remote(ref Client, ref Rnd, token, mlaPort, remoteUrl);

            Local.RequestsUpdated += C_RequestsUpdated;
            Remote.RequestsUpdated += C_RequestsUpdated;

            Local.TokenUpdated += C_TokenUpdated;
            Remote.TokenUpdated += C_TokenUpdated;

            // Auto-Generate Token
            if (string.IsNullOrWhiteSpace(token))
            {
                var tokenArgs = new TokenUpdatedEventArgs()
                {
                    Token = Local.GetApiToken(),
                };

                Local.OnTokenUpdated(tokenArgs);
            }
        }

        public void C_RequestsUpdated(object sender, RequestsUpdateEventArgs e)
        {
            Local.UpdateRequests(e.Requests);
            Remote.UpdateRequests(e.Requests);
        }

        public void C_TokenUpdated(object sender, TokenUpdatedEventArgs e)
        {
            Local.UpdateToken(e.Token);
            Remote.UpdateToken(e.Token);
        }

    }
}
