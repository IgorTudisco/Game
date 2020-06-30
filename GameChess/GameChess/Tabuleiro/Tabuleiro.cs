
using tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // Como a minha lista está bloqueada, temos que criar um metodo para acessar a peca.

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        // melhoria de posição

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        // Existe peça no tabuleiro 

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        // Colocando uma peca no tabuleiro

        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        // verificando o tamanho do tabuleiro

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        // exeção

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida ");
            }
        }


    }
}
