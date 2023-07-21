using Marketing_Console;
using Marketing_Console.Helpers;

namespace Marketing_Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("1. To operate on products");
                Console.WriteLine("2. Conduct surgery on sales");
                Console.WriteLine("0. Sign out");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        Submenu.ProductSubMenu();
                        break;
                    case 2:
                        Submenu.SaleSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option!=0);
        }
    }
}