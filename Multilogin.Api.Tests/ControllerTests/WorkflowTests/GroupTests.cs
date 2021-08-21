using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Tests.ControllerTests.WorkflowTests
{
    [TestClass]
    public class GroupTests : BaseTests
    {
        [TestMethod]
        public void CreateRenameDelete()
        {
            // Create
            var group = client.CreateGroup("test profile");

            Assert.IsNotNull(group);

            // Rename
            group.Name = "test renamed";
            group.Save();

            var newGroup = client.GetGroup(group.GroupId);
            newGroup.Load();

            Assert.IsNotNull(newGroup);
            Assert.AreEqual(newGroup.Name, group.Name);

            // Delete
            group.Delete();

            // Check if exists in list
            var groups = client.GetGroups();
            var groupListing = groups.Where(x => x.GroupId == group.GroupId).LastOrDefault();

            Assert.IsNull(groupListing);
        }
        

    }
}
