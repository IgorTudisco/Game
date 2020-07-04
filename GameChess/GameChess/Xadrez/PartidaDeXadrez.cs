using System;
using System.Runtime.CompilerServices;
using tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        // Metodo para que cada jogador jogue uma unica vez.

        public void realizarJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        // Metodo que trata os possíveis erros

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        // Validando a movimentação de peça

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void mudarJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        private void colocarPeca()
        {
            //Pecas Brancas

            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1, 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'c').toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'd').toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez(1, 'd').toPosicao());
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
