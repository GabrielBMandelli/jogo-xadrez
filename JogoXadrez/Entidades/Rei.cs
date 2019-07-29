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
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // NORDESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // LESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna + 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // SUDESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // SUL
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // SUDOESTE
            pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // OESTE
            pos.SetPosicao(Posicao.Linha, Posicao.Coluna - 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            // NOROESTE
            pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            m[pos.Linha, pos.Coluna] = (!Tabuleiro.IsPosicaoInvalida(pos) && IsMovimentoPossivel(pos)) ? true : false;

            return m;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
