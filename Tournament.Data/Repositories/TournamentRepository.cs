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

        public TournamentRepository(TournmentDbContext context) { }

        public void Add(Core.Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Tournament>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Core.Tournament> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Core.Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}
