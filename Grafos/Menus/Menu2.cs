using Grafos.Algoritmos;
using Grafos.Classes.ListaAdjacencia;
using Grafos.Classes.MatrizAdjacencia;
using Grafos.Interfaces;
using Grafos.LeitorDimac;

namespace Grafos.Menus
{
    public class Menu2
    {
        private IGrafo? grafo;
        private const string SOLICITA_VERTICE = "Vértice ";
        private const string SOLICITA_ORIGEM = "Vértice de origem ";
        private const string SOLICITA_DESTINO = "Vértice de destino ";

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
                            if (grafo == null)
                            {
                                Console.WriteLine("\nGrafo ainda não foi carregado!");
                                break;
                            }

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
            Console.Write("\nDigite o caminho do arquivo: ");
            var caminho = Console.ReadLine();

            grafo = null;

            try
            {
                grafo = DimacReader.LerArquivo(caminho);
                Console.WriteLine("\nGrafo obtido com sucesso!");
                RepresentarGrafo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao ler o grafo: {ex.Message}");
            }
        }

        private void InteragirComGrafo()
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
                Console.WriteLine("6 - Verificar se dois vértices são adjacentes");
                Console.WriteLine("7 - Substituir o peso de uma aresta");
                Console.WriteLine("8 - Trocar dois vértices");
                Console.WriteLine("9 - Busca em Largura");
                Console.WriteLine("10 - Busca em Profundidade");
                Console.WriteLine("11 - Dijkstra");
                Console.WriteLine("12 - Floyd-Warshall");
                Console.WriteLine("13 - Exibir representação do grafo");
                Console.WriteLine("0 - Voltar");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            ImprimirArestasAdjacentes();
                            break;
                        case 2:
                            ImprimirVerticesAdjacentes();
                            break;
                        case 3:
                            ImprimirArestasIncidentes();
                            break;
                        case 4:
                            ImprimirVerticesIncidentais();
                            break;
                        case 5:
                            ImprimirGrauVertice();
                            break;
                        case 6:
                            DeterminarAdjacencia();
                            break;
                        case 7:
                            SubstituirPesoAresta();
                            break;
                        case 8:
                            TrocarVertices();
                            break;
                        case 9:
                            BuscaLargura();
                            break;
                        case 10:
                            BuscaProfundidade();
                            break;
                        case 11:
                            Dijkstra();
                            break;
                        case 12:
                            FloydWarshall();
                            break;
                        case 13:
                            RepresentarGrafo();
                            break;
                        case 0:
                            return;
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

        private bool EhListaAdjacencia()
        {
            return grafo is GrafoListaAdjacencia;
        }

        private void SolicitarAresta(out int origem, out int destino)
        {
            var quantidadeVertices = grafo?.ObterTodosVertices().Count;

            Console.Write(SOLICITA_ORIGEM + $"(1-{quantidadeVertices}): ");
            origem = int.Parse(Console.ReadLine());
            Console.Write(SOLICITA_DESTINO + $"(1-{quantidadeVertices}): ");
            destino = int.Parse(Console.ReadLine());
        }

        private void SolicitarVertice(out int vertice)
        {
            var quantidadeVertices = grafo?.ObterTodosVertices().Count;

            Console.Write(SOLICITA_VERTICE + $"(1-{quantidadeVertices}): ");
            vertice = int.Parse(Console.ReadLine());
        }

