using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Multilogin.Api.Things
{
    public partial class CurrentPlan
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }

        [JsonProperty("entrySurveyFilled")]
        public bool EntrySurveyFilled { get; set; }

        [JsonProperty("profilesCount")]
        public long ProfilesCount { get; set; }

        [JsonProperty("proxyTunnel")]
        public bool ProxyTunnel { get; set; }

        [JsonProperty("canvasShadow")]
        public bool CanvasShadow { get; set; }

        [JsonProperty("zeroFingerPrints")]
        public bool ZeroFingerPrints { get; set; }

        [JsonProperty("disablePlugins")]
        public bool DisablePlugins { get; set; }

        [JsonProperty("automatitonApi")]
        public bool AutomatitonApi { get; set; }

        [JsonProperty("randomProfile")]
        public bool RandomProfile { get; set; }

        [JsonProperty("loadCustomExtensions")]
        public bool LoadCustomExtensions { get; set; }

        [JsonProperty("sessionSharing")]
        public bool SessionSharing { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("sharingToSameWeight")]
        public bool SharingToSameWeight { get; set; }

        [JsonProperty("sharingToLessWeight")]
        public bool SharingToLessWeight { get; set; }

        [JsonProperty("sharingPermissionsFromBiggerWeight")]
        public bool SharingPermissionsFromBiggerWeight { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tagRestrictedAccess")]
        public bool TagRestrictedAccess { get; set; }

        [JsonProperty("mimic")]
        public bool Mimic { get; set; }

        [JsonProperty("stealthfox")]
        public bool Stealthfox { get; set; }

        [JsonProperty("firefox")]
        public bool Firefox { get; set; }

        [JsonProperty("chromium")]
        public bool Chromium { get; set; }

        [JsonProperty("storeLs")]
        public bool StoreLs { get; set; }

        [JsonProperty("storeExtensions")]
        public bool StoreExtensions { get; set; }

        [JsonProperty("startUrl")]
        public bool StartUrl { get; set; }

        [JsonProperty("disableBrowserNotifications")]
        public bool DisableBrowserNotifications { get; set; }

        [JsonProperty("proxyPlugins")]
        public bool ProxyPlugins { get; set; }

        [JsonProperty("disabledFields")]
        public List<DisabledField> DisabledFields { get; set; }

        [JsonProperty("forceUpdate")]
        public bool ForceUpdate { get; set; }

        [JsonProperty("showSubscribeOnboarding")]
        public bool ShowSubscribeOnboarding { get; set; }

        [JsonProperty("showDemo")]
        public bool ShowDemo { get; set; }

        [JsonProperty("createProfileDisabled")]
        public bool CreateProfileDisabled { get; set; }

        [JsonProperty("generateFpDisabled")]
        public bool GenerateFpDisabled { get; set; }

        [JsonProperty("naturalCanvas")]
        public bool NaturalCanvas { get; set; }

        [JsonProperty("clbTransferAllowed")]
        public bool ClbTransferAllowed { get; set; }

        [JsonProperty("collaborationMember")]
        public bool CollaborationMember { get; set; }

        [JsonProperty("maxMembers")]
        public long MaxMembers { get; set; }

        [JsonProperty("helpChat")]
        public bool HelpChat { get; set; }

        [JsonProperty("showSessionLockModal")]
        public bool ShowSessionLockModal { get; set; }

        [JsonProperty("accpmpState")]
        public long AccpmpState { get; set; }

        [JsonProperty("clbMigrationState")]
        public long ClbMigrationState { get; set; }
    }

    public partial class DisabledField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("value")]
        public bool Value { get; set; }

        [JsonProperty("skipServerValidation")]
        public bool SkipServerValidation { get; set; }
    }
}
