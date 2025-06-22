using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publisher.Domain.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Publisher.Api.Tests
{
    [TestClass]
    public class ArtistTests
    {
        [TestMethod]
        public void Artist_CanSetAndGetProperties()
        {
            // Arrange
            var artist = new Artist();

            // Act
            artist.FirstName = "Test";
            artist.LastName = "User";

            // Assert
            Assert.AreEqual("Test", artist.FirstName);
            Assert.AreEqual("User", artist.LastName);
        }
    }
}
