using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public bool xeque { get; private set; }

        // Conjuntos das peças

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;

            // É importante que os conjuntos venha antes do metodo colocar peças.

            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPeca();
            terminada = false;
            xeque = false;
        }

        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.imcrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
            // caso tenha alguma peça na posição de destino, a mesma será capturada e add no HashSet.
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }


        // Metodo para desfazer o movimento se você se por em xeque.

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);
        }

        // Metodo para que cada jogador jogue uma unica vez.

        public void realizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);

            // condição para impedir um movimento que te coloque em xeque.

            if (estaEmXaque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }

            if (estaEmXaque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudarJogador();
            }
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

        // Metodo para separar as peças brancas de preta dentro do HashSet.

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        // Metodo para saber quais peças ainda estão em jogo.

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        // Metodo de adversário.

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        // Metodo para saber qual grupo o Rei pertence.

        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        // Metodo que testa os movimentos possiveis tododas as peças e retorna se o rei está em xaque.

        public bool estaEmXaque(Cor cor)
        {
            Peca R = rei(cor);
            // tratamento de segurança
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da " + cor + "no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        // Metodo para testar se tem algum movimento possível que tire o rei do XequeMate.

        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXaque(cor))
            {
                return false;
            }
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();

                for (int i = 0; i < tab.linhas; i++)
                {
                    for (int j = 0; j<tab.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXaque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        // Metodo auxiliar para colocar as peças no tabuleiro e quardar no HashSet.

        public void colocarNovaPeca(int linha, char coluna, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(linha, coluna).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPeca()
        {
            //Pecas Brancas

            
            colocarNovaPeca(1, 'c', new Torre(tab, Cor.Branca));
            colocarNovaPeca(1, 'd', new Rei(tab, Cor.Branca));
            colocarNovaPeca(7, 'h', new Torre(tab, Cor.Branca));
            

            // Pecas Pretas

            colocarNovaPeca(8, 'a', new Rei(tab, Cor.Preta));
            colocarNovaPeca(8, 'b', new Torre(tab, Cor.Preta));
            
        }





    }
}
