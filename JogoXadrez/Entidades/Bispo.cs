using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] m = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // NE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha--;
                pos.Coluna++;
            }

            // SE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha++;
                pos.Coluna++;
            }

            // SO
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha++;
                pos.Coluna--;
            }

            // NO
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha--;
                pos.Coluna--;
            }

            return m;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
