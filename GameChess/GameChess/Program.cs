using System;
using tabuleiro;

namespace GameChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            Tela.imprimirtabuleiro(tab);

            Console.ReadLine();

        }
    }
}
