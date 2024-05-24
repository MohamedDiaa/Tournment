using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Core.Repositories;

namespace Tournament.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournmentDbContext _context;
        public TournamentRepository(TournmentDbContext context) {
        
            _context = context;
        }

        public void Add(Core.Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return _context.Tournaments.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Core.Tournament>> GetAllAsync()
        {

            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Core.Tournament> GetAsync(int id)
        {
          return await _context.Tournaments.FindAsync(id);
        }

        public async void Remove(Core.Tournament tournament)
        {
         
            _context.Tournaments.Remove(tournament);
        }

        public async void Update(Core.Tournament tournament)
        {
            _context.Entry(tournament).State = EntityState.Modified;
        }
    }
}
