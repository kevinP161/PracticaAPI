using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Categorias")]
    public class CategoriasController : ControllerBase
    {

        private readonly DataContext _context;

        public CategoriasController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Categorias.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return Ok(categoria);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return Ok(categoria);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Categorias
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
