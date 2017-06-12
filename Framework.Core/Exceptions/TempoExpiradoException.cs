namespace Framework.Core.Exceptions
{
    public class TempoExpiradoException : ExceptionBase
    {
        public TempoExpiradoException(string message) : base(message)
        {
            Tipo = "Timeout";
            Descricao = "A espera excedeu o tempo estipulado.";
        }
    }
}
