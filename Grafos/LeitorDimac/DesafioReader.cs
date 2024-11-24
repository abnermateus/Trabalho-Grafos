using Grafos.Classes.MatrizAdjacencia;
using Grafos.Interfaces;
using Grafos.Models;
using static Grafos.Utils.Utls;

namespace Grafos.LeitorDimac
{
    public class DesafioReader
    {
        private static int Nivel = 0;

        private static int Limite = 0;
        public static (IGrafo, int) LerArquivo(string path)
        {
            var vertices = new List<Vertice>();
            var arestas = new List<Aresta>();
            var nomes = new HashSet<string>();

            Vertice.ResetarId();

            string[] linhas = File.ReadAllLines(path);

            DefinirLimiteNivel(linhas[0]);

            //Pegar cada nomes
            for (int i = 1; i < linhas.Length; i++)
                MarcarNomes(nomes, linhas[i]);

            //Preencher os vértices
            foreach (var nome in nomes)
                vertices.Add(new Vertice(nome));

            //Preencher as arestas
            for (int i = 1; i <= Limite; i++)
                PreencherArestas(vertices, arestas, linhas[i]);

            #region Verificações

            if (arestas.Count == 0)
                throw new Exception("Não há arestas no grafo");

            if (arestas.Count < Limite)
                throw new Exception("O grafo não possui arestas suficientes");

            if (arestas.Count > Limite)
                throw new Exception("O grafo possui arestas demais");

            #endregion

            var densidade = CalcularDensidade(vertices.Count, arestas.Count);

            if (densidade < 0.5)
            {
                return (new GrafoMatrizAdjacencia().InicializaGrafo(vertices, arestas), Nivel); //Colocar a lista de adjacência aqui!!!
            }
            else
            {
                return (new GrafoMatrizAdjacencia().InicializaGrafo(vertices, arestas), Nivel);
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
                throw new Exception("Tem coisa errada aê");
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