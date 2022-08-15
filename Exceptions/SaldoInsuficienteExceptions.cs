namespace POUPADEV.API.Exceptions
{
    public class SaldoInsuficienteExceptions
    {
        public class SaldoInsuficienteException : Exception
   {
       public SaldoInsuficienteException() : base("Saldo insuficiente!")
       {
       }
    }
    }
}