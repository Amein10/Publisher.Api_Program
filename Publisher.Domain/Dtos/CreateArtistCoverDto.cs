using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class CreateArtistCoverDto
    {
        public int ArtistId { get; set; }
        public int CoverId { get; set; }
    }
}