
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



    }
}
