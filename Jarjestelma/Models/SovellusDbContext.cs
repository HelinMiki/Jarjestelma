using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jarjestelma.Models
{
    public class SovellusDbContext : DbContext
    {
        public SovellusDbContext(DbContextOptions<SovellusDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
    }
}
