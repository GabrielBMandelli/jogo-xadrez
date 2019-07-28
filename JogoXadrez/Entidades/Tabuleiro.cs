using JogoXadrez.Exceptions;

namespace JogoXadrez.Entidades
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPeca(int linha, int coluna)
        {
            return GetPeca(new Posicao(linha, coluna));
        }

        public Peca GetPeca(Posicao pos)
        {
            if (IsPosicaoInvalida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }

            return Pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca peca, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            Pecas[pos.Linha, pos.Coluna] = peca;
            peca.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            Peca pecaRemovida = null;

            if (ExistePeca(pos))
            {
                pecaRemovida = Pecas[pos.Linha, pos.Coluna];
                pecaRemovida.Posicao = null;
                Pecas[pos.Linha, pos.Coluna] = null;
            }

            return pecaRemovida;
        }

        public bool IsPosicaoInvalida(Posicao pos)
        {
            return pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas;
        }

        public bool ExistePeca(Posicao pos)
        {
            if (IsPosicaoInvalida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }

            return GetPeca(pos) != null;
        }
    }
}
