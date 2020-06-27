
namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null; // a peca começa na posicao 0,0.
            this.cor = cor;
            this.tab = tab;
            this.qteMovimentos = 0;
        }

      


    }
}
