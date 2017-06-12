namespace Framework.Core.Exceptions
{
    public class NavegadorNaoEncontradoException : ExceptionBase
    {
        public NavegadorNaoEncontradoException(string message) : base(message)
        {
            Tipo = "Browser";
            Descricao = "Não foi possível encontrar o navegador.";
        }
    }
}
