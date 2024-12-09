namespace Trabalho
{
    class URI
    {
        static void Main(string[] args)
        {
            var (grafo, nivel) = LeitorDesafio();
            var resposta = new List<Vertice>();
            grafo.ExecutarBFS(nivel, resposta);

            resposta.GerarTabelaBuscaEmLargura();
        }


        public static (GrafoMatrizAdjacencia, int) LeitorDesafio()
        {
            string[] primeiraLinha = Console.ReadLine().Split(' ');

            int numVertices = int.Parse(primeiraLinha[0]);
            int nivel = int.Parse(primeiraLinha[1]);

            var vertices = new List<Vertice>();
            var arestas = new List<Aresta>();
            var nomes = new HashSet<string>();

            for (int i = 0; i < numVertices; i++)
            {
                var linha = Console.ReadLine();
                CriarVertices(nomes, vertices, linha);
                PreencherArestas(vertices, arestas, linha);
            }

            return (new GrafoMatrizAdjacencia().InicializarGrafo(vertices, arestas), nivel);
        }

        private static void CriarVertices(HashSet<string> nomes, List<Vertice> vertices, string linha)
        {
            foreach (var nome in linha.Split(' '))
            {
                if (nomes.Add(nome))
                    vertices.Add(new Vertice(nome));
            }
        }

        private static void PreencherArestas(List<Vertice> vertices, List<Aresta> arestas, string linha)
        {
            var valores = linha.Split(' ');
            var origem = vertices.Find(v => v.Nome == valores[0]);
            var destino = vertices.Find(v => v.Nome == valores[1]);

            arestas.Add(new Aresta(origem, destino, 1));
            arestas.Add(new Aresta(destino, origem, 1));
        }
    }

    public class Vertice
    {
        private static int ContadorId = 0;
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Nivel { get; set; }

        public Vertice(string nome)
        {
            Id = ++ContadorId;
            Nome = nome;
        }

        public void ResetBuscaEmLargura()
        {
            Nivel = 0;
        }

        public int ObterNivelBuscaEmLargura()
        {
            return Nivel;
        }

        public void DefinirNivelBuscaEmLargura(int nivel)
        {
            Nivel = nivel;
        }
    }

    public class Aresta
    {
        public Vertice Origem { get; set; }
        public Vertice Destino { get; set; }
        public int Peso { get; set; }

        public Aresta(Vertice origem, Vertice destino, int peso)
        {
            Origem = origem;
            Destino = destino;
            Peso = peso;
        }
    }

    public class GrafoMatrizAdjacencia
    {
        public Aresta[,] MatrizDeAdjacencia { get; set; }
        public List<Vertice> Vertices { get; set; }

        public GrafoMatrizAdjacencia InicializarGrafo(List<Vertice> vertices, List<Aresta> arestas)
        {
            Vertices = vertices;
            var matriz = new Aresta[vertices.Count + 1, vertices.Count + 1];

            foreach (var aresta in arestas)
            {
                matriz[aresta.Origem.Id, aresta.Destino.Id] = aresta;
            }

            MatrizDeAdjacencia = matriz;
            return this;
        }

        public Vertice ObterVertice(int id)
        {
            var vertice = Vertices.FirstOrDefault(v => v.Id == id);
            if (vertice == null)
                throw new ArgumentException($"Vértice com ID {id} não encontrado.");
            return vertice;
        }

        public List<Vertice> ObterTodosVertices()
        {
            return Vertices;
        }

        public List<Aresta> ObterTodasArestas()
        {
            var arestas = new List<Aresta>();
            for (int i = 1; i <= Vertices.Count; i++)
            {
                for (int j = 1; j <= Vertices.Count; j++)
                {
                    if (MatrizDeAdjacencia[i, j] != null)
                        arestas.Add(MatrizDeAdjacencia[i, j]);
                }
            }
            return arestas;
        }

        public List<Aresta> ObterArestasAdjacentes(int idVertice)
        {
            var arestasAdjacentes = new List<Aresta>();
            for (int i = 1; i <= Vertices.Count; i++)
            {
                if (MatrizDeAdjacencia[idVertice, i] != null)
                    arestasAdjacentes.Add(MatrizDeAdjacencia[idVertice, i]);
            }
            return arestasAdjacentes;
        }
    }

    public static class BuscaEmLargura
    {
        public static void ExecutarBFS(this GrafoMatrizAdjacencia Grafo, int Nivel, List<Vertice> Resposta)
        {
            var vertices = Grafo.ObterTodosVertices().ToList();
            vertices.ForEach(x => x.ResetBuscaEmLargura());

            var rerisson = vertices.First(x => x.Nome == "Rerisson");
            rerisson.DefinirNivelBuscaEmLargura(0); // Começa do nível 1

            var fila = new Queue<Vertice>();
            fila.Enqueue(rerisson);

            while (fila.Count > 0)
            {
                var verticeAtual = fila.Dequeue();

                foreach (var aresta in Grafo.ObterArestasAdjacentes(verticeAtual.Id).OrderBy(aresta => aresta.Destino.Id).ToList())
                {
                    var destino = aresta.Destino;

                    if (destino.ObterNivelBuscaEmLargura() == 0)
                    {
                        int novoNivel = verticeAtual.ObterNivelBuscaEmLargura() + 1;
                        destino.DefinirNivelBuscaEmLargura(novoNivel);

                        if (novoNivel <= Nivel)
                        {
                            fila.Enqueue(destino);

                            if (destino.Nome != "Rerisson")
                            {
                                Resposta.Add(destino);
                            }
                        }
                    }
                }
            }
        }

        public static void GerarTabelaBuscaEmLargura(this List<Vertice> vertices)
        {
            var verticesFiltrados = vertices
                .Where(v => v.Nome != "Rerisson")
                .OrderBy(v => v.Nome).ToList();

            if (verticesFiltrados.Count == 0)
                return;


            Console.WriteLine(verticesFiltrados.Count);
            foreach (var vertice in verticesFiltrados)
            {
                Console.WriteLine(vertice.Nome);
            }
        }
    }
}