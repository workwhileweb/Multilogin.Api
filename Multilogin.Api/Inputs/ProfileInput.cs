using Multilogin.Api.Models.Enums;
using Multilogin.Api.Things.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Inputs
{

    public partial class ProfileInput
    {
        [JsonProperty("editPermissionType", NullValueHandling = NullValueHandling.Ignore)]
        public long? EditPermissionType { get; set; } = 1;

        /// <summary>
        /// UUID of this profile
        /// </summary>
        [JsonProperty("sid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Sid { get; set; } = new Guid();

        [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
        public Container Container { get; set; } = new Inputs.Container()
        {
            Navigator = new Inputs.Navigator()
            {
                LangHdr = "en-US,en;q=0.9",
            },
            ScrWidth = 1920,
            ScrHeight = 1080,
        };

        /// <summary>
        /// GroupId of this profile
        /// </summary>
        [JsonProperty("groupId", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? GroupId { get; set; } = new Guid();

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("browserType")]
        public Browser BrowserType { get; set; } = Browser.Mimic;

        [JsonProperty("browserTypeVersion", NullValueHandling = NullValueHandling.Ignore)]
        public long? BrowserTypeVersion { get; set; }

        [JsonProperty("keyData", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyData { get; set; }

        [JsonProperty("disablePlugins", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisablePlugins { get; set; } = true;

        [JsonProperty("maskWebRtc", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MaskWebRtc { get; set; } = true;

        [JsonProperty("webRtcType", NullValueHandling = NullValueHandling.Ignore)]
        public WebRtcType? WebRtcType { get; set; } = Models.Enums.WebRtcType.Disabled;

        [JsonProperty("webrtcPubIpFillOnStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WebrtcPubIpFillOnStart { get; set; } = true;

        [JsonProperty("webrtcLocalIpInReal", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WebrtcLocalIpInReal { get; set; }

        [JsonProperty("disableFlashPlugin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisableFlashPlugin { get; set; } = true;

        [JsonProperty("storeExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreExtensions { get; set; } = false;

        [JsonProperty("storeLs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreLs { get; set; } = false;

        [JsonProperty("storePasswords", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StorePasswords { get; set; } = false;

        [JsonProperty("storeHistory", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreHistory { get; set; } = false;

        [JsonProperty("storeBookmarks", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreBookmarks { get; set; } = false;

        [JsonProperty("storeServiceWorkerCache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StoreServiceWorkerCache { get; set; } = false;

        /// <summary>
        /// Enabled if type is not off
        /// </summary>
        [JsonProperty("useCanvasNoise", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseCanvasNoise { get; set; } = false;

        /// <summary>
        /// Null if type == Off (0)
        /// </summary>
        [JsonProperty("canvasDefType", NullValueHandling = NullValueHandling.Include)]
        public CanvasDefType? CanvasDefType { get; set; } = Models.Enums.CanvasDefType.Off;

        [JsonProperty("useFingerprintsShadow", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseFingerprintsShadow { get; set; }

        [JsonProperty("forbidConcurrentExecution", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ForbidConcurrentExecution { get; set; } = true;

        [JsonProperty("useAudioNoise", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseAudioContextNoise { get; set; }

        [JsonProperty("useWebglNoise", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseWebglNoise { get; set; }

        [JsonProperty("webglCnv", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WebglImage { get; set; }

        [JsonProperty("webglMeta", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WebglMetadata { get; set; }

        [JsonProperty("maskFonts", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MaskFonts { get; set; } = true;

        [JsonProperty("maskFontGlyphs", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MaskFontGlyphs { get; set; } = false;

        [JsonProperty("useGeoSpoofing", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseGeoSpoofing { get; set; } = true;

        [JsonProperty("geoPermitType", NullValueHandling = NullValueHandling.Ignore)]
        public GeoPermitType? GeoPermitType { get; set; } = Models.Enums.GeoPermitType.Block;

        [JsonProperty("geoFillOnStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GeoFillOnStart { get; set; } = true;

        [JsonProperty("geoAccuracy", NullValueHandling = NullValueHandling.Ignore)]
        public int? GeoAccuracy { get; set; }

        [JsonProperty("geoLatitude", NullValueHandling = NullValueHandling.Ignore)]
        public float? GeoLatitude { get; set; }

        [JsonProperty("geoLongitude", NullValueHandling = NullValueHandling.Ignore)]
        public float? GeoLongitude { get; set; }

        [JsonProperty("maskMediaDevices", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MaskMediaDevices { get; set; } = true;

        [JsonProperty("mediaDevicesAudioInputs", NullValueHandling = NullValueHandling.Ignore)]
        public long? MediaDevicesAudioInputs { get; set; } = 2;

        [JsonProperty("mediaDevicesAudioOutputs", NullValueHandling = NullValueHandling.Ignore)]
        public long? MediaDevicesAudioOutputs { get; set; } = 4;

        [JsonProperty("mediaDevicesVideoInputs", NullValueHandling = NullValueHandling.Ignore)]
        public long? MediaDevicesVideoInputs { get; set; } = 1;

        [JsonProperty("osType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public OS OsType { get; set; } = OS.Windows;

        [JsonProperty("tzFillOnStart", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TzFillOnStart { get; set; } = true;

        [JsonProperty("offlineProfile", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OfflineProfile { get; set; } = false;

        [JsonProperty("googleServices", NullValueHandling = NullValueHandling.Ignore)]
        public bool? GoogleServices { get; set; } = false;

        [JsonProperty("localPortsProtection", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LocalPortsProtection { get; set; } = true;

        [JsonProperty("localPortsExclude", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> LocalPortsExclude { get; set; } = new List<int>();

        [JsonProperty("fallbackFont", NullValueHandling = NullValueHandling.Ignore)]
        public string FallbackFont { get; set; }

        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Fonts { get; set; }

        [JsonProperty("proxyChanged", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProxyChanged { get; set; }

        [JsonProperty("proxyHost", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyHost { get; set; }

        [JsonProperty("proxyPort", NullValueHandling = NullValueHandling.Ignore)]
        public int? ProxyPort { get; set; }

        [JsonProperty("proxyUser", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyUser { get; set; }

        [JsonProperty("proxyPass", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyPass { get; set; }

        [JsonProperty("proxyIpValidation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ProxyIpValidation { get; set; }

        [JsonProperty("proxyType", NullValueHandling = NullValueHandling.Ignore)]
        public ProxyType? ProxyType { get; set; }

        [JsonProperty("loadCustomExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public bool? LoadCustomExtensions { get; set; }

        [JsonProperty("customExtensionFileNames", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomExtensionFileNames { get; set; }

        [JsonProperty("dns", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomDns { get; set; }
    }

    public partial class Container
    {
        [JsonProperty("audioNoiseHash", NullValueHandling = NullValueHandling.Ignore)]
        public string AudioNoiseHash { get; set; }

        [JsonProperty("fontsHash", NullValueHandling = NullValueHandling.Ignore)]
        public string FontsHash { get; set; }

        [JsonProperty("webglNoiseHash", NullValueHandling = NullValueHandling.Ignore)]
        public string WebglNoiseHash { get; set; }

        [JsonProperty("webGlVendor", NullValueHandling = NullValueHandling.Ignore)]
        public string WebGlVendor { get; set; }

        [JsonProperty("webGlRenderer", NullValueHandling = NullValueHandling.Ignore)]
        public string WebGlRenderer { get; set; }

        [JsonProperty("webGlParams", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGlParams { get; set; }

        [JsonProperty("webGl2Params", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGl2Params { get; set; }

        [JsonProperty("scrWidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScrWidth { get; set; }

        [JsonProperty("scrHeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScrHeight { get; set; }

        [JsonProperty("tzAbbr", NullValueHandling = NullValueHandling.Ignore)]
        public string TzAbbr { get; set; }

        [JsonProperty("tzOffset", NullValueHandling = NullValueHandling.Ignore)]
        public string TzOffset { get; set; }

        [JsonProperty("webRtcLocalIps", NullValueHandling = NullValueHandling.Ignore)]
        public string WebRtcLocalIps { get; set; }

        [JsonProperty("webRtcPubIp", NullValueHandling = NullValueHandling.Ignore)]
        public string WebrtcPubIp { get; set; }

        [JsonProperty("navUserAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string NavUserAgent { get; set; }

        [JsonProperty("navigator", NullValueHandling = NullValueHandling.Ignore)]
        public Navigator Navigator { get; set; }
    }

    public partial class Navigator
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("hardwareConcurrency", NullValueHandling = NullValueHandling.Ignore)]
        public long? HardwareConcurrency { get; set; }

        [JsonProperty("langHdr", NullValueHandling = NullValueHandling.Ignore)]
        public string LangHdr { get; set; }

        [JsonProperty("doNotTrack", NullValueHandling = NullValueHandling.Include)]
        public DoNotTrack? DoNotTrack { get; set; }

        [JsonProperty("maxTouchPoints", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxTouchPoints { get; set; }

        [JsonProperty("buildID", NullValueHandling = NullValueHandling.Ignore)]
        public long? BuildId { get; set; }

        [JsonProperty("oscpu", NullValueHandling = NullValueHandling.Ignore)]
        public string OsCPU { get; set; }
    }
}
