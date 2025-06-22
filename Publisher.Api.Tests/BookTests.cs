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
    public class BookTests
    {
        [TestMethod]
        public void Book_CanSetAndGetProperties()
        {
            var book = new Book();
            book.Title = "Hamlet";
            book.BasePrice = 199.95m;
            book.PublishDate = new DateOnly(1603, 1, 1);
            Assert.AreEqual("Hamlet", book.Title);
            Assert.AreEqual(199.95m, book.BasePrice);
            Assert.AreEqual(new DateOnly(1603, 1, 1), book.PublishDate);
        }

        [TestMethod]
        public void Book_CanAssignAuthor()
        {
            var book = new Book();
            var author = new Author() { FirstName = "Jane" };
            book.Author = author;
            Assert.AreSame(author, book.Author);
        }
    }
}