using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Model;

namespace Zaliczenie.Data
{
    public class ZaliczenieContext : DbContext
    {
        public ZaliczenieContext (DbContextOptions<ZaliczenieContext> options)
            : base(options)
        {
        }

        public DbSet<Zaliczenie.Model.Kolekcje> Kolekcje { get; set; } = default!;
    }
}
