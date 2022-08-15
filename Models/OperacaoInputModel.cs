using POUPADEV.API.Enums;

namespace POUPADEV.API.Controllers.Models
{
    public class OperacaoInputModel
    {
        public OperacaoInputModel(decimal valor, TipoOperacao tipoOperacao)
        {
            Valor = valor;
            TipoOperacao = tipoOperacao;
        }

        public decimal Valor { get; private set; }
        public TipoOperacao TipoOperacao { get; private set; }
    }
}