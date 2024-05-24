using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Repositories;

namespace Tournament.Data.Repositories
{
    public class UnitofWork : IUnitofWork
    {
        private TournmentDbContext _db { get; set; }

        public UnitofWork(TournmentDbContext context) {
            _db = context;
        }

        public ITournamentRepository TournamentRepository => new TournamentRepository(context: _db);

        public IGameRepository GameRepository => new GameRepository(context: _db);

        public async Task CompleteAsync()
        {
                
           await _db.SaveChangesAsync();
         }
    }
}
