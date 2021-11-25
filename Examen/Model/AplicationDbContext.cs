using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Model
{
    class AplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Dulceria;" +
                "Integrated Security= True").EnableSensitiveDataLogging(true);
        }
        public DbSet<Productos> Productos { get; set; }
    }
}
