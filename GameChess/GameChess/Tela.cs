using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.Generic;
using tabuleiro;
using Xadrez;

// Como é uma classe de manipulação de tela, ela fica junto a classe programa.

namespace GameChess
{
    class Tela
    {
        // Metodo para imprimir as informações da partida.

        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirtabuleiro(partida.tab);
            Console.WriteLine();
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        // Metodo para imprimir as peças capturadas de cada cor.

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.WriteLine();
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Preta: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.WriteLine();

            Console.ForegroundColor = aux;
        }

        // Metodo para imprimir o conjunto das peças capturadas.

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

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
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("-");
                Console.ForegroundColor = aux;
                
            }
            else
            {
                if (peca.cor == Cor.Preta)
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
            Console.Write(" ");
        }

    }
}
