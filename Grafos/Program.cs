using Grafos.Algoritmos;
using Grafos.Interfaces;

namespace Grafos
{
    public class Program
    {
        public static void Main()
        {
            var grafo = LeitorDimac.DimacReader.LerArquivo("C:\\Users\\igorl\\OneDrive\\Documentos\\Projetos\\Trabalho_Grafos_3Semestre\\Grafos\\testeDimac.txt");

            grafo.Representacao();

            var teste = grafo.BuscaProfunda(1); //Ver se tem loop

            grafo.ExecutarDijkstra(1);

            grafo.ImprimirTabelaCaminhoMinimo();

            var teste2 = grafo as IMatrizAdjacencia;

            teste2.GerarTabelaDistancias(teste2.ExecutarFloydWarshall());
        }
    }
}