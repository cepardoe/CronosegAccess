using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CronosegAccess.Data;
using CronosegAccess.Models;

namespace CronosegAccess.Pages.Enters
{
    [Route("api/[controller]")]
    [ApiController]
    public class accEnterController : ControllerBase
    {
        private readonly CronosegAccessContext _context;

        public accEnterController(CronosegAccessContext context)
        {
            _context = context;
        }

        // GET: api/accEnter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<accEnter>>> GetaccEnter()
        {
            return await _context.accEnter.ToListAsync();
        }

        // GET: api/accEnter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<accEnter>> GetaccEnter(int id)
        {
            var accEnter = await _context.accEnter.FindAsync(id);

            if (accEnter == null)
            {
                return NotFound();
            }

            return accEnter;
        }

        // PUT: api/accEnter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutaccEnter(int id, accEnter accEnter)
        {
            if (id != accEnter.idEnter)
            {
                return BadRequest();
            }

            _context.Entry(accEnter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accEnterExists(id))
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

        // POST: api/accEnter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<accEnter>> PostaccEnter(accEnter accEnter)
        {
            _context.accEnter.Add(accEnter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetaccEnter", new { id = accEnter.idEnter }, accEnter);
        }

        // DELETE: api/accEnter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<accEnter>> DeleteaccEnter(int id)
        {
            var accEnter = await _context.accEnter.FindAsync(id);
            if (accEnter == null)
            {
                return NotFound();
            }

            _context.accEnter.Remove(accEnter);
            await _context.SaveChangesAsync();

            return accEnter;
        }

        private bool accEnterExists(int id)
        {
            return _context.accEnter.Any(e => e.idEnter == id);
        }
    }
}
