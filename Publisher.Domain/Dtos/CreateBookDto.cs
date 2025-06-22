using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class CreateBookDto
    {
        public string? Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public decimal BasePrice { get; set; }
        public int AuthorId { get; set; }
        // Evt. CoverId, hvis du vil oprette med cover fra start
        public int? CoverId { get; set; }
    }
}
