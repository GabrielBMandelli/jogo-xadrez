using System;
using JogoXadrez.Entidades;
using JogoXadrez.Enums;

namespace JogoXadrez
{
    class Tela
    {
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
