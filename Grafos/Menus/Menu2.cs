using Grafos.Classes.MatrizAdjacencia;
using Grafos.Classes.ListaAdjacencia;
using Grafos.Interfaces;
using Grafos.Models;
using static Grafos.Utils.Utils;

namespace Grafos.Menus
{
    public class Menu2
    {
        private IGrafo? grafo;

        public void ExecutarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu 2 ===");
                Console.WriteLine("1 - Obter grafo Dimac de arquivo");
                Console.WriteLine("2 - Interagir com grafo obtido");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            LerArquivoDimac();
                            break;
                        case 2:
                            InteragirComGrafo();
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        
        private void LerArquivoDimac()
        {
           var dimac = new DimacReader();

           Console.Write("Digite o caminho do arquivo: ");
           var caminho = Console.ReadLine();

           try {
                grafo = dimac.LerArquivo(caminho);
           }
           catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao ler o grafo: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Grafo criado com sucesso!");
            }
        }

        private static void InteragirComGrafo()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Interações com o Grafo ===");
                Console.WriteLine("1 - Imprimir todas as arestas adjacentes a uma aresta");
                Console.WriteLine("2 - Imprimir todos os vértices adjacentes a um vértice");
                Console.WriteLine("3 - Imprimir todas as arestas incidentes a um vértice");
                Console.WriteLine("4 - Imprimir todos os vértices incidentes a uma aresta");
                Console.WriteLine("5 - Imprimir o grau do vértice");
                Console.WriteLine("6 - Determinar se dois vértices são adjacentes");
                Console.WriteLine("7 - Substituir o peso de uma aresta");
                Console.WriteLine("8 - Trocar dois vértices");
                Console.WriteLine("9 - Busca em Largura");
                Console.WriteLine("10 - Busca em Profundidade");
                Console.WriteLine("11 - Dijkstra");
                Console.WriteLine("12 - Floyd-Warshall");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    // switch (opcao)
                    // {
                    //     case 1:
                    //         ImprimirArestasAdjacentes();
                    //         break;
                    //     case 2:
                    //         ImprimirVerticesAdjacentes();
                    //         break;
                    //     case 3:
                    //         ImprimirArestasIncidentes();
                    //         break;
                    //     case 4:
                    //         ImprimirVerticesIncidentais();
                    //         break;
                    //     case 5:
                    //         ImprimirGrauVertice();
                    //         break;
                    //     case 6:
                    //         DeterminarAdjacencia();
                    //         break;
                    //     case 7:
                    //         SubstituirPesoAresta();
                    //         break;
                    //     case 8:
                    //         TrocarVertices();
                    //         break;
                    //     case 9:
                    //         BuscaLargura();
                    //         break;
                    //     case 10:
                    //         BuscaProfundidade();
                    //         break;
                    //     case 11:
                    //         Dijkstra();
                    //         break;
                    //     case 12:
                    //         FloydWarshall();
                    //         break;
                    //     case 0:
                    //         return;
                    //     default:
                    //         Console.WriteLine("Opção inválida!");
                    //         break;
                    // }
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }
    }
}
