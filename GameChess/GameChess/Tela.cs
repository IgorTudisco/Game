using System;
using System.Runtime.InteropServices.WindowsRuntime;
using tabuleiro;
using Xadrez;

// Como é uma classe de manipulação de tela, ela fica junto a classe programa.

namespace GameChess
{
    class Tela
    {
        // Sendo static o atributo não precisa ser instanciado

        public static void imprimirtabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));
                    Console.Write(" ");

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h ");
        }

        // Imprimir o tabuleiro com as possiveis posicoes destacadas (sobrecarga)

        public static void imprimirtabuleiro(Tabuleiro tab, bool[,] posicoesPosiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPosiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                    Console.Write(" ");
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a  b  c  d  e  f  g  h ");
            // Para garantir que vamos voltar para o fundo original
            Console.BackgroundColor = fundoOriginal;
        }

        // Metodo para ler o teclado do usuario. Irá ler o que for digitado

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(linha, coluna);
        }

        // Criando um metodo para mudar a cor das peças.

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
