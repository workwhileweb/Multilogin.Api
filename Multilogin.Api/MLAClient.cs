using Multilogin.Api.Things;
using Multilogin.Api.Inputs;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Multilogin.Api.Controllers;
using Multilogin.Api.Models.Enums;
using Multilogin.Api.Things.Base;
using System.Text.RegularExpressions;
using TimeZoneConverter;
using System.Runtime.InteropServices;

namespace Multilogin.Api
{
    public class MLAClient
    {
        /// <summary>
        /// Endpoint wrapper
        /// </summary>
        public Dispatch Models;

        /// <summary>
        /// MLA Client
        /// </summary>
        /// <param name="mlaPort">MLA port (Default: 35000)</param>
        /// <param name="remoteUrl">Remote URL (app/indigo)</param>
        /// <param name="token">MLA token (optional; gets grabbed automatically otherwise)</param>
        public MLAClient(int mlaPort = 35000, string remoteUrl = "https://indigo.multiloginapp.com", string mlaToken = null)
        {
            Models = new Dispatch(new RestClient(), new Random(), mlaPort, remoteUrl, mlaToken);
            Models.Uuid = CurrentPlan.Uid.ToString();
        }

        #region Controllers (Logic Instances)

        public IEnumerable<Things.Resolution> Resolutions
        {
            get
            {
                if (resolutions == null)
                    resolutions = Models.Remote.GetResolutions();

                return resolutions;
            }
        }

        private IEnumerable<Things.Resolution> resolutions;

        public Things.Resolution LocalResolution
        {
            get
            {
                if (localResolution == null)
                    localResolution = Models.Local.GetScreenResolution();

                return localResolution;
            }
        }

        private Things.Resolution localResolution;

        public IEnumerable<Things.BrowserTypeVersion> BrowserTypeVersions
        {
            get
            {
                if (browserTypeVersions == null)
                    browserTypeVersions = Models.Local.GetBrowserTypeVersions();

                return browserTypeVersions;
            }
        }

        private IEnumerable<Things.BrowserTypeVersion> browserTypeVersions;

        /// <summary>
        /// Persistant Fonts
        /// </summary>
        public Things.PersistentFonts PersistentFonts
        {
            get
            {
                if (persistentFonts == null)
                    persistentFonts = Models.Local.GetPersistentFonts();

                return persistentFonts;
            }
        }

        private Things.PersistentFonts persistentFonts;

        /// <summary>
        /// Current subscription plan
        /// Updates every 5 minutes
        /// </summary>
        public Things.CurrentPlan CurrentPlan
        {
            get
            {
                return (currentPlan != null
                       && currentPlanLastUpdated.Value.AddMinutes(5) > DateTime.Now ? currentPlan : GetPlan());
            }
            set
            {
                currentPlan = value;
            }
        }

        private Things.CurrentPlan currentPlan;

        private DateTime? currentPlanLastUpdated { get; set; }

        /// <summary>
        /// Retrieve current subscription plan
        /// </summary>
        /// <returns></returns>
        private Things.CurrentPlan GetPlan()
        {
            var plan = Models.Remote.GetCurrentPlan();

            currentPlanLastUpdated = DateTime.Now;
            currentPlan = plan;

            return plan;
        }


        /// <summary>
        /// Retrieve all groups
        /// </summary>
        /// <returns>All groups</returns>
        public IEnumerable<Controllers.Group> GetGroups()
        {
            var groups = Models.Remote.GetGroups(Models.Uuid);

            foreach (var group in groups)
            {
                yield return new Controllers.Group(Models, group);
            }
        }

        /// <summary>
        /// Get specific group
        /// </summary>
        /// <param name="groupId">Group id</param>
        /// <returns>Group</returns>
        public Controllers.Group GetGroup(string groupId)
        {
            return new Controllers.Group(Models, groupId);
        }

        /// <summary>
        /// Retrieve all profiles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Controllers.Profile> GetProfiles()
        {
            var profiles = Models.Remote.GetProfiles(Models.Uuid);

            foreach (var profile in profiles)
            {
                yield return new Controllers.Profile(Models, profile);
            }
        }

