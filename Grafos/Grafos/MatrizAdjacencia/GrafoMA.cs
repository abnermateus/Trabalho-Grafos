using Grafos.Interfaces;
using Grafos.Models;

namespace Grafos.Classes.MatrizAdjacencia
{
    public class GrafoMA : IGrafo
    {
        public int[,]? MatrizDeAdjacencia { get; set; }
        public List<Aresta>? Arestas { get; set; }
        public List<Vertice>? Vertices { get; set; }

        public GrafoMA()
        {
            Vertices = null;
            Arestas = null;
        }

        public GrafoMA(int[,] matriz, List<Aresta> arestas, List<Vertice> vertices)
        {
            MatrizDeAdjacencia = matriz;
            Vertices = vertices;
            Arestas = arestas;
        }

        public GrafoMA InicializaGrafo(List<Vertice> vertices, List<Aresta> arestas)
        {
            Vertices = vertices;
            Arestas = arestas;

            // Matriz é criada com tamanho + 1 para permitir uso direto dos IDs como índices
            // Índice 0 não é utilizado, simplificando o acesso à matriz
            var matriz = new int[vertices.Count + 1, vertices.Count + 1];

            foreach (var aresta in arestas)
            {
                matriz[aresta.Origem.Id, aresta.Destino.Id] = aresta.Peso;
            }

            MatrizDeAdjacencia = matriz;

            return this;
        }

        public void Representacao()
        {
            if (Vertices == null || Arestas == null)
                throw new InvalidOperationException("Grafo não inicializado");

            Console.WriteLine("\nMatriz de Adjacência:");

            Console.Write("   ");
            for (int i = 1; i <= Vertices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{i,3}");
                Console.ResetColor();
            }
            Console.WriteLine();

            Console.Write("   ");
            for (int i = 1; i <= Vertices.Count; i++)
                Console.Write("---");
            Console.WriteLine();

            for (int i = 1; i <= Vertices.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{i,2}");
                Console.ResetColor();
                Console.Write("|");

                for (int j = 1; j <= Vertices.Count; j++)
                {
                    var peso = MatrizDeAdjacencia[i, j];
                    if (peso == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{peso,3}");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
