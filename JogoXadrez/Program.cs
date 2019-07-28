namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro.Entidades.Tabuleiro tab = new Tabuleiro.Entidades.Tabuleiro(8, 8);
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
