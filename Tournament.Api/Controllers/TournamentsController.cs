using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tournament.Core;
using Tournament.Core.Repositories;
using Tournament.Data;

namespace Tournament.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly IUnitofWork _uow;

        public TournamentsController(IUnitofWork uow)
        {
            _uow = uow;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament.Core.Tournament>>> GetTournaments()
        {

             var list = await _uow.TournamentRepository.GetAllAsync();
            return new OkObjectResult(list);
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament.Core.Tournament>> GetTournament(int id)
        {
             
            var tournament = await _uow.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament.Core.Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _uow.TournamentRepository.Update(tournament);

            try
            {
                _uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournament.Core.Tournament>> PostTournament(Tournament.Core.Tournament tournament)
        {
            _uow.TournamentRepository.Add(tournament);
            await _uow.CompleteAsync();
            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _uow.TournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            _uow.TournamentRepository.Remove(tournament);
            await _uow.CompleteAsync();
            
            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _uow.TournamentRepository.AnyAsync(id).Result;
        }
    }
}
