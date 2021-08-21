using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilogin.Api.Tests.ControllerTests.WorkflowTests
{
    [TestClass]
    public class ProfileTests : BaseTests
    {
        [TestMethod]
        public void CreateRenameDelete()
        {
            // Create
            var profile = client.CreateProfile("test profile", new Guid(), Models.Enums.OS.Windows, Models.Enums.Browser.Mimic, Models.Enums.ProxyType.None);

            Assert.IsNotNull(profile);

            // Rename
            profile.Name = "test renamed";
            profile.Save();

            var newProfile = client.GetProfile(profile.ProfileId);
            newProfile.Load();

            Assert.IsNotNull(newProfile);
            Assert.AreEqual(newProfile.Name, profile.Name);

            // Delete
            profile.Delete();

            // Check if exists in list
            var profiles = client.GetProfiles();
            var profileListing = profiles.Where(x => x.ProfileId == profile.ProfileId).LastOrDefault();

            Assert.IsNull(profileListing);
        }

        [TestMethod]
        public async Task StartAndStopSelenium()
        {
            var profile = client.GetProfiles().LastOrDefault();

            DriverOptions options = null;
            switch (profile.BrowserType)
            {
                case Models.Enums.Browser.Mimic:
                case Models.Enums.Browser.MimicMobile:
                    options = new ChromeOptions();
                    break;

                case Models.Enums.Browser.Stealthfox:
                    options = new FirefoxOptions();
                    break;

            }

            // Visit website and wait 5 seconds
            await profile.Start(options);
            var webDriver = profile.WebDriver;

            webDriver.Url = "https://yahoo.com";
            await Task.Delay(5000);

            await profile.Stop();
            webDriver.Quit();
        }
    }
}
