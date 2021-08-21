using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Tests.ControllerTests
{
    [TestClass]
    public class ProfileTests : BaseTests
    {

        [TestMethod]
        public void Share()
        {
            var profiles = client.GetProfiles();
            var randomProfile = profiles.LastOrDefault();

            // Needs a valid email to pass --Dev
            randomProfile.Share("admin@google.com");
        }

        [TestMethod]
        public void Clone()
        {
            var profiles = client.GetProfiles();
            var randomProfile = profiles.LastOrDefault();

            var profile = randomProfile.Clone();

            Assert.IsNotNull(profile);
            Assert.IsTrue(!string.IsNullOrEmpty(profile.ProfileId));
        }

    }
}
