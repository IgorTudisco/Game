using System;
using tabuleiro;
using Xadrez;

namespace GameChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PosicaoXadrez pos = new PosicaoXadrez('c', 7);

                Console.WriteLine(pos);
                Console.WriteLine(pos.toPosicao());

                Console.ReadLine();
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }


        }
    }
}
