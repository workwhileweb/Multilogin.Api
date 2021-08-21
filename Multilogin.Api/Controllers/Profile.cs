using Multilogin.Api.Models.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilogin.Api.Controllers
{
    /// <summary>
    /// Profile Controller
    /// </summary>
    public class Profile : BaseController
    {
        internal Dispatch Dispatch;

        #region Constructor
        public Profile(Dispatch dispatch)
        {
            Dispatch = dispatch;
        }

        public Profile(Dispatch dispatch, Inputs.ProfileInput listing)
        {
            Dispatch = dispatch;
            Import(listing);
        }

        public Profile(Dispatch dispatch, Things.Profile listing)
        {
            Dispatch = dispatch;
            Import(listing);
        }

        public Profile(Dispatch dispatch, string profileId)
        {
            Dispatch = dispatch;
            ProfileId = profileId;
        }

        public void Import(Things.Profile listing)
        {
            ProfileId = listing.Uuid.ToString();
            Name = listing.Name;
            BrowserType = listing.BrowserType;
            Updated = listing.Updated;

            Listing = listing;
        }

        /// <summary>
        /// Used to save a profile
        /// </summary>
        /// <param name="container"></param>
        public void Import(Inputs.ProfileInput container)
        {
            ProfileId = container.Sid?.ToString();
            Name = container.Name;
            BrowserType = container.BrowserType;
            // no updated

            Container = container;
        }

        /// <summary>
        /// Load profile data (if profile id is provided)
        /// </summary>
        public void Load()
        {
            Import(Container);
        }

        #endregion

        #region Data

        public string ProfileId { get; set; }

        public Browser BrowserType { get; private set; }

        public string Name { get; set; }

        public DateTimeOffset Updated { get; private set; }

        public Group Group 
        {
            get
            {
                var groupId = Container.GroupId;

                if (group == null && groupId != null && !string.IsNullOrEmpty(ProfileId))
                    group = new Group(Dispatch, groupId.ToString());
                   
                return group;
            }
            set
            {
                group = value;
            }
        }

        private Group group;

        /// <summary>
        /// Store listing information
        /// </summary>

        public Things.Profile Listing { get; set; }

        /// <summary>
        /// Store profile fingerprint, lazy-load if necessary
        /// </summary>
        public Inputs.ProfileInput Container
        {
            get
            {
                if (container == null && !string.IsNullOrEmpty(ProfileId))
                    container = Dispatch.Local.GetProfile(ProfileId, new Inputs.ProfileInput());

                return container;
            }
            set
            {
                container = value;
            }
        }

        private Inputs.ProfileInput container;

        public bool IsRunning
        {
            get
            {
                return Dispatch.Local.CheckProfileRunning(ProfileId);
            }
        }

        /// <summary>
        /// Available if you start with automation enabled
        /// </summary>
        public RemoteWebDriver WebDriver;

        #endregion

        /// <summary>
        /// Start profile and make sure its loaded
        /// </summary>
        public async Task Start(DriverOptions options = null)
        {
            if (string.IsNullOrEmpty(ProfileId))
                throw new Exception("Specify a profile id first");

            bool isLoaded = false;
            bool enableSelenium = options != null;
            while (!isLoaded)
            {
                var remoteUrl = Dispatch.Local.StartProfile(ProfileId, automation: enableSelenium);

                if (enableSelenium)
                    WebDriver = new RemoteWebDriver(new Uri(remoteUrl), options);

                await Task.Delay(5000);

                isLoaded = Dispatch.Local.CheckProfileRunning(ProfileId);
            }
            
        }

        /// <summary>
        /// Stop profile and make sure its gone
        /// </summary>
        public async Task Stop()
        {
            if (string.IsNullOrEmpty(ProfileId))
                throw new Exception("Specify a profile id first");

            // Save tabs
            if(WebDriver != null)
            {
                List<string> tabs = new List<string>();

                // Visit every tab, save url
                foreach(var handle in WebDriver.WindowHandles)
                {
                    WebDriver.SwitchTo().Window(handle);

                    var url = WebDriver.Url;
                    if (!string.IsNullOrWhiteSpace(url) && !url.Contains("local.app.multiloginapp.com"))
                        tabs.Add(url);
                }

                // Save tabs for next session
                Dispatch.Local.SaveSession(ProfileId, BrowserType.GetBrowserRequestName(), new Inputs.SaveInput() { Tabs = tabs } );
            }

            // Close it
            bool isLoaded = true;
            while (isLoaded)
            {
                Dispatch.Local.StopProfile(ProfileId);
                await Task.Delay(5000);

                isLoaded = Dispatch.Local.CheckProfileRunning(ProfileId);
            }
        }

        /// <summary>
        /// Save the browser profile
        /// </summary>
        public void Save()
        {
            Container.Name = Name;

            if(!string.IsNullOrEmpty(ProfileId))
                container.Sid = new Guid(ProfileId);

            Dispatch.Local.SaveProfile(Container, Dispatch.Uuid);
        }

        /// <summary>
        /// Delete the browser profile
        /// </summary>
        public void Delete()
        {
            if (string.IsNullOrEmpty(ProfileId))
                throw new Exception("Specify a profile id first");

            Dispatch.Remote.DeleteProfile(ProfileId);
        }

        /// <summary>
        /// Share browser profile
        /// </summary>
        /// <param name="email"></param>
        public void Share(string email)
        {
            if (string.IsNullOrEmpty(ProfileId))
                throw new Exception("Specify a profile id first");

            Dispatch.Local.ShareProfile(ProfileId, email);
        }

        /// <summary>
        /// Clone browser profile
        /// </summary>
        public Profile Clone()
        {
            if (string.IsNullOrEmpty(ProfileId))
                throw new Exception("Specify a profile id first");

            var clonedProfileId = Dispatch.Local.CloneProfile(ProfileId).FirstOrDefault();

            return new Profile(Dispatch, clonedProfileId);
        }
    }
}
