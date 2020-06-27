using System;
using tabuleiro;

// Como é uma classe de manipulação de tela, ela fica junto a classe programa.

namespace GameChess
{
    class Tela
    {
        // Sendo static o atributo não precisa ser instanciado

        public static void imprimirtabuleiro(Tabuleiro tab)
        {


            for(int i = 0; i<tab.linhas ; i++)
            {
                for ( int j = 0; j < tab.colunas ; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("-" + " ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
