﻿using System;
using System.Collections.Generic;

namespace Publisher.Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
