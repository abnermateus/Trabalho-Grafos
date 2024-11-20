namespace Grafos.Models
{
    public class Vertice
    {
        private static int _id = 1;
        public int Id { get; set; }

        public int Grau { get; private set; }

        public BuscaProfundidade? BuscaProfundidade { get; set; }

        public CaminhoMinimo? CaminhoMinimo { get; set; }

        public Vertice()
        {
            Id = _id;
            Grau = 0;
            _id++;
        }

        public void IncrementaGrau()
        {
            Grau++;
        }

        public void ResetBuscaEmProfundidade()
        {
            BuscaProfundidade = new BuscaProfundidade();
        }

        public void ResetCaminhoMinimo()
        {
            CaminhoMinimo = new CaminhoMinimo();
        }
    }


    public class BuscaProfundidade
    {
        public int DiscoveryTime { get; set; }
        public int FinishTime { get; set; }
        public Vertice? Father { get; set; }

        public BuscaProfundidade()
        {
            DiscoveryTime = 0;
            FinishTime = 0;
            Father = null;
        }
    }

    public class CaminhoMinimo
    {
        public decimal Distance { get; set; }
        public Vertice? Father { get; set; }

        public CaminhoMinimo()
        {
            Distance = int.MaxValue;
            Father = null;
        }
    }
}
