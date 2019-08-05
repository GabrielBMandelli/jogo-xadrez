using System.Collections.Generic;
using JogoXadrez.Enums;
using JogoXadrez.Exceptions;

namespace JogoXadrez.Entidades
{
    class Partida
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public bool Xeque { get; private set; }

        private HashSet<Peca> PecasVivas;
        private HashSet<Peca> PecasCapturadas;

        public Partida()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            PecasVivas = new HashSet<Peca>();
            PecasCapturadas = new HashSet<Peca>();

            IniciarPecas();
        }

        public void MoverPeca(Posicao origem, Posicao destino)
        {
            Peca pecaMovimentada = Tabuleiro.RetirarPeca(origem);
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);

            Tabuleiro.ColocarPeca(pecaMovimentada, destino);
            pecaMovimentada.IncrementarMovimento();

            if (pecaCapturada != null)
            {
                PecasVivas.Remove(pecaCapturada);
                PecasCapturadas.Add(pecaCapturada);
            }

            if (ReiEstaEmXeque(JogadorAtual))
            {
                Tabuleiro.RetirarPeca(destino);
                Tabuleiro.ColocarPeca(pecaMovimentada, origem);
                
                if (pecaCapturada != null)
                {
                    Tabuleiro.ColocarPeca(pecaCapturada, destino);
                    PecasVivas.Add(pecaCapturada);
                    PecasCapturadas.Remove(pecaCapturada);
                }

                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }
        }

        public void ValidarOrigem(Posicao origem)
        {
            if (!Tabuleiro.ExistePeca(origem))
            {
                throw new TabuleiroException("Não existe peça na posição de origem!");
            }

            if (Tabuleiro.GetPeca(origem).Cor != JogadorAtual)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tabuleiro.GetPeca(origem).ExisteMovimentoPossivel())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarDestino(bool[,] m, Posicao destino)
        {
            if (!m[destino.Linha, destino.Coluna])
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public void RealizarJogada(Posicao origem, Posicao destino)
        {
            MoverPeca(origem, destino);
            Turno++;
            JogadorAtual = (JogadorAtual == Cor.Branca) ? Cor.Preta : Cor.Branca;
            Xeque = ReiEstaEmXeque(JogadorAtual);
        }

        public HashSet<Peca> GetPecasCapturadas(Cor cor)
        {
            HashSet<Peca> pecasCapturadas = new HashSet<Peca>();

            foreach (Peca p in PecasCapturadas)
            {
                if (p.Cor == cor)
                    pecasCapturadas.Add(p);
            }

            return pecasCapturadas;
        }

        public HashSet<Peca> GetPecasVivas(Cor cor)
        {
            HashSet<Peca> pecasVivas = new HashSet<Peca>();

            foreach (Peca p in PecasVivas)
            {
                if (p.Cor == cor)
                    pecasVivas.Add(p);
            }

            return pecasVivas;
        }

        public bool ReiEstaEmXeque(Cor cor)
        {
            Peca rei = GetRei(cor);

            HashSet<Peca> pecasAdversarias = (cor == Cor.Branca) ? GetPecasVivas(Cor.Preta) : GetPecasVivas(Cor.Branca);

            foreach (Peca p in pecasAdversarias)
            {
                bool[,] m = p.GetMovimentosPossiveis();

                if (m[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }

            return false;
        }

        public Peca GetRei(Cor cor)
        {
            foreach (Peca p in GetPecasVivas(cor))
            {
                if (p is Rei)
                    return p;
            }

            return null;
        }

        public void ColocarPeca(Peca peca, Posicao pos)
        {
            Tabuleiro.ColocarPeca(peca, pos);
            PecasVivas.Add(peca);
        }

        public void IniciarPecas()
        {
            // PECAS BRANCAS
            ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 1).ToPosicao());
            ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 1).ToPosicao());
            ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            ColocarPeca(new Dama(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 1).ToPosicao());
            ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 1).ToPosicao());
            ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 1).ToPosicao());

            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 2).ToPosicao());
            ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 2).ToPosicao());

            // PECAS PRETAS
            ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 8).ToPosicao());
            ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 8).ToPosicao());
            ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            ColocarPeca(new Dama(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
            ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 8).ToPosicao());
            ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
            ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 8).ToPosicao());

            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 7).ToPosicao());
            ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 7).ToPosicao());
        }
    }
}
