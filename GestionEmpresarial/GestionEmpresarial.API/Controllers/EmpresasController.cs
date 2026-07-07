using GestionEmpresarial.API.Data;
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
    }
}
