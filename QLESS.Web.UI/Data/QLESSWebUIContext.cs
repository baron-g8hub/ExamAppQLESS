#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace QLESS.Web.UI.Data
{
    public class QLESSWebUIContext : DbContext
    {
        public QLESSWebUIContext (DbContextOptions<QLESSWebUIContext> options)
            : base(options)
        {
        }

        public DbSet<TravelCard> TravelCard { get; set; }
    }
}
