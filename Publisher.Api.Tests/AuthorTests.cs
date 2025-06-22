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
    public class AuthorTests
    {
        [TestMethod]
        public void Author_CanSetAndGetProperties()
        {
            var author = new Author();
            author.FirstName = "William";
            author.LastName = "Shakespeare";
            Assert.AreEqual("William", author.FirstName);
            Assert.AreEqual("Shakespeare", author.LastName);
        }

        [TestMethod]
        public void Author_Books_InitializedEmptyList()
        {
            var author = new Author();
            Assert.IsNotNull(author.Books);
            Assert.AreEqual(0, author.Books.Count);
        }
    }
}