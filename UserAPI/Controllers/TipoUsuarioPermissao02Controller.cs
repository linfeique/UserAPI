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
    public class TipoUsuarioPermissao02Controller : ControllerBase
    {
        private readonly UserContext _context;

        public TipoUsuarioPermissao02Controller(UserContext context)
        {
            _context = context;
        }

        // GET: api/TipoUsuarioPermissao02
        [HttpGet]
        public IEnumerable<TipoUsuarioPermissao02> GetTipoUsuarioPermissao02()
        {
            return _context.TipoUsuarioPermissao02;
        }

        // GET: api/TipoUsuarioPermissao02/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoUsuarioPermissao02([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuarioPermissao02 = await _context.TipoUsuarioPermissao02.FindAsync(id);

            if (tipoUsuarioPermissao02 == null)
            {
                return NotFound();
            }

            return Ok(tipoUsuarioPermissao02);
        }

        // PUT: api/TipoUsuarioPermissao02/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuarioPermissao02([FromRoute] int id, [FromBody] TipoUsuarioPermissao02 tipoUsuarioPermissao02)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoUsuarioPermissao02.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoUsuarioPermissao02).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoUsuarioPermissao02Exists(id))
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

        // POST: api/TipoUsuarioPermissao02
        [HttpPost]
        public async Task<IActionResult> PostTipoUsuarioPermissao02([FromBody] TipoUsuarioPermissao02 tipoUsuarioPermissao02)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoUsuarioPermissao02.Add(tipoUsuarioPermissao02);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoUsuarioPermissao02", new { id = tipoUsuarioPermissao02.Id }, tipoUsuarioPermissao02);
        }

        // DELETE: api/TipoUsuarioPermissao02/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoUsuarioPermissao02([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoUsuarioPermissao02 = await _context.TipoUsuarioPermissao02.FindAsync(id);
            if (tipoUsuarioPermissao02 == null)
            {
                return NotFound();
            }

            _context.TipoUsuarioPermissao02.Remove(tipoUsuarioPermissao02);
            await _context.SaveChangesAsync();

            return Ok(tipoUsuarioPermissao02);
        }

        private bool TipoUsuarioPermissao02Exists(int id)
        {
            return _context.TipoUsuarioPermissao02.Any(e => e.Id == id);
        }
    }
}