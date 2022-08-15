namespace POUPADEV.API.Controllers.Models
{
    public class ObjetivoFinanceiroInputModel
    {
        public ObjetivoFinanceiroInputModel(string titulo, string descricao, decimal valorObjetivo)
        {
            Titulo = titulo;
            Descricao = descricao;
            ValorObjetivo = valorObjetivo;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal ValorObjetivo { get; private set; }
    }
}