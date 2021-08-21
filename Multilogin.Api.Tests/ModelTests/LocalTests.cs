using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multilogin.Api.Inputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Tests.ModelTests
{
    [TestClass]
    public class LocalTests : BaseTests
    {
        
        [TestMethod]
        public void GetProfile()
        {
            var profile = client.Models.Local.GetProfile("00000000-0000-0000-0000-000000000000", new Inputs.ProfileInput());

            Assert.IsNotNull(profile);
        }

        [TestMethod]
        public void SaveSession()
        {
            client.Models.Local.SaveSession("cf4629a3-c17c-46cf-ade5-24f1c36ef638", "mimic", new SaveInput());
        }

        [TestMethod]
        public void CloneProfile()
        {
            var clonedProfiles = client.Models.Local.CloneProfile("cf4629a3-c17c-46cf-ade5-24f1c36ef638");

            Assert.IsNotNull(clonedProfiles);
            Assert.IsTrue(clonedProfiles.Count > 0);
        }

        [TestMethod]
        public void ShareProfile()
        {
            // Needs a valid email to pass --Dev
            client.Models.Local.ShareProfile("cf4629a3-c17c-46cf-ade5-24f1c36ef638", "admin@google.com");
        }

        [TestMethod]
        public void GetRandomFonts()
        {
            var fonts = client.Models.Local.GetRandomFonts("mimic");

            Assert.IsNotNull(fonts);
            Assert.IsTrue(fonts.Count() > 0);
        }

        [TestMethod]
        public void GetScreenResolution()
        {
            var resolution = client.Models.Local.GetScreenResolution();

            Assert.IsNotNull(resolution);
        }

        [TestMethod]
        public void GetAvailableSystemFonts()
        {
            var fonts = client.Models.Local.GetAvailableSystemFonts();

            Assert.IsNotNull(fonts);
            Assert.IsTrue(fonts.Count() > 0);
        }

        [TestMethod]
        public void GetPersistentFonts()
        {
            var fonts = client.Models.Local.GetPersistentFonts();

            Assert.IsNotNull(fonts);
            Assert.IsTrue(fonts.Windows.Length > 0);
            Assert.IsTrue(fonts.Mac.Length > 0);
            Assert.IsTrue(fonts.Linux.Length > 0);
        }

        [TestMethod]
        public void GetBrowserTypeVersions()
        {
            var browserVersions = client.Models.Local.GetBrowserTypeVersions();

            Assert.IsNotNull(browserVersions);
            Assert.IsTrue(browserVersions.Count() > 0);
        }

        [TestMethod]
        public void GetApiToken()
        {
            var apiToken = client.Models.Local.GetApiToken();

            Assert.IsTrue(!string.IsNullOrEmpty(apiToken));
        }
    }
}
