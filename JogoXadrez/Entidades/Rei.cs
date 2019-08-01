using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] m = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // NORTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // NORDESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // LESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // SUDESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // SUL
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // SUDOESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // OESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // NOROESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            return m;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
