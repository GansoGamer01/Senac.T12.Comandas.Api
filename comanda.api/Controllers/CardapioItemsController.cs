using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeComandas.BancoDeDados;
using SistemaDeComandas.Modelos;

namespace comanda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioItemsController : ControllerBase
    {
        private readonly ComandaContexto _context;

        public CardapioItemsController(ComandaContexto context)
        {
            _context = context;
        }

        // GET: api/CardapioItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardapioItem>>> GetcardapioItems()
        {
            return await _context.cardapioItems.ToListAsync();
        }

        // GET: api/CardapioItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardapioItem>> GetCardapioItem(int id)
        {
            var cardapioItem = await _context.cardapioItems.FindAsync(id);

            if (cardapioItem == null)
            {
                return NotFound();
            }

            return cardapioItem;
        }

        // PUT: api/CardapioItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardapioItem(int id, CardapioItem cardapioItem)
        {
            if (id != cardapioItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(cardapioItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardapioItemExists(id))
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

        // POST: api/CardapioItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardapioItem>> PostCardapioItem(CardapioItem cardapioItem)
        {
            _context.cardapioItems.Add(cardapioItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardapioItem", new { id = cardapioItem.Id }, cardapioItem);
        }

        // DELETE: api/CardapioItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardapioItem(int id)
        {
            var cardapioItem = await _context.cardapioItems.FindAsync(id);
            if (cardapioItem == null)
            {
                return NotFound();
            }

            _context.cardapioItems.Remove(cardapioItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardapioItemExists(int id)
        {
            return _context.cardapioItems.Any(e => e.Id == id);
        }
    }
}
