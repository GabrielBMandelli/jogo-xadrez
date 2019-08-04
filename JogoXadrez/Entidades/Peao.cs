using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] GetMovimentosPossiveis()
        {
            bool[,] m = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {
                // 1 NORTE
                pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && EstaLivre(pos))
                    m[pos.Linha, pos.Coluna] = true;

                // 2 NORTE
                pos.SetPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && EstaLivre(pos) && QtdMovimentos == 0)
                    m[pos.Linha, pos.Coluna] = true;

                // NE
                pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && ExisteInimigo(pos))
                    m[pos.Linha, pos.Coluna] = true;

                // NO
                pos.SetPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && ExisteInimigo(pos))
                    m[pos.Linha, pos.Coluna] = true;
            }
            else
            {
                // 1 SUL
                pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && EstaLivre(pos))
                    m[pos.Linha, pos.Coluna] = true;

                // 2 SUL
                pos.SetPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && EstaLivre(pos) && QtdMovimentos == 0)
                    m[pos.Linha, pos.Coluna] = true;

                // SE
                pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && ExisteInimigo(pos))
                    m[pos.Linha, pos.Coluna] = true;

                // SO
                pos.SetPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (!Tabuleiro.IsPosicaoInvalida(pos) && ExisteInimigo(pos))
                    m[pos.Linha, pos.Coluna] = true;
            }

            return m;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.GetPeca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool EstaLivre(Posicao pos)
        {
            return Tabuleiro.GetPeca(pos) == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
