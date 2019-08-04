using System;
using System.Collections.Generic;
using System.Text;
using JogoXadrez.Entidades;
using JogoXadrez.Enums;

namespace JogoXadrez
{
    class Tela
    {
        public static void ImprimirPartida(Partida partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: {0}", partida.Turno);
            Console.WriteLine("Aguardando jogada: {0}", partida.JogadorAtual);
        }

        public static void ImprimirPecasCapturadas(Partida partida)
        {
            Console.WriteLine("Peças capturadas:");
            Cor cor;

            // Imprimir pecas brancas capturadas
            cor = Cor.Branca;
            ImprimirConjunto(cor, partida.GetPecasCapturadas(cor));

            // Imprimir pecas pretas capturadas
            cor = Cor.Preta;
            ImprimirConjunto(cor, partida.GetPecasCapturadas(cor));
        }

        public static void ImprimirConjunto(Cor cor, HashSet<Peca> pecas)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"{cor}s: ");
            builder.Append("[");

            foreach (Peca p in pecas)
            {
                builder.Append($" {p} ");
            }

            builder.Append("]");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = (cor == Cor.Preta) ? ConsoleColor.Yellow : ConsoleColor.White;

            Console.WriteLine(builder.ToString());

            Console.ForegroundColor = aux;
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] m = null)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                ImprimirPosicaoXadrez($"{8 - i} ", false);

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ConsoleColor corDeFundo = (m != null && m[i, j]) ? ConsoleColor.DarkGray : ConsoleColor.Black;
                    ImprimirPeca(tabuleiro.GetPeca(i, j), corDeFundo);
                }

                Console.WriteLine();
            }

            ImprimirPosicaoXadrez("  a b c d e f g h ", true);
        }

        public static Posicao LerPosicao()
        {
            string s = Console.ReadLine();

            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());

            return new PosicaoXadrez(coluna, linha).ToPosicao();
        }

        private static void ImprimirPeca(Peca peca, ConsoleColor fundo)
        {
            Console.BackgroundColor = fundo;

            string s = (peca == null) ? "- " : $"{peca} ";

            ConsoleColor aux = Console.ForegroundColor;

            if (peca != null)
                Console.ForegroundColor = (peca.Cor == Cor.Preta) ? ConsoleColor.Yellow : aux;

            Console.Write(s);
            Console.ForegroundColor = aux;
        }

        private static void ImprimirPosicaoXadrez(string s, bool writeLine)
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            if (writeLine)
                Console.WriteLine(s);
            else
                Console.Write(s);

            Console.ForegroundColor = aux;
        }
    }
}
