using Grafos.Interfaces;
using Grafos.Models;

namespace Grafos.Classes.ListaAdjacencia
{
    public class GrafoListaAdjacencia : IGrafo
    {
        public List<Aresta> Arestas { get; set; }
        public List<Vertice> Vertices { get; set; }

        public GrafoListaAdjacencia()
        {

        }

        public GrafoListaAdjacencia(List<Vertice> vertices, List<Aresta> arestas)
        {
            Vertices = vertices;
            Arestas = arestas;
        }

        public IGrafo InicializarGrafo(List<Vertice> vertices, List<Aresta> arestas)
        {
            Vertices = vertices;
            Arestas = arestas;

            return this;
        }

        public Vertice ObterVertice(int id)
        {
            var vertice = Vertices.FirstOrDefault(v => v.Id == id);

            if (vertice == null)
                throw new ArgumentException($"Vértice com ID {id} não encontrado.");

            return vertice;
        }

        public Aresta ObterAresta(int idOrigem, int idDestino)
        {
            var aresta = Arestas.FirstOrDefault(a => a.Origem?.Id == idOrigem && a.Destino?.Id == idDestino);

            if (aresta == null)
                throw new ArgumentException($"Aresta ({idOrigem}, {idDestino}) não encontrada.");

            return aresta;
        }

        public List<Vertice> ObterTodosVertices()
        {
            return Vertices;
        }

        public List<Aresta> ObterTodasArestas()
        {
            return Arestas;
        }

        public List<Aresta> ObterAdjacenciasDaAresta(int idOrigem, int idDestino)
        {
            var aresta = ObterAresta(idOrigem, idDestino);
            var adjacencias = new List<Aresta>();

            foreach (var a in Arestas)
            {
                if (a.Destino?.Id == aresta.Destino?.Id)
                {
                    adjacencias.Add(a);
                }
            }

            return adjacencias;
        }

        public List<Vertice> ObterVizinhanca(int idVertice)
        {
            var vertice = ObterVertice(idVertice);
            var vizinhanca = new List<Vertice>
            {
                vertice
            };

            foreach (var aresta in Arestas)
            {
                if (aresta.Origem?.Id == vertice.Id)
                {
                    vizinhanca.Add(aresta.Destino);
                }
            }

            return vizinhanca;
        }

        public List<Aresta> ObterArestasIncidentes(int idVertice)
        {
            var vertice = ObterVertice(idVertice);
            var arestasIncidentes = new List<Aresta>();

            foreach (var aresta in Arestas)
            {
                if (aresta.Destino?.Id == vertice.Id)
                {
                    arestasIncidentes.Add(aresta);
                }
            }

            return arestasIncidentes;
        }

        public List<Aresta> ObterArestasAdjacentes(int idVertice)
        {
            var vertice = ObterVertice(idVertice);
            var arestasAdjacentes = new List<Aresta>();

            foreach (var aresta in Arestas)
            {
                if (aresta.Origem?.Id == vertice.Id)
                {
                    arestasAdjacentes.Add(aresta);
                }
            }

            return arestasAdjacentes;
        }

        public (int origem, int destino) ObterVerticesIncidentes(int idOrigem, int idDestino)
        {
            var aresta = ObterAresta(idOrigem, idDestino);

            return (aresta.Origem.Id, aresta.Destino.Id);
        }

        public int ObterGrauDoVertice(int idVertice)
        {
            var vertice = ObterVertice(idVertice);

            return ObterArestasAdjacentes(vertice.Id).Count;
        }

        public bool VerificarAdjacenciaEntreVertices(int idV1, int idV2)
        {
            var vertice1 = ObterVertice(idV1);
            var vertice2 = ObterVertice(idV2);

            return Arestas.Any(a => a.Origem?.Id == vertice1.Id && a.Destino?.Id == vertice2.Id);
        }

        public void SubstituirPesoAresta(int idOrigem, int idDestino, int novoPeso)
        {
            var aresta = ObterAresta(idOrigem, idDestino);
            aresta.Peso = novoPeso;
        }

        public void TrocarVertices(int idV1, int idV2)
        {
            //TODO: Implementar
            var vertice1 = ObterVertice(idV1);
            var vertice2 = ObterVertice(idV2);
        }

        public void ExibirRepresentacao()
        {
            throw new NotImplementedException();
        }
    }
}