        private void ImprimirArestasAdjacentes()
        {
            try
            {
                SolicitarAresta(out int origem, out int destino);

                var arestasAdjacentes = grafo?.ObterAdjacenciasDaAresta(origem, destino);

                if (arestasAdjacentes.Count > 0)
                {
                    Console.Write($"\nArestas adjacentes à aresta ({origem}, {destino}): ");

                    foreach (var aresta in arestasAdjacentes)
                    {
                        Console.Write($"({aresta.Origem.Id}, {aresta.Destino.Id}) ");
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Nenhuma aresta adjacente encontrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ImprimirVerticesAdjacentes()
        {
            try
            {
                SolicitarVertice(out int vertice);

                var verticesAdjacentes = grafo?.ObterVizinhanca(vertice);

                if (verticesAdjacentes?.Count > 0)
                {
                    Console.Write($"\nVértices adjacentes ao vértice {vertice}: ");

                    foreach (var v in verticesAdjacentes)
                    {
                        Console.Write(v.Id + " ");
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Nenhum vértice adjacente encontrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ImprimirArestasIncidentes()
        {
            try
            {
                SolicitarVertice(out int vertice);

                var arestasIncidentes = grafo?.ObterArestasIncidentes(vertice);

                if (arestasIncidentes?.Count > 0)
                {
                    Console.Write($"\nArestas incidentes ao vértice {vertice}: ");

                    foreach (var aresta in arestasIncidentes)
                    {
                        Console.Write($"({aresta.Origem.Id}, {aresta.Destino.Id}) ");
                    }
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("Nenhuma aresta incidente encontrada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ImprimirVerticesIncidentais()
        {
            try
            {
                SolicitarAresta(out int origem, out int destino);
                var (verticeOrigem, verticeDestino) = grafo?.ObterVerticesIncidentes(origem, destino) ?? (0, 0);

                if (verticeOrigem != 0 && verticeDestino != 0)
                {
                    Console.WriteLine($"Vértices incidentes à aresta ({origem}, {destino}): ({verticeOrigem}, {verticeDestino})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        private void ImprimirGrauVertice()
        {
            try
            {
                SolicitarVertice(out int vertice);
                Console.WriteLine($"\nGrau do vértice {vertice}: {grafo?.ObterGrauDoVertice(vertice)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeterminarAdjacencia()
        {
            try
            {
                SolicitarAresta(out int origem, out int destino);
                Console.Write($"\nOs vértices {origem} e {destino} são adjacentes?");
                Console.WriteLine(grafo.VerificarAdjacenciaEntreVertices(origem, destino) ? " Sim" : " Não");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SubstituirPesoAresta()
        {
            try
            {
                SolicitarAresta(out int origem, out int destino);
                Console.Write("Digite o novo peso: ");
                var peso = int.Parse(Console.ReadLine());

                grafo?.SubstituirPesoAresta(origem, destino, peso);
                Console.WriteLine("\nPeso substituído com sucesso!");
                RepresentarGrafo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TrocarVertices()
        {
            try
            {
                SolicitarAresta(out int origem, out int destino);

                grafo?.TrocarVertices(origem, destino);
                Console.WriteLine("\nVértices trocados com sucesso!");
                RepresentarGrafo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BuscaLargura()
        {
            try
            {
                SolicitarVertice(out int origem);

                grafo?.ExecutarBuscaEmLargura(origem).GerarTabelaBuscaEmLargura();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BuscaProfundidade()
        {
            try
            {
                SolicitarVertice(out int origem);

                var temCiclo = grafo?.ExecutarBuscaEmProfundidade(origem);

                if (temCiclo.HasValue && temCiclo.Value)
                    Console.WriteLine("\nO grafo possui ciclo.");
                else
                    grafo.GerarTabelaBuscaEmProfundidade();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Dijkstra()
        {
            try
            {
                SolicitarVertice(out int origem);

                grafo?.ExecutarDijkstra(origem);
                grafo?.ImprimirTabelaCaminhoMinimo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FloydWarshall()
        {
            try
            {
                if (!EhListaAdjacencia())
                {
                    var floydWarshall = ((GrafoMatrizAdjacencia)grafo)?.ExecutarFloydWarshall();
                    ((GrafoMatrizAdjacencia)grafo).GerarTabelaDistancias(floydWarshall);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RepresentarGrafo()
        {
            try
            {
                Console.WriteLine("\n=== Representação do Grafo ===");
                grafo?.ExibirRepresentacao();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
