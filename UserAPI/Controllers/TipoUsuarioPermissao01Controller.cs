using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Domains;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioPermissao01Controller : ControllerBase
    {
        private readonly UserContext _context;

        public TipoUsuarioPermissao01Controller(UserContext context)
        {
            _context = context;
        }

        // GET: api/TipoUsuarioPermissao01
        [HttpGet]
        public IEnumerable<TipoUsuarioPermissao01> GetTipoUsuarioPermissao01()
        {
            return _context.TipoUsuarioPermissao01;
        }

        // GET: api/TipoUsuarioPermissao01/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoUsuarioPermissao01([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuarioPermissao01 = await _context.TipoUsuarioPermissao01.FindAsync(id);

            if (tipoUsuarioPermissao01 == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuarioPermissao01);
        }

        // PUT: api/TipoUsuarioPermissao01/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuarioPermissao01([FromRoute] int id, [FromBody] TipoUsuarioPermissao01 tipoUsuarioPermissao01)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUsuarioPermissao01.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoUsuarioPermissao01).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioPermissao01Exists(id))
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

        // POST: api/TipoUsuarioPermissao01
        [HttpPost]
        public async Task<IActionResult> PostTipoUsuarioPermissao01([FromBody] TipoUsuarioPermissao01 tipoUsuarioPermissao01)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoUsuarioPermissao01.Add(tipoUsuarioPermissao01);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUsuarioPermissao01", new { id = tipoUsuarioPermissao01.Id }, tipoUsuarioPermissao01);
        }

        // DELETE: api/TipoUsuarioPermissao01/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUsuarioPermissao01([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuarioPermissao01 = await _context.TipoUsuarioPermissao01.FindAsync(id);
            if (tipoUsuarioPermissao01 == null)
            {
                return NotFound();
            }

            _context.TipoUsuarioPermissao01.Remove(tipoUsuarioPermissao01);
            await _context.SaveChangesAsync();

            return Ok(tipoUsuarioPermissao01);
        }

        private bool TipoUsuarioPermissao01Exists(int id)
        {
            return _context.TipoUsuarioPermissao01.Any(e => e.Id == id);
        }
    }
}