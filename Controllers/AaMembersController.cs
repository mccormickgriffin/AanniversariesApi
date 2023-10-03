using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AanniversariesApi.Models;

namespace AanniversariesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AaMembersController : ControllerBase
    {
        private readonly AaMemberContext _context;

        public AaMembersController(AaMemberContext context)
        {
            _context = context;
        }

        // GET: api/AaMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AaMember>>> GetAaMembers()
        {
          if (_context.AaMembers == null)
          {
              return NotFound();
          }
            return await _context.AaMembers.ToListAsync();
        }

        // GET: api/AaMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AaMember>> GetAaMember(long id)
        {
          if (_context.AaMembers == null)
          {
              return NotFound();
          }
            var aaMember = await _context.AaMembers.FindAsync(id);

            if (aaMember == null)
            {
                return NotFound();
            }

            return aaMember;
        }

        // PUT: api/AaMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAaMember(long id, AaMember aaMember)
        {
            if (id != aaMember.Id)
            {
                return BadRequest();
            }

            _context.Entry(aaMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AaMemberExists(id))
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

        // POST: api/AaMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AaMember>> PostAaMember(AaMember aaMember)
        {
          if (_context.AaMembers == null)
          {
              return Problem("Entity set 'AaMemberContext.AaMembers'  is null.");
          }
            _context.AaMembers.Add(aaMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAaMember), new { id = aaMember.Id }, aaMember);
        }

        // DELETE: api/AaMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAaMember(long id)
        {
            if (_context.AaMembers == null)
            {
                return NotFound();
            }
            var aaMember = await _context.AaMembers.FindAsync(id);
            if (aaMember == null)
            {
                return NotFound();
            }

            _context.AaMembers.Remove(aaMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AaMemberExists(long id)
        {
            return (_context.AaMembers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
