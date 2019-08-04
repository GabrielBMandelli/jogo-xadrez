using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] m = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // 2 NORTE 1 LESTE
            pos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 NORTE 1 OESTE
            pos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 NORTE 2 LESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 NORTE 2 OESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 LESTE 1 NORTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 LESTE 1 SUL
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 LESTE 2 NORTE
            pos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 LESTE 2 SUL
            pos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 SUL 1 LESTE
            pos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 SUL 1 OESTE
            pos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 SUL 2 LESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 SUL 2 OESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 OESTE 1 NORTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 2 OESTE 1 SUL
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 OESTE 2 NORTE
            pos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            // 1 OESTE 2 SUL
            pos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos))
                m[pos.Linha, pos.Coluna] = true;

            return m;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
