using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
