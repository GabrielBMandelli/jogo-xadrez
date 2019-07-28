using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
