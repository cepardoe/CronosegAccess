using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class accUserZone
    {
        public int idUser { get; set; }

        public accUser user { get; set; }
        public int idZone { get; set; }

        public accZone zone { get; set; }
    }
}
