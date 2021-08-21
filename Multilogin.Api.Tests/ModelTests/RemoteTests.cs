using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Tests.ModelTests
{
    [TestClass]
    public class RemoteTests : BaseTests
    {
        [TestMethod]
        public void GetResolutions()
        {
            var resolutions = client.Models.Remote.GetResolutions();

            Assert.IsNotNull(resolutions);
            Assert.IsTrue(resolutions.Count() > 0);
        }

        [TestMethod]
        public void GenerateProfile()
        {
            var input = new Inputs.GenerateInput()
            {
                Os = Models.Enums.OS.Windows,
                MaxWidth = 5120,
                MaxHeight = 2880,
                MinWidth = 1024,
                MinHeight = 600,
                NativeWidth = 1920,
                NativeHeight = 1080,
                Browser = Models.Enums.Browser.Mimic,
                Versions = new Inputs.Versions()
                {
                    MinVersion = 86,
                    MaxVersion = 88,
                },
                Language = "en-US",
            };

            var generatedOutput = client.Models.Remote.GenerateProfile(input);

            Assert.IsNotNull(generatedOutput);
        }

        [TestMethod]
        public void GetProfiles()
        {
            var profiles = client.Models.Remote.GetProfiles(client.Models.Uuid);

            Assert.IsNotNull(profiles);
            Assert.IsTrue(profiles.Count() > 0);
        }

        [TestMethod]
        public void GetGroups()
        {
            var groups = client.Models.Remote.GetGroups(client.Models.Uuid);

            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Count() > 0);
        }

        [TestMethod]
        public void GetCurrentPlan()
        {
            var currentPlan = client.Models.Remote.GetCurrentPlan();

            Assert.IsNotNull(currentPlan);
        }

    }
}
