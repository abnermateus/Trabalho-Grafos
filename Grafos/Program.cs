using Grafos.Algoritmos;
using Grafos.Interfaces;
using Grafos.Menus;

namespace Grafos
{
    public class Program
    {
        public static void Main()
        {
            // var grafo = LeitorDimac.DimacReader.LerArquivo("C:\\Users\\igorl\\OneDrive\\Documentos\\Projetos\\Trabalho_Grafos_3Semestre\\Grafos\\testeDimac.txt");

            // grafo.ExibirRepresentacao();

            // var teste = grafo.ExecutarBuscaEmProfundidade(1); //Ver se tem loop

            // grafo.ExecutarDijkstra(1);

            // grafo.ImprimirTabelaCaminhoMinimo();

            // var teste2 = grafo as IMatrizAdjacencia;

            // teste2.GerarTabelaDistancias(teste2.ExecutarFloydWarshall());

            // grafo.ExecutarBuscaEmLargura(1).GerarTabelaBuscaEmLargura();

            // var (GrafoDesafio, Nivel) = LeitorDimac.DesafioReader.LerArquivo("C:\\Users\\igorl\\OneDrive\\Documentos\\Projetos\\Trabalho_Grafos_3Semestre\\Grafos\\TesteDesafio.txt");

            // GrafoDesafio.ExecutarBuscaEmLargura(1).GerarTabelaBuscaEmLargura(3);

            Menu menu = new Menu();
            menu.ExecutarMenu();
        }
    }
}