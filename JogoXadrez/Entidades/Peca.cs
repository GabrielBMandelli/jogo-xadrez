using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Cor = cor;
            Tabuleiro = tabuleiro;
            QtdMovimentos = 0;
            Posicao = null;
        }

        public void IncrementarMovimento()
        {
            QtdMovimentos++;
        }

        protected bool IsMovimentoPossivel(Posicao pos)
        {
            Peca p = Tabuleiro.GetPeca(pos);
            return p == null || p.Cor != Cor;
        }

        public bool ExisteMovimentoPossivel()
        {
            bool[,] m = GetMovimentosPossiveis();

            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (m[i, j])
                        return true;
                }
            }

            return false;
        }

        public abstract bool[,] GetMovimentosPossiveis();
    }
}
