using CronosegAccess.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CronosegAccess.Models
{
    public class accEnter
    {
        [Key]
        public int idEnter { get; set; }

        public int Date { get; set; }

        public int Time { get; set; }

        public int idUser { get; set; }

        public string FullName { get; set; }

        public string Uid { get; set; }

        public accUser user { get; set; }
        public int idMode { get; set; }
        public accMode mode { get; set; }

        public int idResult { get; set; }
        public accResult result { get; set; }
        public int idTerminal { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }

        public int idZone { get; set; }
        public accZone Zone { get; set; }
        public int idSchedule { get; set; }
        public accSchedule schedule {get; set;}


    }
}
