using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models.ViewModel
{
    public class UserIndexData
    {
        public IEnumerable<accUser> Users { get; set; }
        public IEnumerable<accZone> Zones { get; set; }
        public IEnumerable<accTerminal> Terminals { get; set; }
    }
}
    