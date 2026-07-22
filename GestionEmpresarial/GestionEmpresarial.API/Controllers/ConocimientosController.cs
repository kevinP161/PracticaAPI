using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Conocimientos")]
    public class ConocimientosController : ControllerBase
    {

        private readonly DataContext _context;

        public ConocimientosController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Conocimientos.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var conocimiento = await _context.Conocimientos.FirstOrDefaultAsync(x => x.Id == id);
            if (conocimiento == null)
            {
                return NotFound();
            }

            return Ok(conocimiento);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Conocimiento conocimiento)
        {
            _context.Add(conocimiento);
            await _context.SaveChangesAsync();
            return Ok(conocimiento);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Conocimiento conocimiento)
        {
            _context.Update(conocimiento);
            await _context.SaveChangesAsync();
            return Ok(conocimiento);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Conocimientos
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
