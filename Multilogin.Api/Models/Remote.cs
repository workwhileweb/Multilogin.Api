using Multilogin.Api.Inputs;
using Multilogin.Api.Things;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multilogin.Api.Models
{
    public class Remote : BaseModel
    {
        public Remote(ref RestClient client, ref Random rnd, string token, int mlaPort, string remoteUrl) : base(ref client, ref rnd, token, mlaPort, remoteUrl) { }

        /// <summary>
        /// Get available resolutions
        /// https://indigo.multiloginapp.com/fpb/rest/resolutions
        /// </summary>
        /// <returns>Resolutions</returns>
        public IEnumerable<Resolution> GetResolutions()
        {
            RestRequest restRequest = PrepareRequest("fpb/rest/resolutions", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
            var resolutions = JsonConvert.DeserializeObject<List<List<long>>>(restResponse.Content);

            foreach(var res in resolutions)
            {
                yield return new Resolution(res[0], res[1]);
            }
        }

        /// <summary>
        /// Generate profile with given parameters
        /// https://indigo.multiloginapp.com/fpb/rest/generate
        /// </summary>
        /// <param name="input">Generate Input</param>
        /// <returns>Generated browser profile</returns>
        public Generate GenerateProfile(GenerateInput input)
        {
            RestRequest restRequest = PrepareRequest("fpb/rest/generate", Method.POST, "application/json");
            restRequest.AddJsonBody(input);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
            return JsonConvert.DeserializeObject<Generate>(restResponse.Content);
        }

        /// <summary>
        /// Delete a browser profile
        /// https://indigo.multiloginapp.com/accpmp/rest/ui/v1/session/remove/7641ca09-8fec-40a8-bb2c-564d81184d34
        /// </summary>
        public void DeleteProfile(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"accpmp/rest/ui/v1/session/remove/{profileId}", Method.GET);
            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
        }

        /// <summary>
        /// Get our current profiles on the ML AWS S3 Container
        /// https://indigo.multiloginapp.com/clb/rest/v1/t/d648cd97-a43c-38e8-893b-381fe8a115fa/m/d648cd97-a43c-38e8-893b-381fe8a115fa/p
        /// </summary>
        /// <param name="uid"></param>
        /// <returns>All browser profiles</returns>
        public IEnumerable<Profile> GetProfiles(string uid)
        {
            RestRequest restRequest = PrepareRequest($"clb/rest/v1/t/{uid}/m/{uid}/p", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
            return JsonConvert.DeserializeObject<IEnumerable<Profile>>(restResponse.Content);
        }

        /// <summary>
        /// Get groups
        /// https://indigo.multiloginapp.com/clb/rest/v1/t/d648cd97-a43c-38e8-893b-381fe8a115fa/m/d648cd97-a43c-38e8-893b-381fe8a115fa/g/
        /// </summary>
        /// <param name="uid">User UUID</param>
        /// <returns>All browser groups</returns>
        public IEnumerable<Group> GetGroups(string uid)
        {
            RestRequest restRequest = PrepareRequest($"clb/rest/v1/t/{uid}/m/{uid}/g/", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
            return JsonConvert.DeserializeObject<IEnumerable<Group>>(restResponse.Content);
        }

        /// <summary>
        /// Delete group
        /// </summary>
        /// <param name="groupId">Group ID </param>
        /// <param name="uid">Client UUID</param>
        public void DeleteGroup(string groupId, string uid)
        {
            RestRequest restRequest = PrepareRequest($"/clb/rest/v1/u/{uid}/g/{groupId}", Method.DELETE);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
        }

        /// <summary>
        /// Save group
        /// /clb/rest/v1/u/d648cd97-a43c-38e8-893b-381fe8a115fa/g/6a4bcc6b-4928-4f1b-b545-bcbb843bd5ae
        /// </summary>
        /// <param name="input">Group Input</param>
        /// <param name="groupId">Group Id</param>
        /// <param name="uid">Client UUID</param>
        public void SaveGroup(GroupInput input, string groupId, string uid)
        {
            RestRequest restRequest = PrepareRequest($"/clb/rest/v1/u/{uid}/g/{groupId}", Method.PUT, "application/json");
            restRequest.AddJsonBody(input);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
        }

        /// <summary>
        /// Get the current subscription plan
        /// https://indigo.multiloginapp.com/rest/v1/plans/current
        /// </summary>
        /// <returns>Current subscription plan</returns>
        public CurrentPlan GetCurrentPlan()
        {
            RestRequest restRequest = PrepareRequest($"rest/v1/plans/current", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: RemoteUrl);
            return JsonConvert.DeserializeObject<CurrentPlan>(restResponse.Content);
        }
    }
}
