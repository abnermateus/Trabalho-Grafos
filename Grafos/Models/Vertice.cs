namespace Grafos.Models
{
    public class Vertice
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Grau { get; private set; }
        public BuscaProfundidade? BuscaProfundidade { get; set; }
        public CaminhoMinimo? CaminhoMinimo { get; set; }
        public BuscaEmlargura? BuscaEmlargura { get; set; }

        public Vertice(string name = "")
        {
            Id = _id;
            Nome = name;
            Grau = 0;
            _id++;
        }

        public Vertice IncrementaGrau()
        {
            Grau++;
            return this;
        }

        public static void ResetarId()
        {
            _id = 1;
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

        #region Busca em Largura
        public void ResetBuscaEmLargura()
        {
            BuscaEmlargura = new BuscaEmlargura();
        }

        public Vertice? ObterPaiBuscaEmLargura()
        {
            return BuscaEmlargura.Pai;
        }

        public void DefinirPaiBuscaEmLargura(Vertice pai)
        {
            BuscaEmlargura.Pai = pai;
        }

        public int ObterIndiceBuscaEmLargura()
        {
            return BuscaEmlargura.Indice;
        }

        public void DefinirIndiceBuscaEmLargura(int indice)
        {
            BuscaEmlargura.Indice = indice;
        }

        public int ObterNivelBuscaEmLargura()
        {
            return BuscaEmlargura.Nivel;
        }

        public void DefinirNivelBuscaEmLargura(int nivel)
        {
            BuscaEmlargura.Nivel = nivel;
        }

        #endregion Busca em Largura
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

    public class BuscaEmlargura
    {
        public int Indice { get; set; }
        public int Nivel { get; set; }
        public Vertice? Pai { get; set; }

        public BuscaEmlargura()
        {
            Indice = 0;
            Nivel = 0;
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
