using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class ArtistCoverShortDto
    {
        public int CoverId { get; set; }
        public string? CoverTitle { get; set; }
    }
}
