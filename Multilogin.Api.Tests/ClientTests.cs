using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Multilogin.Api.Tests
{
    [TestClass]
    public class ClientTests
    {

        /// <summary>
        /// MLA Client
        /// </summary>
        public static MLAClient client;

        /// <summary>
        /// Profile to run tests on
        /// </summary>
        public static string profileId = "e44fd552-cf8f-472d-b0f3-a94f993d3be3";

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            client = new MLAClient();
        }

        //[TestMethod]
        //public void RateLimitTest()
        //{
        //    var sw = Stopwatch.StartNew();

        //    for (int i = 0; i < 15; i++)
        //    {
        //        client.GetProfiles(); // only 10 per minute allowed
        //    }

        //    // 15 requests should end in more than 1 minutes
        //    Assert.IsTrue(sw.Elapsed.TotalSeconds > 60);
        //}
    }
}
