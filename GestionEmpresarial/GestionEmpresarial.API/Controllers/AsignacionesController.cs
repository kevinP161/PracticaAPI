using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{

    [ApiController]
    [Route("/api/Asignaciones")]
    public class AsignacionesController : ControllerBase
    {

        private readonly DataContext _context;

        public AsignacionesController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Asignaciones.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var asignacion = await _context.Asignaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return Ok(asignacion);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Asignacion asignacion)
        {
            _context.Add(asignacion);
            await _context.SaveChangesAsync();
            return Ok(asignacion);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Asignacion asignacion)
        {
            _context.Update(asignacion);
            await _context.SaveChangesAsync();
            return Ok(asignacion);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Asignaciones
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (Filas_Afectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
