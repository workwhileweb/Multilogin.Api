using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Multilogin.Api.Tests
{
    public abstract class BaseTests
    {
        private TestContext TestContextInstance;

        public TestContext TestContext
        {
            get
            {
                return TestContextInstance;
            }
            set
            {
                TestContextInstance = value;
            }
        }

        /// <summary>
        /// MLA Client
        /// </summary>
        public static MLAClient client => ClientTests.client;

        /// <summary>
        /// Profile to test features on
        /// </summary>
        public static string profileId => ClientTests.profileId;

        public BaseTests() { }

        protected string GetResourceFilePath(string filename)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(path, "Resources", filename);
        }

    }
}
