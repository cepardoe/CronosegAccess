using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Models;

namespace CronosegAccess.Data
{
    public class CronosegAccessContext : DbContext
    {
        public CronosegAccessContext (DbContextOptions<CronosegAccessContext> options)
            : base(options)
        {
        }

        public DbSet<CronosegAccess.Models.Terminal> Terminal { get; set; }

        public DbSet<CronosegAccess.Models.Zone> Zone { get; set; }
    }
}
