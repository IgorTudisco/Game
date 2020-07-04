
namespace tabuleiro
{
    abstract class Peca
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

        public void imcrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        // Criando um metodo abstrato para restringir o movimento da peca (a classe vira abstrata)
        // de acordo com o tipo da peca Rei, Cavalo... e assim por diante.
        // Será do tipo bool porque os movimentos vão gerar uma tabela vedade (matriz boleana).

        public abstract bool[,] movimentosPossiveis();

    }
}
