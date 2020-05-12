using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class accUserSchedule
    {
        public int idUser { get; set; }

        public accUser User { get; set; }
        public int idSchedule { get; set; }

        public accSchedule schedule { get; set; }
    }
}
