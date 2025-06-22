using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class CoverArtistShortDto
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

