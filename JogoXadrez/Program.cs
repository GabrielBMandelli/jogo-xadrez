using System;
using JogoXadrez.Entidades;
using JogoXadrez.Enums;
using JogoXadrez.Exceptions;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.AddPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
                tab.AddPeca(new Rei(Cor.Preta, tab), new Posicao(0, 3));
                tab.AddPeca(new Torre(Cor.Preta, tab), new Posicao(0, 7));

                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
