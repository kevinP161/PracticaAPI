using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Proyectos")]
    public class ProyectosController : ControllerBase
    {

        private readonly DataContext _context;

        public ProyectosController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Proyectos.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.Id == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return Ok(proyecto);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Proyecto proyecto)
        {
            _context.Add(proyecto);
            await _context.SaveChangesAsync();
            return Ok(proyecto);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Proyecto proyecto)
        {
            _context.Update(proyecto);
            await _context.SaveChangesAsync();
            return Ok(proyecto);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Proyectos
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
