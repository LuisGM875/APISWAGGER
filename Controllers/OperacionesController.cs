using Microsoft.AspNetCore.Mvc;
using APISWAGGER.Bd;
using APISWAGGER.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APISWAGGER.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperacionesController : ControllerBase
    {
        private readonly CalculadoraContext _context;

        public OperacionesController(CalculadoraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operacion>>> GetOperaciones()
        {
            return await _context.Operaciones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Operacion>> PostOperacion(Operacion operacion)
        {
            _context.Operaciones.Add(operacion);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOperaciones), new { id = operacion.Id }, operacion);
        }
    }
}