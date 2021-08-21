using Multilogin.Api.Models.EventArgs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multilogin.Api.Models.Internal
{
    /// <summary>
    /// Base class for API requests
    /// </summary>
    public abstract class Request
    {
        #region Client

        internal abstract RestClient RestClient { get; set; }

        internal abstract Uri LocalUrl { get; set; }

        internal abstract Uri RemoteUrl { get; set; }

        internal abstract string Token { get; set; }

        internal abstract int BasePort { get; set; }

        internal abstract Random Rnd { get; set; }

        internal abstract List<DateTime> Requests { get; set; }

        public event EventHandler<RequestsUpdateEventArgs> RequestsUpdated;

        public event EventHandler<TokenUpdatedEventArgs> TokenUpdated;


        private void AddRequest()
        {
            Requests.Add(DateTime.Now);

            RequestsUpdateEventArgs args = new RequestsUpdateEventArgs
            {
                Requests = Requests
            };

            OnRequestsUpdated(args);
        }

        internal bool RequestReady(int maxRequests = 60)
        {
            if (Requests.Count < maxRequests)
            {
                return true;
            }
            else
            {
                while (Requests.Count > 0)
                {
                    // As I understand, the general rule is 60 requests per minute.
                    if (Requests[0].AddSeconds(60) < DateTime.Now)
                    {
                        Requests.RemoveAt(0);
                    }
                    else
                    {
                        break;
                    }
                }

                RequestsUpdateEventArgs args = new RequestsUpdateEventArgs
                {
                    Requests = Requests
                };
                OnRequestsUpdated(args);

                return (Requests.Count < maxRequests);
            }
        }

        public RestRequest PrepareExecuteRequest(RestRequest restRequest)
        {
            // If we've reached the speed limit, hold until we're clear to proceed.
            while (!RequestReady())
            {
                Thread.Sleep(1000);
            }

            // Add to recent request history (used for ratelimiting purposes).
            AddRequest();

            // Set client requirements
            RestClient.UserAgent = "Mozilla/5.0  MultiLoginApp ui client. 5.14.1.3 Unity";

            return restRequest;
        }

        public bool IsRetryNeeded(IRestResponse res, int retry)
        {
            var retryNeeded = (res == null || !res.IsSuccessful) &&
                (res.StatusCode == HttpStatusCode.Unauthorized
                           || res.StatusCode == HttpStatusCode.InternalServerError
                           || res.StatusCode == HttpStatusCode.MovedPermanently
                           || res.StatusCode == 0);

            return retryNeeded;
        }

        private int GetRateLimit(IRestResponse res)
        {

            string retryAfter = res.Headers
                .Where(x => x.Name == "Retry-After")
                .Select(x => x.Value)
                .FirstOrDefault().ToString();

            if (!string.IsNullOrEmpty(retryAfter))
            {
                var retryAfterSeconds = Convert.ToInt32(retryAfter);
                return retryAfterSeconds * 1000;
            }
            else
            {
                return 60 * 1000;
            }


        }

        private bool IsRateLimited(IRestResponse res, ref int retry)
        {

            // If we hit a ratelimit of less than a minute, wait the specified time then retry.
            bool ratelimited = false;
            if (!string.IsNullOrWhiteSpace(res.Content)
                && res.StatusCode == HttpStatusCode.TooManyRequests
               )
            {
                // Get sleep time
                var sleepTime = GetRateLimit(res);

                // Confirm the errors JSON and extract the wait time.
                Thread.Sleep(sleepTime);

                ratelimited = true;
                retry--;
            }

            return ratelimited;
        }

        public RestRequest PrepareRequest(string url, Method method = Method.GET, string contentType = "application/x-www-form-urlencoded; charset=UTF-8")
        {
            RestRequest restRequest = new RestRequest(url, method);
            return PrepareRequest(restRequest, contentType);
        }

        private RestRequest PrepareRequest(RestRequest restRequest, string contentType = "application/x-www-form-urlencoded; charset=UTF-8")
        {
            // Add token, if we have one
            if (!string.IsNullOrEmpty(Token))
                restRequest.AddHeader("token", Token);

            // Setup JsonNet Serializer
            restRequest.JsonSerializer = new RestSharp.Serializers.NewtonsoftJson.JsonNetSerializer();
          
            // Add content type
            if (restRequest.Method == Method.POST || restRequest.Method == Method.PUT)
            {
                restRequest.AddHeader("Content-Type", contentType);
            }

            return restRequest;
        }

        public IRestResponse ExecuteRequest(RestRequest restRequest, bool throwErrors = true, Uri domain = null)
        {
            int ratelimitRetry = 5;
            IRestResponse res;
            do
            {
                RestClient client;

                if (domain != null)
                    client = new RestClient(domain) { Proxy = RestClient.Proxy };
                else
                    client = RestClient;

                res = client.Execute(PrepareExecuteRequest(restRequest));

            } while (IsRateLimited(res, ref ratelimitRetry) && ratelimitRetry > 0);

            return ProcessResponse(res, throwErrors);
        }

        private Exception BuildException(Exception ex, IRestResponse res)
        {
            ex.Data.Add("StatusCode", res.StatusCode);
            ex.Data.Add("StatusDescription", res.StatusDescription);
            ex.Data.Add("Content", res.Content);
            ex.Data.Add("ContentEncoding", res.ContentEncoding);
            ex.Data.Add("ContentLength", res.ContentLength);
            ex.Data.Add("ContentType", res.ContentType);
            ex.Data.Add("ErrorMessage", res.ErrorMessage);
            ex.Data.Add("ProtocolVersion", res.ProtocolVersion);
            ex.Data.Add("Server", res.Server);

            return ex;
        }

        public IRestResponse ProcessResponse(IRestResponse res, bool throwErrors = true)
        {
            // Temper detection (signing)

            if (throwErrors)
            {
                if (res == null)
                {
                    throw new Exception("Multilogin API returned null response.");
                }

                if (!res.IsSuccessful)
                {
                    switch (res.StatusCode)
                    {
                        default:
                            throw BuildException(new Exception("Multilogin API failed"), res);

                        case HttpStatusCode.Found:
                            return res;
                    }

                }
            }

            return res;
        }

        #endregion

        public void UpdateRequests(List<DateTime> requests)
        {
            Requests = requests;
        }
        public virtual void OnRequestsUpdated(RequestsUpdateEventArgs e)
        {
            RequestsUpdated?.Invoke(this, e);
        }


        public void UpdateToken(string token)
        {
            this.Token = token;
        }
        public virtual void OnTokenUpdated(TokenUpdatedEventArgs e)
        {
            TokenUpdated?.Invoke(this, e);
        }

        public Request(ref RestClient client, ref Random rnd, string token, int mlaPort, string remoteUrl)
        {
            Requests = new List<DateTime>();
            LocalUrl = new Uri($"http://127.0.0.1:{mlaPort}");
            RemoteUrl = new Uri(remoteUrl);

            RestClient = client;
            Token = token;
            BasePort = mlaPort;
            Rnd = rnd;
        }

    }
}
