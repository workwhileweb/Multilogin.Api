using Multilogin.Api.Things.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Inputs.Creepjs
{
    public partial class LooseFingerprint
    {
        [JsonProperty("workerScope", NullValueHandling = NullValueHandling.Ignore)]
        public WorkerScope WorkerScope { get; set; }

        [JsonProperty("webRTC", NullValueHandling = NullValueHandling.Ignore)]
        public WebRtc WebRtc { get; set; }

        [JsonProperty("navigator", NullValueHandling = NullValueHandling.Ignore)]
        public Navigator Navigator { get; set; }

        [JsonProperty("windowFeatures", NullValueHandling = NullValueHandling.Ignore)]
        public WindowFeatures WindowFeatures { get; set; }

        [JsonProperty("headless", NullValueHandling = NullValueHandling.Ignore)]
        public LooseFingerprintHeadless Headless { get; set; }

        [JsonProperty("htmlElementVersion", NullValueHandling = NullValueHandling.Ignore)]
        public HtmlElementVersion HtmlElementVersion { get; set; }

        [JsonProperty("cssMedia", NullValueHandling = NullValueHandling.Ignore)]
        public CssMedia CssMedia { get; set; }

        [JsonProperty("css", NullValueHandling = NullValueHandling.Ignore)]
        public Css Css { get; set; }

        [JsonProperty("screen", NullValueHandling = NullValueHandling.Ignore)]
        public Screen Screen { get; set; }

        [JsonProperty("voices", NullValueHandling = NullValueHandling.Ignore)]
        public Voices Voices { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public Media Media { get; set; }

        [JsonProperty("canvas2d", NullValueHandling = NullValueHandling.Ignore)]
        public LooseFingerprintCanvas2D Canvas2D { get; set; }

        [JsonProperty("canvasWebgl", NullValueHandling = NullValueHandling.Ignore)]
        public CanvasWebgl CanvasWebgl { get; set; }

        [JsonProperty("maths", NullValueHandling = NullValueHandling.Ignore)]
        public Maths Maths { get; set; }

        [JsonProperty("consoleErrors", NullValueHandling = NullValueHandling.Ignore)]
        public ConsoleErrors ConsoleErrors { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public Timezone Timezone { get; set; }

        [JsonProperty("clientRects", NullValueHandling = NullValueHandling.Ignore)]
        public ClientRects ClientRects { get; set; }

        [JsonProperty("offlineAudioContext", NullValueHandling = NullValueHandling.Ignore)]
        public OfflineAudioContext OfflineAudioContext { get; set; }

        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public Fonts Fonts { get; set; }

        [JsonProperty("lies", NullValueHandling = NullValueHandling.Ignore)]
        public Lies Lies { get; set; }

        [JsonProperty("trash", NullValueHandling = NullValueHandling.Ignore)]
        public Trash Trash { get; set; }

        [JsonProperty("capturedErrors", NullValueHandling = NullValueHandling.Ignore)]
        public CapturedErrors CapturedErrors { get; set; }
    }

    public partial class LooseFingerprintCanvas2D
    {
        [JsonProperty("dataURI", NullValueHandling = NullValueHandling.Ignore)]
        public string DataUri { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class CanvasWebgl
    {
        [JsonProperty("extensions", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Extensions { get; set; }

        [JsonProperty("pixels", NullValueHandling = NullValueHandling.Ignore)]
        public string Pixels { get; set; }

        [JsonProperty("pixels2", NullValueHandling = NullValueHandling.Ignore)]
        public string Pixels2 { get; set; }

        [JsonProperty("dataURI", NullValueHandling = NullValueHandling.Ignore)]
        public string DataUri { get; set; }

        [JsonProperty("dataURI2", NullValueHandling = NullValueHandling.Ignore)]
        public string DataUri2 { get; set; }

        [JsonProperty("webGlParams", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGlParams { get; set; }

        [JsonProperty("webGl2Params", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGl2Params { get; set; }

        [JsonProperty("webGlCustom", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGlCustom { get; set; }

        [JsonProperty("webGL2Custom", NullValueHandling = NullValueHandling.Ignore)]
        public List<Param> WebGL2Custom { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Parameters { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }
    public partial class CapturedErrors
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object[] Data { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class ClientRects
    {
        [JsonProperty("emojiRects", NullValueHandling = NullValueHandling.Ignore)]
        public Rect[] EmojiRects { get; set; }

        [JsonProperty("clientRects", NullValueHandling = NullValueHandling.Ignore)]
        public Rect[] ClientRectsClientRects { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Rect
    {
        [JsonProperty("bottom", NullValueHandling = NullValueHandling.Ignore)]
        public double? Bottom { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public double? Height { get; set; }

        [JsonProperty("left", NullValueHandling = NullValueHandling.Ignore)]
        public double? Left { get; set; }

        [JsonProperty("right", NullValueHandling = NullValueHandling.Ignore)]
        public double? Right { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public double? Width { get; set; }

        [JsonProperty("top", NullValueHandling = NullValueHandling.Ignore)]
        public double? Top { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public double? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public double? Y { get; set; }

        [JsonProperty("emoji", NullValueHandling = NullValueHandling.Ignore)]
        public string Emoji { get; set; }
    }

    public partial class ConsoleErrors
    {
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Errors { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Css
    {
        [JsonProperty("computedStyle", NullValueHandling = NullValueHandling.Ignore)]
        public ComputedStyle ComputedStyle { get; set; }

        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public SystemClass System { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class ComputedStyle
    {
        [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keys { get; set; }

        [JsonProperty("interfaceName", NullValueHandling = NullValueHandling.Ignore)]
        public string InterfaceName { get; set; }
    }

    public partial class SystemClass
    {
        [JsonProperty("colors", NullValueHandling = NullValueHandling.Ignore)]
        public Color[] Colors { get; set; }

        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public Font[] Fonts { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("ActiveBorder", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiveBorder { get; set; }

        [JsonProperty("ActiveCaption", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiveCaption { get; set; }

        [JsonProperty("ActiveText", NullValueHandling = NullValueHandling.Ignore)]
        public string ActiveText { get; set; }

        [JsonProperty("AppWorkspace", NullValueHandling = NullValueHandling.Ignore)]
        public string AppWorkspace { get; set; }

        [JsonProperty("Background", NullValueHandling = NullValueHandling.Ignore)]
        public string Background { get; set; }

        [JsonProperty("ButtonBorder", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonBorder { get; set; }

        [JsonProperty("ButtonFace", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonFace { get; set; }

        [JsonProperty("ButtonHighlight", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonHighlight { get; set; }

        [JsonProperty("ButtonShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonShadow { get; set; }

        [JsonProperty("ButtonText", NullValueHandling = NullValueHandling.Ignore)]
        public string ButtonText { get; set; }

        [JsonProperty("Canvas", NullValueHandling = NullValueHandling.Ignore)]
        public string Canvas { get; set; }

        [JsonProperty("CanvasText", NullValueHandling = NullValueHandling.Ignore)]
        public string CanvasText { get; set; }

        [JsonProperty("CaptionText", NullValueHandling = NullValueHandling.Ignore)]
        public string CaptionText { get; set; }

        [JsonProperty("Field", NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; set; }

        [JsonProperty("FieldText", NullValueHandling = NullValueHandling.Ignore)]
        public string FieldText { get; set; }

        [JsonProperty("GrayText", NullValueHandling = NullValueHandling.Ignore)]
        public string GrayText { get; set; }

        [JsonProperty("Highlight", NullValueHandling = NullValueHandling.Ignore)]
        public string Highlight { get; set; }

        [JsonProperty("HighlightText", NullValueHandling = NullValueHandling.Ignore)]
        public string HighlightText { get; set; }

        [JsonProperty("InactiveBorder", NullValueHandling = NullValueHandling.Ignore)]
        public string InactiveBorder { get; set; }

        [JsonProperty("InactiveCaption", NullValueHandling = NullValueHandling.Ignore)]
        public string InactiveCaption { get; set; }

        [JsonProperty("InactiveCaptionText", NullValueHandling = NullValueHandling.Ignore)]
        public string InactiveCaptionText { get; set; }

        [JsonProperty("InfoBackground", NullValueHandling = NullValueHandling.Ignore)]
        public string InfoBackground { get; set; }

        [JsonProperty("InfoText", NullValueHandling = NullValueHandling.Ignore)]
        public string InfoText { get; set; }

        [JsonProperty("LinkText", NullValueHandling = NullValueHandling.Ignore)]
        public string LinkText { get; set; }

        [JsonProperty("Mark", NullValueHandling = NullValueHandling.Ignore)]
        public string Mark { get; set; }

        [JsonProperty("MarkText", NullValueHandling = NullValueHandling.Ignore)]
        public string MarkText { get; set; }

        [JsonProperty("Menu", NullValueHandling = NullValueHandling.Ignore)]
        public string Menu { get; set; }

        [JsonProperty("MenuText", NullValueHandling = NullValueHandling.Ignore)]
        public string MenuText { get; set; }

        [JsonProperty("Scrollbar", NullValueHandling = NullValueHandling.Ignore)]
        public string Scrollbar { get; set; }

        [JsonProperty("ThreeDDarkShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreeDDarkShadow { get; set; }

        [JsonProperty("ThreeDFace", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreeDFace { get; set; }

        [JsonProperty("ThreeDHighlight", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreeDHighlight { get; set; }

        [JsonProperty("ThreeDLightShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreeDLightShadow { get; set; }

        [JsonProperty("ThreeDShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string ThreeDShadow { get; set; }

        [JsonProperty("VisitedText", NullValueHandling = NullValueHandling.Ignore)]
        public string VisitedText { get; set; }

        [JsonProperty("Window", NullValueHandling = NullValueHandling.Ignore)]
        public string Window { get; set; }

        [JsonProperty("WindowFrame", NullValueHandling = NullValueHandling.Ignore)]
        public string WindowFrame { get; set; }

        [JsonProperty("WindowText", NullValueHandling = NullValueHandling.Ignore)]
        public string WindowText { get; set; }
    }

    public partial class Font
    {
        [JsonProperty("caption", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }

        [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }

        [JsonProperty("menu", NullValueHandling = NullValueHandling.Ignore)]
        public string Menu { get; set; }

        [JsonProperty("message-box", NullValueHandling = NullValueHandling.Ignore)]
        public string MessageBox { get; set; }

        [JsonProperty("small-caption", NullValueHandling = NullValueHandling.Ignore)]
        public string SmallCaption { get; set; }

        [JsonProperty("status-bar", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusBar { get; set; }
    }

    public partial class CssMedia
    {
        [JsonProperty("importCSS", NullValueHandling = NullValueHandling.Ignore)]
        public ImportCssClass ImportCss { get; set; }

        [JsonProperty("mediaCSS", NullValueHandling = NullValueHandling.Ignore)]
        public ImportCssClass MediaCss { get; set; }

        [JsonProperty("matchMediaCSS", NullValueHandling = NullValueHandling.Ignore)]
        public ImportCssClass MatchMediaCss { get; set; }

        [JsonProperty("screenQuery", NullValueHandling = NullValueHandling.Ignore)]
        public ScreenQuery ScreenQuery { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class ImportCssClass
    {
        [JsonProperty("prefers-reduced-motion", NullValueHandling = NullValueHandling.Ignore)]
        public string PrefersReducedMotion { get; set; }

        [JsonProperty("prefers-color-scheme", NullValueHandling = NullValueHandling.Ignore)]
        public string PrefersColorScheme { get; set; }

        [JsonProperty("monochrome", NullValueHandling = NullValueHandling.Ignore)]
        public string Monochrome { get; set; }

        [JsonProperty("forced-colors", NullValueHandling = NullValueHandling.Ignore)]
        public string ForcedColors { get; set; }

        [JsonProperty("any-hover", NullValueHandling = NullValueHandling.Ignore)]
        public string AnyHover { get; set; }

        [JsonProperty("hover", NullValueHandling = NullValueHandling.Ignore)]
        public string Hover { get; set; }

        [JsonProperty("any-pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string AnyPointer { get; set; }

        [JsonProperty("pointer", NullValueHandling = NullValueHandling.Ignore)]
        public string Pointer { get; set; }

        [JsonProperty("device-aspect-ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceAspectRatio { get; set; }

        [JsonProperty("device-screen", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceScreen { get; set; }

        [JsonProperty("display-mode", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayMode { get; set; }

        [JsonProperty("color-gamut", NullValueHandling = NullValueHandling.Ignore)]
        public string ColorGamut { get; set; }

        [JsonProperty("orientation", NullValueHandling = NullValueHandling.Ignore)]
        public string Orientation { get; set; }
    }

    public partial class ScreenQuery
    {
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }
    }

    public partial class Fonts
    {
        [JsonProperty("fonts", NullValueHandling = NullValueHandling.Ignore)]
        public string[] FontsFonts { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class LooseFingerprintHeadless
    {
        [JsonProperty("chromium", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Chromium { get; set; }

        [JsonProperty("likeHeadless", NullValueHandling = NullValueHandling.Ignore)]
        public LikeHeadless LikeHeadless { get; set; }

        [JsonProperty("headless", NullValueHandling = NullValueHandling.Ignore)]
        public HeadlessHeadless Headless { get; set; }

        [JsonProperty("stealth", NullValueHandling = NullValueHandling.Ignore)]
        public Stealth Stealth { get; set; }

        [JsonProperty("likeHeadlessRating", NullValueHandling = NullValueHandling.Ignore)]
        public long? LikeHeadlessRating { get; set; }

        [JsonProperty("headlessRating", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeadlessRating { get; set; }

        [JsonProperty("stealthRating", NullValueHandling = NullValueHandling.Ignore)]
        public long? StealthRating { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class HeadlessHeadless
    {
        [JsonProperty("chrome window.chrome is undefined", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromeWindowChromeIsUndefined { get; set; }

        [JsonProperty("chrome permission state is inconsistent", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromePermissionStateIsInconsistent { get; set; }

        [JsonProperty("userAgent contains HeadlessChrome", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UserAgentContainsHeadlessChrome { get; set; }

        [JsonProperty("worker userAgent contains HeadlessChrome", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WorkerUserAgentContainsHeadlessChrome { get; set; }
    }

    public partial class LikeHeadless
    {
        [JsonProperty("trust token feature is disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TrustTokenFeatureIsDisabled { get; set; }

        [JsonProperty("navigator.webdriver is on", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NavigatorWebdriverIsOn { get; set; }

        [JsonProperty("chrome plugins array is empty", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromePluginsArrayIsEmpty { get; set; }

        [JsonProperty("chrome mimeTypes array is empty", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromeMimeTypesArrayIsEmpty { get; set; }

        [JsonProperty("notification permission is denied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NotificationPermissionIsDenied { get; set; }

        [JsonProperty("chrome system color ActiveText is rgb(255, 0, 0)", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromeSystemColorActiveTextIsRgb25500 { get; set; }

        [JsonProperty("prefers light color scheme", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PrefersLightColorScheme { get; set; }
    }

    public partial class Stealth
    {
        [JsonProperty("srcdoc throws an error", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SrcdocThrowsAnError { get; set; }

        [JsonProperty("srcdoc triggers a window Proxy", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SrcdocTriggersAWindowProxy { get; set; }

        [JsonProperty("index of chrome is too high", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IndexOfChromeIsTooHigh { get; set; }

        [JsonProperty("chrome.runtime functions are invalid", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ChromeRuntimeFunctionsAreInvalid { get; set; }

        [JsonProperty("Permissions.prototype.query leaks Proxy behavior", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PermissionsPrototypeQueryLeaksProxyBehavior { get; set; }

        [JsonProperty("Function.prototype.toString leaks Proxy behavior", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FunctionPrototypeToStringLeaksProxyBehavior { get; set; }

        [JsonProperty("Function.prototype.toString has invalid TypeError", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FunctionPrototypeToStringHasInvalidTypeError { get; set; }
    }

    public partial class HtmlElementVersion
    {
        [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keys { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Lies
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        [JsonProperty("totalLies", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalLies { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Maths
    {
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Acos0123
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public double? Result { get; set; }

        [JsonProperty("chrome", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Chrome { get; set; }

        [JsonProperty("firefox", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Firefox { get; set; }

        [JsonProperty("torBrowser", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TorBrowser { get; set; }

        [JsonProperty("safari", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Safari { get; set; }
    }

    public partial class PolyfillPow2E3100
    {
        [JsonProperty("result", NullValueHandling = NullValueHandling.Ignore)]
        public double[] Result { get; set; }

        [JsonProperty("chrome", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Chrome { get; set; }

        [JsonProperty("firefox", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Firefox { get; set; }

        [JsonProperty("torBrowser", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TorBrowser { get; set; }

        [JsonProperty("safari", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Safari { get; set; }
    }

    public partial class Media
    {
        [JsonProperty("mediaDevices", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MediaDevices { get; set; }

        [JsonProperty("constraints", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Constraints { get; set; }

        [JsonProperty("mimeTypes", NullValueHandling = NullValueHandling.Ignore)]
        public MimeType[] MimeTypes { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class MimeType
    {
        [JsonProperty("mimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string MimeTypeMimeType { get; set; }

        [JsonProperty("audioPlayType", NullValueHandling = NullValueHandling.Ignore)]
        public object AudioPlayType { get; set; }

        [JsonProperty("videoPlayType", NullValueHandling = NullValueHandling.Ignore)]
        public object VideoPlayType { get; set; }

        [JsonProperty("mediaSource", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MediaSource { get; set; }

        [JsonProperty("mediaRecorder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? MediaRecorder { get; set; }
    }

    public partial class Navigator
    {
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public string System { get; set; }

        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public string Device { get; set; }

        [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        [JsonProperty("appVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string AppVersion { get; set; }

        [JsonProperty("deviceMemory", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeviceMemory { get; set; }

        [JsonProperty("doNotTrack")]
        public object DoNotTrack { get; set; }

        [JsonProperty("hardwareConcurrency", NullValueHandling = NullValueHandling.Ignore)]
        public long? HardwareConcurrency { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("maxTouchPoints", NullValueHandling = NullValueHandling.Ignore)]
        public long? MaxTouchPoints { get; set; }

        [JsonProperty("vendor", NullValueHandling = NullValueHandling.Ignore)]
        public string Vendor { get; set; }

        [JsonProperty("mimeTypes", NullValueHandling = NullValueHandling.Ignore)]
        public string[] MimeTypes { get; set; }

        [JsonProperty("plugins", NullValueHandling = NullValueHandling.Ignore)]
        public Plugin[] Plugins { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Properties { get; set; }

        [JsonProperty("highEntropyValues", NullValueHandling = NullValueHandling.Ignore)]
        public HighEntropyValues HighEntropyValues { get; set; }

        [JsonProperty("keyboard", NullValueHandling = NullValueHandling.Ignore)]
        public object Keyboard { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class HighEntropyValues
    {
        [JsonProperty("architecture", NullValueHandling = NullValueHandling.Ignore)]
        public string Architecture { get; set; }

        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("platformVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string PlatformVersion { get; set; }

        [JsonProperty("uaFullVersion", NullValueHandling = NullValueHandling.Ignore)]
        public string UaFullVersion { get; set; }
    }

    

    public partial class Plugin
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
        public string Filename { get; set; }
    }

    public partial class OfflineAudioContext
    {
        [JsonProperty("binsSample", NullValueHandling = NullValueHandling.Ignore)]
        public double[] BinsSample { get; set; }

        [JsonProperty("copySample", NullValueHandling = NullValueHandling.Ignore)]
        public double[] CopySample { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public object Values { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Screen
    {
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public string Device { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public long? Width { get; set; }

        [JsonProperty("outerWidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? OuterWidth { get; set; }

        [JsonProperty("availWidth", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailWidth { get; set; }

        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public long? Height { get; set; }

        [JsonProperty("outerHeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? OuterHeight { get; set; }

        [JsonProperty("availHeight", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvailHeight { get; set; }

        [JsonProperty("colorDepth", NullValueHandling = NullValueHandling.Ignore)]
        public long? ColorDepth { get; set; }

        [JsonProperty("pixelDepth", NullValueHandling = NullValueHandling.Ignore)]
        public long? PixelDepth { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Timezone
    {
        [JsonProperty("zone", NullValueHandling = NullValueHandling.Ignore)]
        public string Zone { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("locationMeasured", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationMeasured { get; set; }

        [JsonProperty("locationEpoch", NullValueHandling = NullValueHandling.Ignore)]
        public long? LocationEpoch { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("offsetComputed", NullValueHandling = NullValueHandling.Ignore)]
        public long? OffsetComputed { get; set; }

        [JsonProperty("lied", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Lied { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Trash
    {
        [JsonProperty("trashBin", NullValueHandling = NullValueHandling.Ignore)]
        public object[] TrashBin { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Voices
    {
        [JsonProperty("voices", NullValueHandling = NullValueHandling.Ignore)]
        public Voice[] VoicesVoices { get; set; }

        [JsonProperty("defaultVoice", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultVoice { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Voice
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
        public string Lang { get; set; }
    }

    public partial class WebRtc
    {
        [JsonProperty("ipaddress", NullValueHandling = NullValueHandling.Ignore)]
        public string Ipaddress { get; set; }

        [JsonProperty("candidate", NullValueHandling = NullValueHandling.Ignore)]
        public string Candidate { get; set; }

        [JsonProperty("connection", NullValueHandling = NullValueHandling.Ignore)]
        public string Connection { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("foundation", NullValueHandling = NullValueHandling.Ignore)]
        //[JsonConverter(typeof(ParseStringConverter))]
        public object Foundation { get; set; }

        [JsonProperty("protocol", NullValueHandling = NullValueHandling.Ignore)]
        public string Protocol { get; set; }

        [JsonProperty("capabilities", NullValueHandling = NullValueHandling.Ignore)]
        public Capabilities Capabilities { get; set; }

        [JsonProperty("sdpcapabilities", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Sdpcapabilities { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class Capabilities
    {
        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public Receiver Sender { get; set; }

        [JsonProperty("receiver", NullValueHandling = NullValueHandling.Ignore)]
        public Receiver Receiver { get; set; }
    }

    public partial class Receiver
    {
        [JsonProperty("audio", NullValueHandling = NullValueHandling.Ignore)]
        public Audio Audio { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public Audio Video { get; set; }
    }

    public partial class Audio
    {
        [JsonProperty("codecs", NullValueHandling = NullValueHandling.Ignore)]
        public Codec[] Codecs { get; set; }

        [JsonProperty("headerExtensions", NullValueHandling = NullValueHandling.Ignore)]
        public HeaderExtension[] HeaderExtensions { get; set; }
    }

    public partial class Codec
    {
        [JsonProperty("channels", NullValueHandling = NullValueHandling.Ignore)]
        public long? Channels { get; set; }

        [JsonProperty("clockRate", NullValueHandling = NullValueHandling.Ignore)]
        public long? ClockRate { get; set; }

        [JsonProperty("mimeType", NullValueHandling = NullValueHandling.Ignore)]
        public string MimeType { get; set; }

        [JsonProperty("sdpFmtpLine", NullValueHandling = NullValueHandling.Ignore)]
        public string SdpFmtpLine { get; set; }
    }

    public partial class HeaderExtension
    {
        [JsonProperty("direction", NullValueHandling = NullValueHandling.Ignore)]
        public object Direction { get; set; }

        [JsonProperty("uri", NullValueHandling = NullValueHandling.Ignore)]
        public string Uri { get; set; }
    }

    public partial class WindowFeatures
    {
        [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keys { get; set; }

        [JsonProperty("apple", NullValueHandling = NullValueHandling.Ignore)]
        public long? Apple { get; set; }

        [JsonProperty("moz", NullValueHandling = NullValueHandling.Ignore)]
        public long? Moz { get; set; }

        [JsonProperty("webkit", NullValueHandling = NullValueHandling.Ignore)]
        public long? Webkit { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class WorkerScope
    {
        [JsonProperty("timezoneOffset", NullValueHandling = NullValueHandling.Ignore)]
        public long? TimezoneOffset { get; set; }

        [JsonProperty("timezoneLocation", NullValueHandling = NullValueHandling.Ignore)]
        public string TimezoneLocation { get; set; }

        [JsonProperty("deviceMemory", NullValueHandling = NullValueHandling.Ignore)]
        public long? DeviceMemory { get; set; }

        [JsonProperty("hardwareConcurrency", NullValueHandling = NullValueHandling.Ignore)]
        public long? HardwareConcurrency { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        [JsonProperty("canvas2d", NullValueHandling = NullValueHandling.Ignore)]
        public WorkerScopeCanvas2D Canvas2D { get; set; }

        [JsonProperty("webglRenderer", NullValueHandling = NullValueHandling.Ignore)]
        public string WebglRenderer { get; set; }

        [JsonProperty("webglVendor", NullValueHandling = NullValueHandling.Ignore)]
        public string WebglVendor { get; set; }

        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public string System { get; set; }

        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public string Device { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("$hash", NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }
    }

    public partial class WorkerScopeCanvas2D
    {
        [JsonProperty("dataURI", NullValueHandling = NullValueHandling.Ignore)]
        public string DataUri { get; set; }
    }
}
