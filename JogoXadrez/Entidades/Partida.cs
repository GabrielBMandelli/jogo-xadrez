﻿using JogoXadrez.Enums;

namespace JogoXadrez.Entidades
{
    class Partida
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno { get; set; }
        private Cor JogadorAtual { get; set; }
        public bool Terminada { get; private set; }

        public Partida()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;

            IniciarPecas();
        }

        public void MoverPeca(Posicao origem, Posicao destino)
        {
            Peca pecaMovimentada = Tabuleiro.RetirarPeca(origem);
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);

            if (pecaMovimentada != null)
            {
                pecaMovimentada.IncrementarMovimento();
                Tabuleiro.ColocarPeca(pecaMovimentada, destino);
            }
        }

        public void IniciarPecas()
        {
            // PECAS BRANCAS
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 1).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 1).ToPosicao());

            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('a', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('b', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('f', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('g', 2).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Branca, Tabuleiro), new PosicaoXadrez('h', 2).ToPosicao());

            // PECAS PRETAS
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Dama(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Bispo(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Cavalo(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
            Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 8).ToPosicao());

            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('a', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('b', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('f', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 7).ToPosicao());
            Tabuleiro.ColocarPeca(new Peao(Cor.Preta, Tabuleiro), new PosicaoXadrez('h', 7).ToPosicao());
        }
    }
}
