using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Publisher.Api.Tests
{
    [TestClass]
    public class CoverTests
    {
        [TestMethod]
        public void Cover_CanSetAndGetProperties()
        {
            var cover = new Cover();
            cover.Title = "Hardcover";
            cover.DigitalOnly = true;
            Assert.AreEqual("Hardcover", cover.Title);
            Assert.IsTrue(cover.DigitalOnly);
        }
    }
}