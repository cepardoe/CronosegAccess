using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class accResult
    {
        [Key]
        public int idResult { get; set; }

        public string Name { get; set; }

        public string Equivale { get; set; }

        public ICollection<accEnter> Enters { get; set; }
    }

}
