using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class CoverDto
    {
        public int CoverId { get; set; }
        public string? Title { get; set; }
        public bool DigitalOnly { get; set; }
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public List<CoverArtistShortDto> Artists { get; set; } = new();
    }
}
