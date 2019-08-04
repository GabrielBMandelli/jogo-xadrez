using System;
using JogoXadrez.Entidades;
using JogoXadrez.Exceptions;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Partida partida = new Partida();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);
                    Console.WriteLine();

                    try
                    {
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicao();
                        partida.ValidarOrigem(origem);

                        bool[,] movimentosPossiveis = partida.Tabuleiro.GetPeca(origem).GetMovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, movimentosPossiveis);
                        Console.WriteLine();

                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicao();
                        partida.ValidarDestino(movimentosPossiveis, destino);

                        partida.RealizarJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
