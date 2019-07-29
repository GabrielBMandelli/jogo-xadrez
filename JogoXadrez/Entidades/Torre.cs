using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] m = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // NORTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha--;
            }

            // LESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Coluna++;
            }

            // SUL
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Linha++;
            }

            // OESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
            {
                m[pos.Linha, pos.Coluna] = true;

                if (Tabuleiro.GetPeca(pos) != null && Tabuleiro.GetPeca(pos).Cor != Cor)
                    break;

                pos.Coluna--;
            }

            return m;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
