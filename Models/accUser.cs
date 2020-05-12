using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class accUser
    {
        [Key]
        [Display(Name = "Id Usuario")]
        public int idUser { get; set; }
        [StringLength(15, MinimumLength = 5)]
        [RegularExpression(@"^[0-9]*$")]
        [Required]
        [Display(Name = "Identificación")]
        public string Uid { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [Display(Name = "Nombres")]

        public string FirstName { get; set; }


        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Display(Name = "Fecha Inicial")]
        [DataType(DataType.DateTime)]
        public DateTime dateIni { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Final")]
        public DateTime dateEnd { get; set; }

        public ICollection<accUserZone> UserZones { get; set; }
        public ICollection<accUserSchedule> UserSchedules { get; set; }
    }
}