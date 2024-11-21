using Grafos.Classes.MatrizAdjacencia;
using Grafos.Interfaces;
using Grafos.Models;

namespace Grafos.Menus
{
    public class Menu
    {
        private IGrafo? _grafo;

        public void ExecutarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Principal ===");
                Console.WriteLine("1 - Criar novo grafo");
                Console.WriteLine("2 - Representar matriz de adjacência");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            CriarGrafo();
                            break;
                        case 2:
                            RepresentarMatriz();
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

        private void CriarGrafo()
        {
            try
            {
                Console.WriteLine("\n=== Criação do Grafo ===");

                Console.Write("Digite a quantidade de vértices: ");
                int numVertices = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Digite a quantidade de arestas: ");
                int numArestas = int.Parse(Console.ReadLine() ?? "0");

                // Calcula densidade
                double densidade = CalcularDensidade(numVertices, numArestas);
                Console.WriteLine($"\nDensidade do grafo: {densidade:F2}");

                // Decide representação baseado na densidade
                if (densidade > 0.5)
                {
                    Console.WriteLine("Usando Matriz de Adjacência (densidade > 0.5)");
                    _grafo = new GrafoMA();
                }
                else
                {
                    Console.WriteLine("Usando Lista de Adjacência (densidade <= 0.5)");
                    // Implementar classe de Lista de Adjacência
                    _grafo = new GrafoMA(); // Temporariamente usando MA
                }

                // Criar vértices
                var vertices = new List<Vertice>();
                for (int i = 1; i <= numVertices; i++)
                {
                    vertices.Add(new Vertice());
                }

                // Criar arestas
                var arestas = new List<Aresta>();
                Console.WriteLine("\nDigite as informações das arestas:");

                for (int i = 0; i < numArestas; i++)
                {
                    Console.WriteLine($"\nAresta {i + 1}:");

                    Console.Write("Vértice de origem (1 a {0}): ", numVertices);
                    int origem = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Vértice de destino (1 a {0}): ", numVertices);
                    int destino = int.Parse(Console.ReadLine() ?? "0");

                    Console.Write("Peso da aresta: ");
                    int peso = int.Parse(Console.ReadLine() ?? "0");

                    if (origem < 1 || origem > numVertices ||
                        destino < 1 || destino > numVertices)
                    {
                        throw new ArgumentException("Vértices inválidos!");
                    }

                    var arestaOrigem = vertices.Find(v => v.Id == origem);
                    var arestaDestino = vertices.Find(v => v.Id == destino);

                    if (arestaOrigem != null && arestaDestino != null)
                    {
                        arestas.Add(new Aresta(arestaOrigem, arestaDestino, peso));
                    }
                }

                _grafo.InicializaGrafo(vertices, arestas);
                Console.WriteLine("\nGrafo criado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao criar grafo: {ex.Message}");
            }
        }

        private void RepresentarMatriz()
        {
            if (_grafo == null)
            {
                Console.WriteLine("\nNenhum grafo foi criado ainda!");
                return;
            }

            if (_grafo is GrafoMA grafoMA)
            {
                grafoMA.Representacao();
            }
            else
            {
                Console.WriteLine("\nO grafo atual não é uma matriz de adjacência!");
            }
        }

        private double CalcularDensidade(int numVertices, int numArestas)
        {
            return numVertices <= 1 ? 0 : (double)numArestas / (numVertices * (numVertices - 1));
        }
    }
}
