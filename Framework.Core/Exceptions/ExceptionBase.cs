using System;

namespace Framework.Core.Exceptions
{
    public abstract class ExceptionBase : Exception
    {

        public string Tipo { get; protected set; }
        public string Descricao { get; protected set;}

        protected ExceptionBase(string message) : base(message)
        {}

        protected ExceptionBase(string message, string tipo) : base(message)
        {
            Tipo = tipo;
        }
        protected ExceptionBase(string message, string tipo, string descricao) : base(message)
        {
            Tipo = tipo;
            Descricao = descricao;
        }
    }
}
