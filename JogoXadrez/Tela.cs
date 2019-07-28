using System;
using JogoXadrez.Entidades;
using JogoXadrez.Enums;

namespace JogoXadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                ImprimirPosicaoXadrez($"{8 - i} ", false);

                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (tabuleiro.GetPeca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tabuleiro.GetPeca(i, j));
                        Console.Write(" ");
                    }
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

        private static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Preta)
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                Console.Write(peca);
            }
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
