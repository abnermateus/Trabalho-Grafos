using System;
using Grafos.Classes.MatrizAdjacencia;
using Grafos.Classes.ListaAdjacencia;
using Grafos.Interfaces;
using Grafos.Models;
using static Grafos.Utils.Utils;
using Grafos.LeitorDimac;

namespace Grafos.Menus
{
    public class MenuPrincipal
    {
        private IGrafo? grafo;

        public void ExecutarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Principal ===");
                Console.WriteLine("1 - Criar novo grafo");
                Console.WriteLine("2 - Obter grafo Dimac");
                Console.WriteLine("0 - Sair");
                Console.Write("\nEscolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Menu1 menu1 = new Menu1();
                            menu1.ExecutarMenu();
                            break;
                        case 2:
                            Menu2 menu2 = new Menu2();
                            menu2.ExecutarMenu();
                            break;
                        case 0:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }
    }
}