        /// <summary>
        /// Get specific profile
        /// </summary>
        /// <param name="profileId">Browser profile id</param>
        /// <returns>Profile</returns>
        public Controllers.Profile GetProfile(string profileId)
        {
            return new Controllers.Profile(Models, profileId);
        }

        /// <summary>
        /// Creates a new profile
        /// Overview and Proxy need to be set, everything else is optional (auto-generated)
        /// </summary>
        /// <param name="name">Name of the profile</param>
        /// <param name="group">Group Id of the profile</param>
        /// <param name="os">Target OS</param>
        /// <param name="browser">Target Browser</param>
        /// <param name="proxyType">Proxy Protocol</param>
        /// <param name="proxyIp">Proxy IP</param>
        /// <param name="proxyPort">Proxy Port</param>
        /// <param name="proxyUser">Proxy Username</param>
        /// <param name="proxyPass">Proxy Password</param>
        /// <param name="tzFillOnStart">Fill timezone on browser profile start based on the external IP</param>
        /// <param name="tzAbbr">Timezone Abbrevation (e.g. Africa/Addis_Ababa)</param>
        /// <param name="tzOffset">Timezone offset (e.g. EAT +0300)</param>
        /// <param name="webRtcType">WebRTC Behaviour</param>
        /// <param name="webrtcPubIpFillOnStart">Fill WebRTC Public IP on browser profile start based on the external IP.</param>
        /// <param name="webRtcPubIp">WebRTC Public IP (if <see cref="webrtcPubIpFillOnStart"/> is disabled) </param>
        /// <param name="webrtcLocalIpInReal">Enable Local IP Masking</param>
        /// <param name="webRtcLocalIps">Local IPs (Example: 192.168.0.132;192.168.0.216)</param>
        /// <param name="geoPermitType">Geolocation Behavior</param>
        /// <param name="geoFillOnStart">Fill geolocation coordinates on browser profile start based on the external IP</param>
        /// <param name="geoAccuracy">Accuracy (meters)</param>
        /// <param name="geoLatitude">Latitude (Example: 40.6856954)</param>
        /// <param name="geoLongitude">Longitude (Example: -74.0209128)</param>
        /// <param name="navUserAgent">User-Agent</param>
        /// <param name="screenWidth">Screen Width (Example: 1920)</param>
        /// <param name="screenHeight">Screen Height (Example: 1080)</param>
        /// <param name="langHdr">Accept-Language (Example: en-US,en;q=0.9)</param>
        /// <param name="platform">Platform (Example: MacIntel)</param>
        /// <param name="doNotTrack">DoNotTrack</param>
        /// <param name="hardwareConcurrency">HardwareConcurrency</param>
        /// <param name="maskFonts">Enable font list masking</param>
        /// <param name="fonts">Browser profile fonts list</param>
        /// <param name="maskMediaDevices">Mask media devices</param>
        /// <param name="mediaDevicesAudioInputs">Media devices: Audio inputs</param>
        /// <param name="mediaDevicesAudioOutputs">Media devices: Audio outputs</param>
        /// <param name="mediaDevicesVideoInputs">Media devices: Video outputs</param>
        /// <param name="canvasDefType">Canvas</param>
        /// <param name="useAudioNoise">AudioContext</param>
        /// <param name="webglCnv">WebGL image</param>
        /// <param name="webglMeta">WebGL metadata</param>
        /// <param name="webGlVendor">WebGL vendor</param>
        /// <param name="webGlRenderer">WebGL renderer</param>
        /// <param name="webGlParams">WebGL context</param>
        /// <param name="webGl2Params">WebGL2 context</param>
        /// <param name="storeLs">Enable Local Storage and IndexedDB</param>
        /// <param name="storeExtensions">Enable Extension storage</param>
        /// <param name="storeServiceWorkerCache">Enable Service Worker cache</param>
        /// <param name="storeBookmarks">Enable browser bookmark saving</param>
        /// <param name="storeHistory">Enable browser history saving</param>
        /// <param name="storePasswords">Enable password saving</param>
        /// <param name="enableVulnerablePlugins">Enable potentially vulnerable plugins (AdobePDF, Widevine, and Native Client)</param>
        /// <param name="enableFlashPlugin">Enable Flash plugin</param>
        /// <param name="forbidConcurrentExecution">Active session lock</param>
        /// <param name="googleServices">Enable Google services (experimental)</param>
        /// <param name="dns">Custom DNS</param>
        /// <param name="localPortsProtection">Enable Port Scan protection</param>
        /// <param name="localPortsExclude">Ports allowed for scanning (comma seperated)</param>
        /// <returns>Profile to work with</returns>
        public Controllers.Profile CreateProfile(
            string name, Guid group, OS os, Browser browser, // overview
            ProxyType proxyType = ProxyType.None, string proxyIp = null, int? proxyPort = null, string proxyUser = null, string proxyPass = null, // proxy
            bool? tzFillOnStart = null, string tzAbbr = null, string tzOffset = null, // timezone
            WebRtcType? webRtcType = null, bool? webrtcPubIpFillOnStart = null, string webRtcPubIp = null, bool? webrtcLocalIpInReal = null, string webRtcLocalIps = null, // webrtc
            GeoPermitType? geoPermitType = null, bool? geoFillOnStart = null, int? geoAccuracy = null, float? geoLatitude = null, float? geoLongitude = null,  // geolocation
            string navUserAgent = null, long? screenWidth = null, long? screenHeight = null, string langHdr = null, string platform = null, DoNotTrack? doNotTrack = null, int? hardwareConcurrency = null, // advanced - navigator
            bool? maskFonts = null, List<string> fonts = null,  // advanced - fonts
            bool? maskMediaDevices = null, int? mediaDevicesAudioInputs = null, int? mediaDevicesAudioOutputs = null, int? mediaDevicesVideoInputs = null, // advanced - media devices
            CanvasDefType? canvasDefType = null, bool? useAudioNoise = null, bool? webglCnv = null, bool? webglMeta = null, string webGlVendor = null, string webGlRenderer = null, List<Param> webGlParams = null, List<Param> webGl2Params = null,  // advanced - hardware
            bool? storeLs = null, bool? storeExtensions = null, bool? storeServiceWorkerCache = null, bool? storeBookmarks = null, bool? storeHistory = null, bool? storePasswords = null, // advanced - storage options
            bool? enableVulnerablePlugins = null, bool? enableFlashPlugin = null, // advanced - browser plugins
            bool? forbidConcurrentExecution = null, bool? googleServices = null, string dns = null, bool? localPortsProtection = null, List<int> localPortsExclude = null // advanced - other
            )
        {
            var browserTypes = BrowserTypeVersions.ToList();
            var browserData = browserTypes.Where(x => x.Type == browser).FirstOrDefault();

            // Default input (customize what we need)
            var defaultInput = new Inputs.ProfileInput()
            {
                MediaDevicesVideoInputs = mediaDevicesVideoInputs == null ? Models.Rnd.Next(0, 1) : mediaDevicesVideoInputs,
                MediaDevicesAudioInputs = mediaDevicesAudioInputs == null ? Models.Rnd.Next(1, 4) : mediaDevicesAudioInputs,
                MediaDevicesAudioOutputs = mediaDevicesAudioOutputs == null ? Models.Rnd.Next(1, 4) : mediaDevicesAudioOutputs,
            };

            // Map keyData into defaultInput
            var defaultProfile = Models.Local.GetProfile("00000000-0000-0000-0000-000000000000", defaultInput);
            var input = new Inputs.GenerateInput()
            {
                Os = os,
                MaxWidth = 5120,
                MaxHeight = 2880,
                MinWidth = 1024,
                MinHeight = 600,
                NativeWidth = LocalResolution.Width,
                NativeHeight = LocalResolution.Height,
                Browser = browser,
                Versions = new Inputs.Versions()
                {
                    MinVersion = browserData.MinVersion,
                    MaxVersion = browserData.MaxVersion,
                },
                Language = "en-US",
            };
            var generatedProfile = Models.Remote.GenerateProfile(input);

            #region Map generated profile

            // Navigator
            defaultProfile.Container.NavUserAgent = generatedProfile.Navigator.UserAgent;
            defaultProfile.Container.Navigator.HardwareConcurrency = generatedProfile.Navigator.HardwareConcurrency;
            defaultProfile.Container.Navigator.Platform = generatedProfile.Navigator.Platform;
            defaultProfile.Container.Navigator.MaxTouchPoints = generatedProfile.Navigator.MaxTouchPoints;
            defaultProfile.Container.Navigator.BuildId = generatedProfile.Navigator.BuildId;
            defaultProfile.Container.Navigator.OsCPU = generatedProfile.Navigator.OsCPU;

            // Screen
            defaultProfile.Container.ScrWidth = generatedProfile.Screen.Width;
            defaultProfile.Container.ScrHeight = generatedProfile.Screen.Height;
            // missing: pixelratio

            // Webgl
            defaultProfile.Container.WebGlParams = generatedProfile.Webgl.Params;

            // Webgl2
            defaultProfile.Container.WebGl2Params = generatedProfile.Webgl2.Params;
            defaultProfile.Container.WebGlVendor = generatedProfile.Webgl2.UnmaskedVendor;
            defaultProfile.Container.WebGlRenderer = generatedProfile.Webgl2.UnmaskedRenderer;

            // Languages
            // missing: acceptlanguage

            if (os == OS.Android)
            {
                defaultProfile.Fonts = generatedProfile.Fonts;
            }
            else
            {
                var randomFonts = Models.Local.GetRandomFonts(browser.GetBrowserRequestName()).ToList();

                switch (os)
                {
                    case OS.Windows:
                        randomFonts.AddRange(PersistentFonts.Windows);
                        break;
                    case OS.MacOS:
                        randomFonts.AddRange(PersistentFonts.Mac);
                        break;
                    case OS.Linux:
                        randomFonts.AddRange(PersistentFonts.Linux);
                        break;
                }

                defaultProfile.Fonts = randomFonts;
            }

            // WebRtcLocalIps
            defaultProfile.Container.WebRtcLocalIps = generatedProfile.WebRtcLocalIps;

            #endregion

            #region Set settings

            // Overview
            defaultProfile.Name = name;
            defaultProfile.GroupId = group;
            defaultProfile.OsType = os;
            defaultProfile.BrowserType = browserData.Type;
            defaultProfile.BrowserTypeVersion = browserData.TypeVersion;
            defaultProfile.Sid = null;

            // Proxy
            if (proxyType != ProxyType.None)
            {
                defaultProfile.ProxyChanged = true;
                defaultProfile.ProxyType = proxyType;
                defaultProfile.ProxyHost = proxyIp;
                defaultProfile.ProxyPort = (int)proxyPort;
                defaultProfile.ProxyUser = proxyUser;
                defaultProfile.ProxyPass = proxyPass;
            }

            // Timezone
            if(tzFillOnStart != null)
                defaultProfile.TzFillOnStart = tzFillOnStart;

            if(tzAbbr != null)
                defaultProfile.Container.TzAbbr = tzAbbr;

            if(tzOffset != null)
                defaultProfile.Container.TzOffset = tzOffset;

            // WebRTC 
            if (webRtcType != null)
                defaultProfile.WebRtcType = webRtcType;
            else
                defaultProfile.WebRtcType = WebRtcType.Altered;

            if (webrtcPubIpFillOnStart != null)
                defaultProfile.WebrtcPubIpFillOnStart = webrtcPubIpFillOnStart;

            if (webRtcPubIp != null)
                defaultProfile.Container.WebrtcPubIp = webRtcPubIp;

            if (webrtcLocalIpInReal != null)
                defaultProfile.WebrtcLocalIpInReal = webrtcLocalIpInReal;

            if (webRtcLocalIps != null)
                defaultProfile.Container.WebRtcLocalIps = webRtcLocalIps;

            // Geolocation
            if (geoPermitType != null)
                defaultProfile.GeoPermitType = geoPermitType;
            else
                defaultProfile.GeoPermitType = GeoPermitType.Prompt;

            if (geoFillOnStart != null)
                defaultProfile.GeoFillOnStart = geoFillOnStart;

            if(geoAccuracy != null)
                defaultProfile.GeoAccuracy = geoAccuracy;

            if (geoLatitude != null)
                defaultProfile.GeoLatitude = geoLatitude;

            if(geoLongitude != null)
                defaultProfile.GeoLongitude = geoLongitude;

            // Navigator
            if (navUserAgent != null)
                defaultProfile.Container.NavUserAgent = navUserAgent;

            if(screenWidth != null)
                defaultProfile.Container.ScrWidth = screenWidth;

            if (screenHeight != null)
                defaultProfile.Container.ScrHeight = screenHeight;

            if (langHdr != null)
                defaultProfile.Container.Navigator.LangHdr = langHdr;

            if (platform != null)
                defaultProfile.Container.Navigator.Platform = platform;

            if (doNotTrack != null)
                defaultProfile.Container.Navigator.DoNotTrack = doNotTrack == DoNotTrack.NotSet ? null : doNotTrack;
            else
                defaultProfile.Container.Navigator.DoNotTrack = DoNotTrack.Off;

            if (hardwareConcurrency != null)
                defaultProfile.Container.Navigator.HardwareConcurrency = hardwareConcurrency;

            // Fonts
            if (maskFonts != null)
                defaultProfile.MaskFonts = maskFonts;

            if (fonts != null)
                defaultProfile.Fonts = fonts;

            // Media devices
            if(maskMediaDevices != null)
                defaultProfile.MaskMediaDevices = maskMediaDevices;

            // Hardware
            if(canvasDefType != null)
                defaultProfile.CanvasDefType = canvasDefType;
            else
                defaultProfile.CanvasDefType = null;

            defaultProfile.UseCanvasNoise = defaultProfile.CanvasDefType == CanvasDefType.Noise;

            if (useAudioNoise != null)
                defaultProfile.UseAudioContextNoise = useAudioNoise;
            else
                defaultProfile.UseAudioContextNoise = true;

            if (webglCnv != null)
                defaultProfile.WebglImage = webglCnv;
            else
                defaultProfile.WebglImage = true;

            if (webglMeta != null)
                defaultProfile.WebglMetadata = webglMeta;
            else
                defaultProfile.WebglMetadata = true;

            if(webGlVendor != null)
                defaultProfile.Container.WebGlVendor = webGlVendor;

            if (webGlRenderer != null)
                defaultProfile.Container.WebGlRenderer = webGlRenderer;

            if (webGlParams != null)
                defaultProfile.Container.WebGlParams = webGlParams;

            if (webGl2Params != null)
                defaultProfile.Container.WebGl2Params = webGl2Params;

            // Storage options
            if (storeLs != null)
                defaultProfile.StoreLs = storeLs;
            else
                defaultProfile.StoreLs = true;

            if(storeExtensions != null)
                defaultProfile.StoreExtensions = storeExtensions;
            else
                defaultProfile.StoreExtensions = true;

            if(storeServiceWorkerCache != null)
                defaultProfile.StoreExtensions = storeServiceWorkerCache;

            if (storeBookmarks != null)
                defaultProfile.StoreBookmarks = storeBookmarks;

            if(storeHistory != null)
                defaultProfile.StoreHistory = storeHistory;

            if(storePasswords != null)
                defaultProfile.StorePasswords = storePasswords;

            // Browser plugins
            if (enableVulnerablePlugins != null)
                defaultProfile.DisablePlugins = !enableVulnerablePlugins;

            if (enableFlashPlugin != null)
                defaultProfile.DisableFlashPlugin = !enableFlashPlugin;

            defaultProfile.CustomExtensionFileNames = string.Empty;
            defaultProfile.LoadCustomExtensions = false;

            // Other
            if (forbidConcurrentExecution != null)
                defaultProfile.ForbidConcurrentExecution = forbidConcurrentExecution;
            else
                defaultProfile.ForbidConcurrentExecution = false;

            if (googleServices != null)
                defaultProfile.GoogleServices = googleServices;

            if (dns != null)
                defaultProfile.CustomDns = dns;

            if (localPortsProtection != null)
                defaultProfile.LocalPortsProtection = localPortsProtection;

            if (localPortsExclude != null)
                defaultProfile.LocalPortsExclude = localPortsExclude;

            // Internal
            defaultProfile.EditPermissionType = null;
            var randomLetter = Models.Rnd.GetRandomLetter().ToString();
            defaultProfile.FallbackFont = randomLetter;

            #endregion

            var profile = new Controllers.Profile(Models);
            profile.Import(defaultProfile);
            profile.Save();

            var profileListing = Models.Remote.GetProfiles(Models.Uuid).LastOrDefault();
            profile.Import(profileListing);

            return profile;
        }


