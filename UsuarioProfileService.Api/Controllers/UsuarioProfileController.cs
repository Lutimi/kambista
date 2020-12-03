using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuarioProfileService.Api.Models.UsuarioProfile;
using UsuarioProfileService.Entities;
using UsuarioProfileService.Data;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioProfileController : ControllerBase
    {
        private readonly DbUsuarioProfileContext _context;

        public UsuarioProfileController(DbUsuarioProfileContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioProfile
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioProfileViewModel>> List()
        {
            var conductorList = await _context.UsuarioProfile.ToListAsync();

            return conductorList.Select(c => new UsuarioProfileViewModel
            {
                UsuarioId=c.UsuarioId,
                Nombre=c.Nombre,
                Apellido=c.Apellido,
                Celular=c.Celular,
                Correo=c.Correo
            });
        }

        // GET: api/UsuarioProfile/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<UsuarioProfileViewModel>> Show([FromRoute] int id)
        {
            var conductor= await _context.UsuarioProfile.FindAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(new UsuarioProfileViewModel
            {
                UsuarioId = conductor.UsuarioId,
                Nombre = conductor.Nombre,
                Apellido = conductor.Apellido,
                Celular = conductor.Celular,
                Correo = conductor.Correo
            });
        }

        // PUT: api/UsuarioProfile/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioProfileViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.UsuarioId <= 0)
            {
                return BadRequest();
            }

            var usu = await _context.UsuarioProfile.FirstOrDefaultAsync(c => c.UsuarioId == model.UsuarioId);
            if (usu == null)
            {
                return NotFound();
            }
            usu.Nombre = model.Nombre;
            usu.Apellido = model.Apellido;
            usu.Celular = model.Celular;
            usu.Correo = model.Correo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Conductores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody]CreateUsuarioProfileViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            UsuarioProfile usu = new UsuarioProfile
            {
            Nombre = model.Nombre,
            Apellido = model.Apellido,
            Celular = model.Celular,
            Correo = model.Correo
            };

            _context.UsuarioProfile.Add(usu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/UsuarioProfile/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var conductor = await _context.UsuarioProfile.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            _context.UsuarioProfile.Remove(conductor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        private bool UsuarioProfileExists(int id)
        {
            return _context.UsuarioProfile.Any(e => e.UsuarioId == id);
        }
    }
}
