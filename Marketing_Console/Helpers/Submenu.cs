using Marketing_Console.Data.Models;
using Marketing_Console.Services.Concrete;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Helpers
{
    public class Submenu
    {
        public static void ProductSubMenu()
        {
            int option;

            do
            {
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Make corrections on the product");
                Console.WriteLine("3. Delete product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show products by category");
                Console.WriteLine("6. Show products by price range");
                Console.WriteLine("7. Search products by name");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        ProductService.MenuAddNewProduct();
                        break;
                    case 2:
                        ProductService.MenuMakeCorrectionsOnTheProduct();
                        break;
                    case 3:
                        ProductService.MenuDeleteProduct();
                        break;
                    case 4:
                        ProductService.MenuShowAllProducts();
                        break;
                    case 5:
                        ProductService.MenuShowProductsByCategory();
                        break;
                    case 6:
                        ProductService.MenuShowProductsByPriceRange();
                        break;
                    case 7:
                        ProductService.MenuSearchProductsByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
        public static void SaleSubMenu()
        {
            int option;

            do
            {
                Console.WriteLine("1. Add new sales");
                Console.WriteLine("2. Returning any product on sale");
                Console.WriteLine("3. Delete sales");
                Console.WriteLine("4. Display of all sales");
                Console.WriteLine("5. Display of sales according to the given date range");
                Console.WriteLine("6. Display of sales according to the given amount range");
                Console.WriteLine("7. Showing sales on a given date");
                Console.WriteLine("8. Showing the information of the given ID, mainly the sales with that ID");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        SaleService.MenuAddNewSales();
                        break;
                    case 2:
                        SaleService.MenuReturningAnyProductOnSale();
                        break;
                    case 3:
                        SaleService.MenuDeleteSales();
                        break;
                    case 4:
                        SaleService.MenuDisplayOfAllSales();
                        break;
                    case 5:
                        SaleService.MenuDisplayOfSalesAccordingGivenDateRange();
                        break;
                    case 6:
                        SaleService.MenuDisplayOfSalesAccordingGivenAmountRange();
                        break;
                    case 7:
                        SaleService.MenuShowingSalesOnGivenDate();
                        break;
                    case 8:
                        SaleService.MenuShowingInformationGivenIDMainlySalesWithThatID();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}
