namespace Grafos.Models
{
    public enum ClassificacaoAresta
    {
        Nenhuma,
        ArestaArvore,
        ArestaDeRetorno,
        ArestaDeAvanco,
        ArestaDeCruzamento
    }

    public class Aresta
    {
        public Vertice Origem { get; set; }
        public Vertice Destino { get; set; }
        public int Peso { get; set; }
        public ClassificacaoAresta classificacaoAresta { get; set; }

        public Aresta(Vertice origem, Vertice destino, int peso)
        {
            Origem = origem;
            Destino = destino;
            Peso = peso;
        }
    }
}
