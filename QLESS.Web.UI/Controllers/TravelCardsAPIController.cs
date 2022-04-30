
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Common.Models;
using QLESS.Web.UI.Data;

namespace QLESS.Web.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TravelCardsAPIController : ControllerBase
    {
        private readonly QLESSWebUIContext _context;

        public TravelCardsAPIController(QLESSWebUIContext context)
        {
            _context = context;
        }

        // GET: api/TravelCardsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelCard>>> GetTravelCard()
        {
            return await _context.TravelCard.ToListAsync();
        }

        // GET: api/TravelCardsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelCard>> GetTravelCard(int id)
        {
            var travelCard = await _context.TravelCard.FindAsync(id);

            if (travelCard == null)
            {
                return NotFound();
            }

            return travelCard;
        }

        // PUT: api/TravelCardsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelCard(int id, TravelCard travelCard)
        {
            if (id != travelCard.TravelCardID)
            {
                return BadRequest();
            }

            _context.Entry(travelCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelCardExists(id))
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

        // POST: api/TravelCardsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelCard>> PostTravelCard(TravelCard travelCard)
        {
            _context.TravelCard.Add(travelCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelCard", new { id = travelCard.TravelCardID }, travelCard);
        }

        // DELETE: api/TravelCardsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelCard(int id)
        {
            var travelCard = await _context.TravelCard.FindAsync(id);
            if (travelCard == null)
            {
                return NotFound();
            }

            _context.TravelCard.Remove(travelCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelCardExists(int id)
        {
            return _context.TravelCard.Any(e => e.TravelCardID == id);
        }
    }
}
