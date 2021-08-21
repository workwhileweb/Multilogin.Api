using Multilogin.Api.Inputs;
using Multilogin.Api.Models.Enums;
using Multilogin.Api.Things;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Multilogin.Api.Models
{
    public class Local : BaseModel
    {
        public Local(ref RestClient client, ref Random rnd, string token, int mlaPort, string remoteUrl) : base(ref client, ref rnd, token, mlaPort, remoteUrl) { }

        /// <summary>
        /// Crate default input for saving profiles
        /// http://127.0.0.1:35000/clb/p/00000000-0000-0000-0000-000000000000
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ProfileInput GetProfile(string profileId, ProfileInput input)
        {
            RestRequest restRequest = PrepareRequest($"clb/p/{profileId}", Method.POST, "application/json");
            restRequest.AddJsonBody(input);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            return JsonConvert.DeserializeObject<ProfileInput>(restResponse.Content);
        }

        /// <summary>
        /// http://127.0.0.1:35000/mimic/s/cf4629a3-c17c-46cf-ade5-24f1c36ef638
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        /// <param name="browser">Browser Name</param>
        /// <param name="input">Tabs to save</param>
        public void SaveSession(string profileId, string browser, Inputs.SaveInput input)
        {
            RestRequest restRequest = PrepareRequest($"{browser}/s/{profileId}", Method.POST, "text/plain");
            restRequest.AddJsonBody(input);

            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Clone browser profile
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        /// <returns>Cloned Browser Profile Id(s)</returns>
        public List<string> CloneProfile(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"api/v1/profile/clone?profileId={profileId}", Method.GET);
            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);

            var data = JsonConvert.DeserializeObject<BaseResult>(restResponse.Content);
            var clonedProfiles = JsonConvert.DeserializeObject<List<string>>(data?.Value.ToString());

            return clonedProfiles;
        }

        /// <summary>
        /// Share browser profile
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        /// <param name="user">Multilogin account (email address) to share profile with</param>
        public void ShareProfile(string profileId, string user)
        {
            RestRequest restRequest = PrepareRequest($"api/v1/profile/share?profileId={profileId}&user={user}", Method.GET);
            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Check if profile is already running
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        /// <returns>Profile is already launched</returns>
        public bool CheckProfileRunning(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"api/v1/profile/active?profileId={profileId}", Method.GET);
            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);

            var data = JsonConvert.DeserializeObject<BaseResult>(restResponse.Content);

            return Convert.ToBoolean(data?.Value);
        }

        /// <summary>
        /// Open a profile
        /// Equivalent to pressing start button
        /// http://127.0.0.1:35000/session/open/3300b222-1501-481a-b156-8ad91ac97ec1
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        [Obsolete("OpenSession does not provide any advantage over StartProfile")]
        public void OpenSession(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"session/open/{profileId}", Method.GET);
            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Launch browser profile
        /// http://127.0.0.1:35000/api/v1/profile/start?automation=true&pupeteer=true&profileId=cf4629a3-c17c-46cf-ade5-24f1c36ef638
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        /// <param name="loadTabs">If set to true, tabs from previous session will open</param>
        /// <param name="automation">Set to true to launch profile with Selenium/Puppeteer</param>
        /// <param name="pupeteer">Set to true to launch profile with Puppeteer automation</param>
        /// <returns>Remote URL for RemoteWebDriver (if automation param is true)</returns>
        public string StartProfile(string profileId, bool loadTabs = true, bool automation = false, bool pupeteer = false)
        {
            RestRequest restRequest = PrepareRequest($"api/v1/profile/start?automation={automation}&loadTabs={loadTabs}&pupeteer={pupeteer}&profileId={profileId}", Method.GET);
            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);

            var data = JsonConvert.DeserializeObject<BaseResult>(restResponse.Content);

            return Convert.ToString(data?.Value);
        }

        /// <summary>
        /// Stop browser profile
        /// http://127.0.0.1:35000/api/v1/profile/stop?profileId=cf4629a3-c17c-46cf-ade5-24f1c36ef638
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        public void StopProfile(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"api/v1/profile/stop?profileId={profileId}", Method.GET);
            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Close a profile
        /// http://127.0.0.1:35000/closeProcess/3300b222-1501-481a-b156-8ad91ac97ec1
        /// </summary>
        /// <param name="profileId">Browser profile ID</param>
        [Obsolete("CloseProcess does not provide any advantage over StopProfile")]
        public void CloseProcess(string profileId)
        {
            RestRequest restRequest = PrepareRequest($"closeProcess/{profileId}", Method.GET);
            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Save/Update a profile
        /// http://127.0.0.1:35000/clb/t/d648cd97-a43c-38e8-893b-381fe8a115fa/m/d648cd97-a43c-38e8-893b-381fe8a115fa/p/save
        /// </summary>
        /// <param name="input">Profile input</param>
        /// <param name="uid">User UUID</param>
        public void SaveProfile(ProfileInput input, string uid)
        {
            RestRequest restRequest = PrepareRequest($"clb/t/{uid}/m/{uid}/p/save", Method.POST, "application/json");
            restRequest.AddJsonBody(input);

            ExecuteRequest(restRequest, domain: LocalUrl);
        }


        /// <summary>
        /// Create a browser group
        /// http://127.0.0.1:39005/clb/u/d648cd97-a43c-38e8-893b-381fe8a115fa/g/
        /// </summary>
        /// <param name="input">Group input</param>
        /// <param name="uid">User UUID</param>
        public void CreateGroup(GroupInput input, string uid)
        {
            RestRequest restRequest = PrepareRequest($"clb/u/{uid}/g", Method.POST, "application/json");
            restRequest.AddJsonBody(input);

            ExecuteRequest(restRequest, domain: LocalUrl);
        }

        /// <summary>
        /// Get all running browser profiles
        /// http://127.0.0.1:35000/sessions/get-running
        /// </summary>
        /// <returns>Dictionary with profileid and status (DOWNLOADING, RUNNING, SYNCING)</returns>
        public Dictionary<string, string> GetRunningProfiles()
        {
            RestRequest restRequest = PrepareRequest($"sessions/get-running", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            var data =  JsonConvert.DeserializeObject<BaseResult>(restResponse.Content);
            var runningProfiles = JsonConvert.DeserializeObject<RunningProfiles>(data.Value.ToString());

            return runningProfiles.Profiles;


        }

        /// <summary>
        /// Get random fonts
        /// Used before saving
        /// </summary>
        /// <param name="browser">Browser Name</param>
        /// <returns>Random fonts for specific browser</returns>
        public IEnumerable<string> GetRandomFonts(string browser)
        {
            RestRequest restRequest = PrepareRequest($"{browser}/random_fonts", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            return JsonConvert.DeserializeObject<IEnumerable<string>>(restResponse.Content);
        }


        /// <summary>
        /// Get screen resolution
        /// http://127.0.0.1:31629/bridge/systemScreenResolution
        /// </summary>
        /// <returns>System resolution</returns>
        public Resolution GetScreenResolution()
        {
            RestRequest restRequest = PrepareRequest($"bridge/systemScreenResolution", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            var data = Convert.ToString(JsonConvert.DeserializeObject<BaseResult>(restResponse.Content).Value);
            var value = data.Split(',');
            return new Resolution(Convert.ToInt64(value[0]), Convert.ToInt64(value[1]));
        }

        /// <summary>
        /// Get system fonts
        /// http://127.0.0.1:31629/bridge/availableSystemFonts
        /// </summary>
        /// <returns>Available system fonts</returns>
        public IEnumerable<string> GetAvailableSystemFonts()
        {
            RestRequest restRequest = PrepareRequest($"bridge/availableSystemFonts", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            var data = Convert.ToString(JsonConvert.DeserializeObject<BaseResult>(restResponse.Content).Value);

            return JsonConvert.DeserializeObject<IEnumerable<string>>(data);
        }

        /// <summary>
        /// Get persistent font
        /// http://127.0.0.1:31629/bridge/persistentFonts
        /// </summary>
        /// <returns>Persistent Fonts</returns>
        public PersistentFonts GetPersistentFonts()
        {
            RestRequest restRequest = PrepareRequest($"bridge/persistentFonts", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            return JsonConvert.DeserializeObject<PersistentFonts>(restResponse.Content);
        }

        /// <summary>
        /// Get browser type versions
        /// http://127.0.0.1:31629/bridge/browserTypeVersions
        /// </summary>
        /// <returns>Browser Type Versions</returns>
        public IEnumerable<BrowserTypeVersion> GetBrowserTypeVersions()
        {
            RestRequest restRequest = PrepareRequest($"bridge/browserTypeVersions", Method.GET);

            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);
            var data = Convert.ToString(JsonConvert.DeserializeObject<BaseResult>(restResponse.Content).Value);

            var versions = JsonConvert.DeserializeObject<List<List<long>>>(data);

            for (int i = 0; i < versions.Count; i++)
            {
                var browserData = versions[i];

                yield return new BrowserTypeVersion()
                {
                    Type = (Browser)browserData[0],
                    TypeVersion = browserData[1],
                    Version = browserData[2],
                    MinVersion = browserData[3],
                    MaxVersion = browserData[4],

                };
            } 
        }

        /// <summary>
        /// Get api token
        /// http://127.0.0.1:57015/bridge/apiToken
        /// </summary>
        /// <returns>Client API Token</returns>
        public string GetApiToken()
        {
            RestRequest restRequest = PrepareRequest($"bridge/apiToken", Method.GET);
            var restResponse = ExecuteRequest(restRequest, domain: LocalUrl);

            var data = JsonConvert.DeserializeObject<BaseResult>(restResponse.Content);

            return Convert.ToString(data?.Value);
        }

    }
}
