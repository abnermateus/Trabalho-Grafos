namespace Grafos.Utils
{
    public class Utls
    {
        public static double CalcularDensidade(int numVertices, int numArestas)
        {
            return numVertices <= 1 ? 0 : (double)numArestas / (numVertices * (numVertices - 1));
        }
    }
}
