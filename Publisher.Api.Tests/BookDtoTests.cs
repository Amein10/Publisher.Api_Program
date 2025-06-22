using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publisher.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Publisher.Api.Tests
{
    [TestClass]
    public class BookDtoTests
    {
        [TestMethod]
        public void BookDto_DefaultValues_AreCorrect()
        {
            var dto = new BookDto();
            Assert.AreEqual(0, dto.BookId);
            Assert.IsNull(dto.Title);
            Assert.AreEqual(0, dto.BasePrice);
            Assert.IsNull(dto.AuthorName);
            Assert.IsNull(dto.CoverTitle);
        }
    }

}
