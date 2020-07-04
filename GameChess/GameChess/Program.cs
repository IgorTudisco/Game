using System;
using System.Security;
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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                Tela.imprimirtabuleiro(partida.tab);

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirtabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    bool[,] pisicoesPosiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirtabuleiro(partida.tab, pisicoesPosiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }

                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }


        }
    }
}
