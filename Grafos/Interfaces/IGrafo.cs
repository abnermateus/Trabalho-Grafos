using Grafos.Classes.MatrizAdjacencia;
using Grafos.Models;

namespace Grafos.Interfaces
{
    public interface IGrafo
    {
        GrafoMatrizAdjacencia InicializaGrafo(List<Vertice> vertices, List<Aresta> arestas);
        void Representacao();

        Vertice ObterVertice(int id);

        Aresta ObterAresta(int idOrigem, int idDestino);

        List<Vertice> ObterTodosVertices();

        List<Aresta> ObterTodasArestas();

        List<Aresta> ArestasAdjacentesDaAresta(int idOrigem, int idDestino);

        List<Vertice> VerticesAdjacentes(int idVertice);

        List<Aresta> ArestasIncidentes(int idVertice);

        List<Aresta> ArestasAdjacentes(int idVertice);

        (int origem, int destino) VerticesIncidentes(int idOrigem, int idDestino);

        int GrauDoVertice(int idVertice);

        bool SaoAdjacentes(int idV1, int idV2);

        void SubstituirPesoAresta(int idOrigem, int idDestino, int novoPeso);

        void TrocarVertices(int idV1, int idV2);
    }
}
