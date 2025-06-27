namespace APISWAGGER.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public double Num1 { get; set; }
        public double Num2 { get; set; }
        public string TipoOperacion { get; set; }
        public double Resultado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}