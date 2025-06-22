using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class BookShortDto
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
    }
}
