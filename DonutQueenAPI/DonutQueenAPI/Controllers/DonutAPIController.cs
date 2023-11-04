using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonutQueenAPI.Data;
using DonutQueenAPI.Models;

namespace DonutQueenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonutAPIController : ControllerBase
    {
        private readonly DonutQueenAPIContext _context;

        public DonutAPIController(DonutQueenAPIContext context)
        {
            _context = context;
        }

        // GET: api/DonutAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donut>>> GetDonuts()
        {
          if (_context.Donuts == null)
          {
              return NotFound();
          }
            return await _context.Donuts.ToListAsync();
        }

        // GET: api/DonutAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donut>> GetDonut(int id)
        {
          if (_context.Donuts == null)
          {
              return NotFound();
          }
            var donut = await _context.Donuts.FindAsync(id);

            if (donut == null)
            {
                return NotFound();
            }

            return donut;
        }

        // PUT: api/DonutAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonut(int id, Donut donut)
        {
            if (id != donut.DonutId)
            {
                return BadRequest();
            }

            _context.Entry(donut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonutExists(id))
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

        // POST: api/DonutAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donut>> PostDonut(Donut donut)
        {
          if (_context.Donuts == null)
          {
              return Problem("Entity set 'DonutQueenAPIContext.Donuts'  is null.");
          }
            _context.Donuts.Add(donut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonut", new { id = donut.DonutId }, donut);
        }

        // DELETE: api/DonutAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonut(int id)
        {
            if (_context.Donuts == null)
            {
                return NotFound();
            }
            var donut = await _context.Donuts.FindAsync(id);
            if (donut == null)
            {
                return NotFound();
            }

            _context.Donuts.Remove(donut);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonutExists(int id)
        {
            return (_context.Donuts?.Any(e => e.DonutId == id)).GetValueOrDefault();
        }
    }
}
