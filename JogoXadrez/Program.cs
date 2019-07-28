using JogoXadrez.Entidades;
using JogoXadrez.Enums;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.AddPeca(new Torre(Cor.Branca, tab), new Posicao(0, 0));
            tab.AddPeca(new Rei(Cor.Branca, tab), new Posicao(0, 3));
            tab.AddPeca(new Torre(Cor.Branca, tab), new Posicao(0, 7));

            Tela.ImprimirTabuleiro(tab);
        }
    }
}
