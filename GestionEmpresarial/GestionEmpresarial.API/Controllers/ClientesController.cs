using GestionEmpresarial.API.Data;
using GestionEmpresarial.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpresarial.API.Controllers
{
    [ApiController]
    [Route("/api/Clientes")]
    public class ClientesController : ControllerBase
    {

        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }


        // get para obtener una lista de resultados

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Clientes.ToListAsync());
        }


        //get por parametro

        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }


        //Create datos
        [HttpPost]

        public async Task<ActionResult> Post(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }


        //Update datos
        [HttpPut]
        public async Task<ActionResult> Put(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }


        //Delete datos
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Filas_Afectadas = await _context.Clientes
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
