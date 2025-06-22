using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class ArtistDto
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<ArtistCoverShortDto> ArtistCovers { get; set; } = new();
    }
}
