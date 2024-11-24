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

        public Vertice IncrementaGrau()
        {
            Grau++;
            return this;
        }

        #region Busca em Profundidade

        public void ResetBuscaEmProfundidade()
        {
            BuscaProfundidade = new BuscaProfundidade();
        }

        public int ObterTempoDescoberta()
        {
            return BuscaProfundidade.TempoDescoberta;
        }

        public void DefinirTempoDescoberta(int tempo)
        {
            BuscaProfundidade.TempoDescoberta = tempo;
        }

        public int ObterTempoTermino()
        {
            return BuscaProfundidade.TempoTermino;
        }

        public void DefinirTempoTermino(int tempo)
        {
            BuscaProfundidade.TempoTermino = tempo;
        }

        public Vertice? ObterPai()
        {
            return BuscaProfundidade.Pai;
        }

        public void DefinirPai(Vertice pai)
        {
            BuscaProfundidade.Pai = pai;
        }

        #endregion Busca em Profundidade

        #region Caminho Mínimo

        public void ResetCaminhoMinimo()
        {
            CaminhoMinimo = new CaminhoMinimo();
        }

        public decimal ObterDistanciaCM()
        {
            return CaminhoMinimo.Distancia;
        }

        public void DefinirDistanciaCM(decimal distancia)
        {
            CaminhoMinimo.Distancia = distancia;
        }

        public Vertice? ObterPaiCM()
        {
            return CaminhoMinimo.Pai;
        }

        public Vertice DefinirPaiCM(Vertice pai)
        {
            CaminhoMinimo.Pai = pai;
            return this;
        }
        #endregion Caminho Mínimo
    }

    public class BuscaProfundidade
    {
        public int TempoDescoberta { get; set; }
        public int TempoTermino { get; set; }
        public Vertice? Pai { get; set; }

        public BuscaProfundidade()
        {
            TempoDescoberta = 0;
            TempoTermino = 0;
            Pai = null;
        }
    }

    public class CaminhoMinimo
    {
        public decimal Distancia { get; set; }
        public Vertice? Pai { get; set; }

        public CaminhoMinimo()
        {
            Distancia = int.MaxValue;
            Pai = null;
        }
    }
}
