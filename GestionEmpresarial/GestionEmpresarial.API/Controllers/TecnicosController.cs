using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Tecnicos")]
    public class TecnicosController : ControllerBase
    {

        private readonly DataContext _context;

        public TecnicosController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Tecnicos.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var tecnico = await _context.Tecnicos.FirstOrDefaultAsync(x => x.Id == id);
            if (tecnico == null)
            {
                return NotFound();
            }

            return Ok(tecnico);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Tecnico tecnico)
        {
            _context.Add(tecnico);
            await _context.SaveChangesAsync();
            return Ok(tecnico);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Tecnico tecnico)
        {
            _context.Update(tecnico);
            await _context.SaveChangesAsync();
            return Ok(tecnico);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Tecnicos
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
