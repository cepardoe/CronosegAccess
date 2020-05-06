using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class Zone
    {
        [Key]
        public int idZone { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        public ICollection<UserZone> UserZone { get; set; }
        public ICollection<Terminal> Terminals { get; set; }
    }
}
