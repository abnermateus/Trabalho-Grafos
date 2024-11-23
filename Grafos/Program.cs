namespace Grafos
{
    public class Program
    {
        public static void Main()
        {
            var grafo = LeitorDimac.DimacReader.LerArquivo("C:\\Users\\igorl\\OneDrive\\Documentos\\Projetos\\Trabalho_Grafos_3Semestre\\Grafos\\testeDimac.txt");

            grafo.Representacao();

        }
    }
}