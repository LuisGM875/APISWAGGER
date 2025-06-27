using Microsoft.AspNetCore.Mvc;

namespace APISWAGGER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AritmeticaController : Controller
    {
        [HttpGet("sumar")]
        public ActionResult<double> Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        [HttpGet("restar")]
        public ActionResult<double> Restar(double num1, double num2)
        {
            return num1 - num2;
        }

        [HttpGet("multiplicar")]
        public ActionResult<double> Multiplicar(double num1, double num2)
        {
            return num1 * num2;
        }

        [HttpGet("dividir")]
        public ActionResult<double> Dividir(double num1, double num2)
        {
            if (num2 == 0)
            {
                return BadRequest("No se puede dividir por cero");
            }
            return num1 / num2;
        }
    }
}
