using System;

namespace JogoXadrez.Exceptions
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string mensagem) : base(mensagem)
        {
        }
    }
}
