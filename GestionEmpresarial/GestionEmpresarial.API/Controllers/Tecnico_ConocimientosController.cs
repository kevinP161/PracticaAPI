using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Tecnicos_Conocimientos")]
    public class Tecnico_ConocimientosController : ControllerBase
    {

        private readonly DataContext _context;

        public Tecnico_ConocimientosController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tecnico_Conocimientos.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var tecnico_Conocimiento = await _context.Tecnico_Conocimientos.FirstOrDefaultAsync(x => x.Id == id);
            if (tecnico_Conocimiento == null)
            {
                return NotFound();
            }

            return Ok(tecnico_Conocimiento);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Tecnico_Conocimiento tecnico_Conocimiento)
        {
            _context.Add(tecnico_Conocimiento);
            await _context.SaveChangesAsync();
            return Ok(tecnico_Conocimiento);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Tecnico_Conocimiento tecnico_Conocimiento)
        {
            _context.Update(tecnico_Conocimiento);
            await _context.SaveChangesAsync();
            return Ok(tecnico_Conocimiento);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Tecnico_Conocimientos
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
