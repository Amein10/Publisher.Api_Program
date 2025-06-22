﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public int? CoverId { get; set; }
        public string? CoverTitle { get; set; }
    }
}
