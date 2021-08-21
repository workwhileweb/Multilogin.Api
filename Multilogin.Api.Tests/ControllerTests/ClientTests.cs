using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multilogin.Api.Inputs.Creepjs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Multilogin.Api.Tests.ControllerTests
{
    [TestClass]
    public class ClientTests : BaseTests
    {

        [TestMethod]
        public void GetGroups()
        {
            var groups = client.GetGroups();

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public void GetProfiles()
        {
            var profiles = client.GetProfiles();

            Assert.IsNotNull(profiles);
        }

        [TestMethod]
        public void CreateProfile()
        {
            var profile = client.CreateProfile("test profile", new Guid(), Models.Enums.OS.Android, Models.Enums.Browser.MimicMobile, Models.Enums.ProxyType.None);

            Assert.IsNotNull(profile);
            Assert.IsTrue(!string.IsNullOrEmpty(profile.ProfileId));
        }

        [TestMethod]
        public void ImportCreepJsProfile()
        {
            var profilePath = GetResourceFilePath("CreepJsLooseFingerprint.json");
            var profileInput = JsonConvert.DeserializeObject<LooseFingerprint>(File.ReadAllText(profilePath));

            var profile = client.ImportCreepJsProfile("cloned profile", new Guid(), profileInput);

            Assert.IsNotNull(profile);
            Assert.IsTrue(!string.IsNullOrEmpty(profile.ProfileId));
        }

        [TestMethod]
        public void CreateGroup()
        {
            var group = client.CreateGroup("test group");

            Assert.IsNotNull(group);
            Assert.IsTrue(!string.IsNullOrEmpty(group.GroupId));
        }

    }
}
