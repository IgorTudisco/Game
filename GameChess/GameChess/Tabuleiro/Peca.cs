
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

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        // Testando se a peca tem algum movimento possivel

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j = 0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Metodo auxiliar

        public bool movimentoPossivel(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        // Criando um metodo abstrato para restringir o movimento da peca (a classe vira abstrata)
        // de acordo com o tipo da peca Rei, Cavalo... e assim por diante.
        // Será do tipo bool porque os movimentos vão gerar uma tabela vedade (matriz boleana).

        public abstract bool[,] movimentosPossiveis();

    }
}
