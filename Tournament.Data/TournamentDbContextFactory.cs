using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Tournament.Data
{
    public class TournamentDbContextFactory: IDesignTimeDbContextFactory<TournmentDbContext>
    {

      
            public TournmentDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<TournmentDbContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TournmentDb;Trusted_Connection=True;MultipleActiveResultSets=true");

                  return new TournmentDbContext(optionsBuilder.Options);
            }
    }
}
