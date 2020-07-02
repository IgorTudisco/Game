

namespace tabuleiro
{
    class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int coluna, int linha)
        {
            this.linha = linha;
            this.coluna = coluna;
        }


        public override string ToString()
        {
            return linha + ", " + coluna;
        }

    }
}
