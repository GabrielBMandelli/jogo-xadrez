using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
