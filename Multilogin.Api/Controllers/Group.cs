using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multilogin.Api.Controllers
{
    /// <summary>
    /// Group Controller
    /// </summary>
    public class Group : BaseController
    {
        internal Dispatch Dispatch;

        public Group(Dispatch dispatch, Things.Group listing)
        {
            Dispatch = dispatch;
            Import(listing);
        }

        public Group(Dispatch dispatch, string groupId)
        {
            Dispatch = dispatch;
            GroupId = groupId;
        }

        /// <summary>
        /// Load group by id
        /// The only way is through the group list
        /// </summary>
        public void Load()
        {
            var groups = Dispatch.Remote.GetGroups(Dispatch.Uuid);
            var currentGroup = groups.Where(x => x.Sid.ToString() == GroupId).FirstOrDefault();

            Import(currentGroup);
        }

        #region Data


        /// <summary>
        /// Listing can only be imorted
        /// </summary>
        public Things.Group Listing { get; set; }

        /// <summary>
        /// Import listing into group controller
        /// </summary>
        /// <param name="listing">Group listing (data)</param>
        public void Import(Things.Group listing)
        {
            GroupId = listing.Uuid.ToString();
            Name = listing.Name;

            Listing = listing;
        }

        /// <summary>
        /// Group Id
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// Group Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Get all browser profiles within this group
        /// </summary>
        public IEnumerable<Profile> Profiles
        {
            get
            {
                var profiles = Dispatch.Remote.GetProfiles(Dispatch.Uuid).Where(x => x.Group.ToString() == GroupId);

                foreach (var profile in profiles)
                {
                    yield return new Controllers.Profile(Dispatch, profile);
                }
            }
        }

        #endregion

        /// <summary>
        /// Save group
        /// </summary>
        public void Save()
        {
            if (string.IsNullOrEmpty(GroupId))
                throw new Exception("Specify a group id first");

            Dispatch.Remote.SaveGroup(new Inputs.GroupInput() { Name = this.Name, Uuid = new Guid(GroupId) }, GroupId, Dispatch.Uuid);
        }

        /// <summary>
        /// Delete group
        /// </summary>
        public void Delete()
        {
            if (string.IsNullOrEmpty(GroupId))
                throw new Exception("Specify a group id first");

            Dispatch.Remote.DeleteGroup(GroupId, Dispatch.Uuid);
        }


    }
}
