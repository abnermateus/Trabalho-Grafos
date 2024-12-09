using System.Text;
using Grafos.Interfaces;
using Grafos.Models;

namespace Grafos.Algoritmos
{
    public static class BuscaEmProfundidade
    {
        private static int Tempo = 0;
        private static IGrafo? Grafo;
        private static readonly bool EhDirecionado = true;

        public static bool ExecutarBuscaEmProfundidade(this IGrafo GrafoAtual, int IdVertice)
        {
            Tempo = 0;
            Grafo = GrafoAtual;

            Grafo.ObterTodasArestas().ToList().ForEach(aresta => aresta.Tipo = ClassificacaoAresta.Nenhuma);
            Grafo.ObterTodosVertices().ToList().ForEach(vertice => vertice.ResetBuscaEmProfundidade());

            while (Grafo.ObterTodosVertices().Any(vertice => vertice.ObterTempoDescoberta() == 0))
            {
                if (Tempo != 0)// Para Grafos desconexos
                    IdVertice = Grafo.ObterTodosVertices().First(vertice => vertice.ObterTempoDescoberta() == 0).Id;

                var vertice = Grafo.ObterTodosVertices()[IdVertice];

                Busque(vertice);
            }
            if (Grafo.ObterTodasArestas().ToList().Any(aresta => aresta.Tipo == ClassificacaoAresta.ArestaDeRetorno))
                return true;

            return false;
        }

        public static void GerarTabelaBuscaEmProfundidade(this IGrafo grafo)
        {
            var vertices = grafo.ObterTodosVertices();

            if (vertices == null || vertices.Count == 0)
            {
                throw new InvalidOperationException("O grafo não possui vértices.");
            }

            var sb = new StringBuilder();
            sb.AppendLine("Resultados da Busca em Profundidade:");
            sb.AppendLine(new string('-', 60)); // Separador
            sb.AppendLine($"{"Vértice",-10} {"Descoberta",-15} {"Término",-15} {"Pai",-10}"); // Cabeçalho
            sb.AppendLine(new string('-', 60)); // Separador

            foreach (var vertice in vertices.OrderBy(v => v.Id))
            {
                sb.AppendLine($"{vertice.Id,-10} {vertice.ObterTempoDescoberta(),-15} {vertice.ObterTempoTermino(),-15} {(vertice.ObterPai()?.Id.ToString() ?? "-"),-10}");
            }

            Console.WriteLine(sb.ToString());
        }

        private static void Busque(Vertice vertice)
        {
            Tempo++;
            vertice.DefinirTempoDescoberta(Tempo);

            foreach (var aresta in Grafo?.ObterArestasAdjacentes(vertice.Id))
            {
                var vizinho = aresta.Destino;

                if (vizinho?.ObterTempoDescoberta() == 0)
                {
                    aresta.Tipo = ClassificacaoAresta.ArestaArvore;
                    vizinho.DefinirPai(vertice);
                    Busque(vizinho);
                }
                else if (EhDirecionado)
                {
                    //Se for direcionado vai por esse caminho
                    if (vizinho?.ObterTempoTermino() == 0)
                    {
                        aresta.Tipo = ClassificacaoAresta.ArestaDeRetorno;
                    }
                    else if (vizinho?.ObterTempoDescoberta() > vertice.ObterTempoDescoberta())
                    {
                        aresta.Tipo = ClassificacaoAresta.ArestaDeAvanco;
                    }
                    else
                    {
                        aresta.Tipo = ClassificacaoAresta.ArestaDeCruzamento;
                    }
                }
                else if (vizinho?.ObterTempoTermino() == 0 && vizinho.Id != vertice.ObterPai()?.Id)
                {
                    aresta.Tipo = ClassificacaoAresta.ArestaDeRetorno;
                }
            }

            Tempo++;
            vertice.DefinirTempoTermino(Tempo);
        }
    }
}
