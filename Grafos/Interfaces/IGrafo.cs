using Grafos.Classes.MatrizAdjacencia;
using Grafos.Models;

namespace Grafos.Interfaces
{
    public interface IGrafo
    {
        GrafoMA InicializaGrafo(List<Vertice> vertices, List<Aresta> arestas);
        void Representacao();
    }
}
