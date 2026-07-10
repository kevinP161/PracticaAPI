using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Empresas")]

    public class EmpresasController : ControllerBase
    {

        private readonly DataContext _context;

        public EmpresasController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Empresas.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Empresa empresa)
        {
            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return Ok(empresa);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Empresa empresa)
        {
            _context.Update(empresa);
            await _context.SaveChangesAsync();
            return Ok(empresa);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Empresas
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
