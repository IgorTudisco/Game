using tabuleiro;

namespace Xadrez
{

    // classe para começar a colocar os nomes de cada posição do jogo de xadrez

    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        // metodo de converção
        // As letras corespondem a um numero sendo a = 0, b = 1 e assim por diante.

        public Posicao toPosicao()
        {
            return new Posicao(coluna - 'a', 8 - linha);
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }


    }
}
