using Grafos.Classes.MatrizAdjacencia;
using Grafos.Interfaces;
using Grafos.Models;
using static Grafos.Utils.Utils;

namespace Grafos.LeitorDimac
{
    public class DesafioReader
    {
        private static int Nivel = 0;
        private static int Limite = 0;
        private const double FATOR_DENSIDADE = 0.5;


        public static (IGrafo, int) LerArquivo(string path)
        {
            var vertices = new List<Vertice>();
            var arestas = new List<Aresta>();
            var nomes = new HashSet<string>();

            Vertice.ResetarId();

            string[] linhas = File.ReadAllLines(path);

            DefinirLimiteNivel(linhas[0]);

            for (int i = 1; i < linhas.Length; i++)
                MarcarNomes(nomes, linhas[i]);

            foreach (var nome in nomes)
                vertices.Add(new Vertice(nome));

            for (int i = 1; i <= Limite; i++)
                PreencherArestas(vertices, arestas, linhas[i]);

            if (arestas.Count == 0)
                throw new InvalidOperationException("Não há arestas no grafo");

            if (arestas.Count < Limite)
                throw new InvalidOperationException("O grafo não possui arestas suficientes");

            if (arestas.Count > Limite)
                throw new InvalidOperationException("O grafo possui arestas demais");

            var densidade = CalcularDensidade(vertices.Count, arestas.Count);

            if (densidade < FATOR_DENSIDADE)
            {
                return (new GrafoMatrizAdjacencia().InicializarGrafo(vertices, arestas), Nivel); //Colocar a lista de adjacência aqui!!!
            }
            else
            {
                return (new GrafoMatrizAdjacencia().InicializarGrafo(vertices, arestas), Nivel);
            }
        }

        private static void MarcarNomes(HashSet<string> listaDeNomes, string linha)
        {
            var nomes = linha.Split(' ');

            Vertice.ResetarId();

            foreach (var nome in nomes)
            {
                listaDeNomes.Add(nome);
            }
        }

        private static void DefinirLimiteNivel(string linha)
        {
            var valores = linha.Split(' ');

            if (valores.Length != 2)
                throw new InvalidOperationException("Formato da linha está incorreto");

            Limite = int.Parse(valores[0]);
            Nivel = int.Parse(valores[1]);
        }

        private static void PreencherArestas(List<Vertice> vertices, List<Aresta> arestas, string linha)
        {
            var valores = linha.Split(' ');

            var verticeOrigem = vertices.Find(v => v.Nome == valores[0]);
            var verticeDestino = vertices.Find(v => v.Nome == valores[1]);
            var peso = 1;

            arestas.Add(new Aresta(verticeOrigem, verticeDestino, peso));
        }
    }
}