        /// <summary>
        /// Create a group
        /// </summary>
        /// <param name="name">Group name</param>
        /// <returns>Group Controller</returns>
        public Controllers.Group CreateGroup(string name)
        {
            Models.Local.CreateGroup(new Inputs.GroupInput() { Name = name }, Models.Uuid);

            var groupListing = Models.Remote.GetGroups(Models.Uuid).LastOrDefault();
            var group = new Controllers.Group(Models, groupListing);

            return group;
        }

        /// <summary>
        /// Grab operating system from useragent
        /// </summary>
        /// <param name="useragent">Useragent</param>
        /// <returns>OS of useragent</returns>
        private OS GetOS(string useragent)
        {
            if(new Regex("windows phone", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if(new Regex("win(dows|16|32|64|95|98|nt)|wow64", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Windows;
            }
            else if (new Regex("android", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("cros", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("linux", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Linux;
            }
            else if (new Regex("ipad", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("iphone", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("ipod", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("ios", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.Android;
            }
            else if (new Regex("mac", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return OS.MacOS;
            }
            else
            {
                return GetRealOS();
            }
        }

        /// <summary>
        /// Grab your real OS
        /// </summary>
        /// <returns>Local computer operation system</returns>
        private OS GetRealOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return OS.Windows;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return OS.MacOS;
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
                return OS.Linux;

            return OS.Windows;
        }

        /// <summary>
        /// Grab browser from OS and/or useragent
        /// </summary>
        /// <param name="operationSystem">Operating System</param>
        /// <param name="useragent">User Agent</param>
        /// <returns>Suitable Browser in MLA</returns>
        private Browser GetBrowser(OS operationSystem, string useragent)
        {
            if (operationSystem == OS.Android)
                return Browser.MimicMobile;

            if(new Regex("Firefox", RegexOptions.IgnoreCase).IsMatch(useragent))
            {
                return Browser.Stealthfox;
            }
            else
            {
                return Browser.Mimic;
            }
        
        }

        /// <summary>
        /// Copy somebody elses fingerprint through creepjs
        /// </summary>
        /// <returns>1:1 Fingerprint Profile</returns>
        public Controllers.Profile ImportCreepJsProfile(string name, Guid group, Inputs.Creepjs.LooseFingerprint fingerprint,
            ProxyType proxyType = ProxyType.None, string proxyIp = null, int? proxyPort = null, string proxyUser = null, string proxyPass = null)
        {
            var os = GetOS(fingerprint.Navigator.UserAgent);
            var browser = GetBrowser(os, fingerprint.Navigator.UserAgent);

            var browserData = BrowserTypeVersions.Where(x => x.Type == browser).FirstOrDefault();

            // Map keyData into defaultInput
            var defaultProfile = Models.Local.GetProfile("00000000-0000-0000-0000-000000000000", new Inputs.ProfileInput());

            var input = new Inputs.GenerateInput()
            {
                Os = os,
                MaxWidth = (long)fingerprint.Screen.Width,
                MaxHeight = (long)fingerprint.Screen.Height,
                MinWidth = (long)fingerprint.Screen.Width,
                MinHeight = (long)fingerprint.Screen.Height,
                NativeWidth = LocalResolution.Width,
                NativeHeight = LocalResolution.Height,
                Browser = browser,
                Versions = new Inputs.Versions()
                {
                    MinVersion = browserData.MinVersion,
                    MaxVersion = browserData.MaxVersion,
                },
                Language = fingerprint.Navigator.Language,
            };
            var generatedProfile = Models.Remote.GenerateProfile(input);

            // audioNoiseHash, fontsHash, webglNoiseHash gets generated server side; so we just spoof them accordingly...

            var profileInput = new ProfileInput()
            {
                EditPermissionType = null,
                Sid = null,
                Container = new Container()
                {
                    WebGlVendor = fingerprint.WorkerScope.WebglVendor, // UNMASKED_VENDOR_WEBGL
                    WebGlRenderer = fingerprint.WorkerScope.WebglRenderer, // UNMASKED_RENDERER_WEBGL
                    WebGlParams = fingerprint.CanvasWebgl.WebGlParams.Concat(fingerprint.CanvasWebgl.WebGlCustom).ToList(),
                    WebGl2Params = fingerprint.CanvasWebgl.WebGl2Params.Concat(fingerprint.CanvasWebgl.WebGL2Custom).ToList(),
                    ScrWidth = fingerprint.Screen.Width,
                    ScrHeight = fingerprint.Screen.Height,
                    WebrtcPubIp = fingerprint.WebRtc.Ipaddress,
                    WebRtcLocalIps = generatedProfile.WebRtcLocalIps,
                    NavUserAgent = fingerprint.Navigator.UserAgent,
                    TzAbbr = fingerprint.WorkerScope.TimezoneLocation,
                    TzOffset = TZConvert.GetTimeZoneInfo(fingerprint.WorkerScope.TimezoneLocation).GetUtcOffset(DateTime.UtcNow).HoursAndMinutes(),
                    Navigator = new Inputs.Navigator()
                    {
                        Platform = fingerprint.Navigator.Platform,
                        HardwareConcurrency = fingerprint.Navigator.HardwareConcurrency,
                        LangHdr = fingerprint.WorkerScope.Language,
                        DoNotTrack = (DoNotTrack?)fingerprint.Navigator.DoNotTrack,
                        MaxTouchPoints = fingerprint.Navigator.MaxTouchPoints,
                        //BuildId = fingerprint.Navigator.BuildId, // TODO
                        //OsCPU = fingerprint.Navigator.OsCPU, // TODO
                    }
                },
                GroupId = group,
                Name = name,
                BrowserType = browserData.Type,
                BrowserTypeVersion = browserData.TypeVersion,
                KeyData = defaultProfile.KeyData,
                DisablePlugins = true,
                MaskWebRtc = true,
                WebRtcType = WebRtcType.Altered,
                WebrtcPubIpFillOnStart = false,
                WebrtcLocalIpInReal = null,
                DisableFlashPlugin = true,
                StoreExtensions = true,
                StoreLs = true,
                StorePasswords = true,
                StoreHistory = false,
                StoreBookmarks = false,
                StoreServiceWorkerCache = false,
                UseCanvasNoise = !(GetRealOS() == os),
                CanvasDefType = (GetRealOS() == os) ? (CanvasDefType?)Helper.ReturnNull() : CanvasDefType.Noise, // noise will create unique canvas (win/mac use 87% same canvas; linux probably too..)
                UseFingerprintsShadow = false, // on create this is false
                ForbidConcurrentExecution = false,
                UseAudioContextNoise = true,
                UseWebglNoise = false, // why is this always disabled?
                WebglImage = true,
                WebglMetadata = true,
                MaskFonts = true,
                MaskFontGlyphs = false,
                UseGeoSpoofing = true,
                GeoPermitType = GeoPermitType.Prompt,
                GeoFillOnStart = true,
                GeoAccuracy = null,
                GeoLatitude = null,
                GeoLongitude = null,
                MaskMediaDevices = true,
                MediaDevicesAudioInputs = fingerprint.Media.MediaDevices.Where(x => x.Contains("audioinput")).Count(),
                MediaDevicesAudioOutputs = fingerprint.Media.MediaDevices.Where(x => x.Contains("audiooutput")).Count(),
                MediaDevicesVideoInputs = fingerprint.Media.MediaDevices.Where(x => x.Contains("videoinput")).Count(),
                OsType = os,
                TzFillOnStart = false,
                OfflineProfile = false,
                GoogleServices = false,
                LocalPortsProtection = true,
                LocalPortsExclude = new List<int>(),
                FallbackFont = Models.Rnd.GetRandomLetter().ToString(),
                Fonts = fingerprint.Fonts.FontsFonts.ToList(),
                ProxyChanged = null,
                ProxyHost = proxyIp,
                ProxyPort = proxyPort,
                ProxyUser = proxyUser,
                ProxyPass = proxyPass,
                ProxyIpValidation = null,
                ProxyType = proxyType,
                LoadCustomExtensions = false,
                CustomExtensionFileNames = string.Empty,
                CustomDns = string.Empty,
            };

            var profile = new Controllers.Profile(Models, profileInput);
            profile.Save();

            var profileListing = Models.Remote.GetProfiles(Models.Uuid).LastOrDefault();
            profile.Import(profileListing);

            return profile;
        }

        #endregion
    }
}

