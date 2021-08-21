using Microsoft.VisualStudio.TestTools.UnitTesting;
using Multilogin.Api.Inputs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Tests.ModelTests.WorkflowTests
{
    [TestClass]
    public class LocalTests : BaseTests
    {
        [TestMethod]
        public void StartAndStopProfile()
        {
            client.Models.Local.StartProfile(profileId);

            System.Threading.Thread.Sleep(5000);

            var profiles = client.Models.Local.GetRunningProfiles();

            Assert.IsNotNull(profiles);
            Assert.IsNotNull(profiles.Count > 0);

            var startedProfile = profiles.Where(x => x.Key == profileId).FirstOrDefault();

            Assert.IsNotNull(startedProfile);
            Assert.IsTrue(startedProfile.Value == "RUNNING");
            Assert.IsTrue(client.Models.Local.CheckProfileRunning(profileId));

            client.Models.Local.StopProfile(profileId);
        }

        [TestMethod]
        [Obsolete]
        public void StartAndStopSessionProcess()
        {
            client.Models.Local.OpenSession(profileId);

            System.Threading.Thread.Sleep(5000);

            var profiles = client.Models.Local.GetRunningProfiles();

            Assert.IsNotNull(profiles);
            Assert.IsNotNull(profiles.Count > 0);

            var startedProfile = profiles.Where(x => x.Key == profileId).FirstOrDefault();

            Assert.IsNotNull(startedProfile);
            Assert.IsTrue(startedProfile.Value == "RUNNING");
            Assert.IsTrue(client.Models.Local.CheckProfileRunning(profileId));

            client.Models.Local.CloseProcess(profileId);
        }

        [TestMethod]
        public void SaveAndDeleteProfile()
        {
            var defaultProfile = client.Models.Local.GetProfile("00000000-0000-0000-0000-000000000000", new Inputs.ProfileInput());

            Assert.IsNotNull(defaultProfile);

            var profilePath = GetResourceFilePath("SampleProfile.json");
            var profileInput = JsonConvert.DeserializeObject<ProfileInput>(File.ReadAllText(profilePath));

            // Override default
            profileInput.KeyData = defaultProfile.KeyData;
            profileInput.Sid = null;

            // Save
            client.Models.Local.SaveProfile(profileInput, client.Models.Uuid);

            var profiles = client.Models.Remote.GetProfiles(client.Models.Uuid);

            // Check if any available
            var profileCount = profiles.Count();
            Assert.IsTrue(profileCount > 0);

            // Delete newly created one
            var currentProfile = profiles.LastOrDefault();
            client.Models.Remote.DeleteProfile(currentProfile.Sid.ToString());

            // Check if one less
            profiles = client.Models.Remote.GetProfiles(client.Models.Uuid);
            Assert.IsTrue(profileCount - 1 == profiles.Count());
        }

        [TestMethod]
        public void SaveAndDeleteGroup()
        {
            client.Models.Local.CreateGroup(new GroupInput() { Name = "test" }, client.Models.Uuid);

            var groups = client.Models.Remote.GetGroups(client.Models.Uuid);

            // Count
            var groupCount = groups.Count();
            Assert.IsTrue(groupCount > 0);

            // Delete newly created one
            var currentGroup = groups.LastOrDefault();
            client.Models.Remote.DeleteGroup(currentGroup.Sid.ToString(), client.Models.Uuid);

            // Check if one less
            groups = client.Models.Remote.GetGroups(client.Models.Uuid);
            Assert.IsTrue(groupCount - 1 == groups.Count());
        }

    }
}
