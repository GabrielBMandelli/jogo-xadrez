using System;
using JogoXadrez.Entidades;

namespace JogoXadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    string s = (tabuleiro.GetPeca(i, j) == null) ? "- " : $"{tabuleiro.GetPeca(i, j)} ";
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }
    }
}
