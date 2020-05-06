using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class UserZone
    {
        public int idUser { get; set; }

        public int IdZone { get; set; }

        public User user { get; set; }

        public Zone zone { get; set; }
    }
}
