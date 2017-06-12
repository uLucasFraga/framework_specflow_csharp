namespace Framework.Core.Exceptions
{
    public class ElementoNaoEncontrado : ExceptionBase
    {
        public ElementoNaoEncontrado(string message) : base(message)
        {
            Tipo = "Elemento";
            Descricao = "O elemento não foi encontrado na página ou a página não foi carregada corretamente.";
        }

        public void TextoNaoEncontrado(string message)
        {
            Tipo = "Texto";
            Descricao = "O texto não foi encontrado na página ou a página não foi carregada corretamente";
        }
    }
}
