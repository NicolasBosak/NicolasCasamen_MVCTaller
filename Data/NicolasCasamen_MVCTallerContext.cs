using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicolasCasamen_MVCTaller.Models;

namespace NicolasCasamen_MVCTaller.Data
{
    public class NicolasCasamen_MVCTallerContext : DbContext
    {
        public NicolasCasamen_MVCTallerContext (DbContextOptions<NicolasCasamen_MVCTallerContext> options)
            : base(options)
        {
        }

        public DbSet<NicolasCasamen_MVCTaller.Models.Burger> Burger { get; set; } = default!;
        public DbSet<NicolasCasamen_MVCTaller.Models.Promo> Promo { get; set; } = default!;
    }
}
