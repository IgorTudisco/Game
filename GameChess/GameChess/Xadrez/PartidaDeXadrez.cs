using System;
using tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPeca();
            terminada = false;
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.imcrementarQteMovimentos();
            Peca capturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPeca()
        {
            //Pecas Brancas

            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1 , 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1, 'd').toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez(2, 'd').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1, 'e').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'e').toPosicao());

            // Pecas Pretas

            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(8, 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'd').toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez(8, 'd').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'e').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(8, 'e').toPosicao());

        }





    }
}
