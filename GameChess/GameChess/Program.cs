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
                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] pisicoesPosiveis = partida.tab.peca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirtabuleiro(partida.tab, pisicoesPosiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizarJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
                Console.ReadLine();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
