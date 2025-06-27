using APISWAGGER.Bd;
using APISWAGGER.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APISWAGGER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AritmeticaController : ControllerBase
    {
        private readonly CalculadoraContext _context;

        public AritmeticaController(CalculadoraContext context)
        {
            _context = context;
        }

        [HttpGet("sumar")]
        public async Task<double> Sumar(double num1, double num2)
        {
            var resultado = num1 + num2;
            await GuardarOperacion(num1, num2, "Suma", resultado);
            return resultado;
        }

        [HttpGet("restar")]
        public async Task<double> Restar(double num1, double num2)
        {
            var resultado = num1 - num2;
            await GuardarOperacion(num1, num2, "Resta", resultado);
            return resultado;
        }

        [HttpGet("multiplicar")]
        public async Task<double> Multiplicar(double num1, double num2)
        {
            var resultado = num1 * num2;
            await GuardarOperacion(num1, num2, "Multiplicación", resultado);
            return resultado;
        }

        [HttpGet("dividir")]
        public async Task<ActionResult<double>> Dividir(double num1, double num2)
        {
            if (num2 == 0) return BadRequest("No se puede dividir por cero");

            var resultado = num1 / num2;
            await GuardarOperacion(num1, num2, "División", resultado);
            return resultado;
        }

        [HttpGet("historial")]
        public async Task<List<Operacion>> GetHistorial()
        {
            return await _context.Operaciones
                .OrderByDescending(o => o.Fecha)
                .ToListAsync();
        }

        private async Task GuardarOperacion(double num1, double num2, string operacion, double resultado)
        {
            await _context.Operaciones.AddAsync(new Operacion
            {
                Num1 = num1,
                Num2 = num2,
                TipoOperacion = operacion,
                Resultado = resultado
            });
            await _context.SaveChangesAsync();
        }
    }
}