using Marketing_Console.Data.Enums;
using Marketing_Console.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Services.Concrete
{
    public class SubMenuServices
    {
        private static MarketingServices marketingServices = new MarketingServices();

        public static void AddNewProduct()
        {
            try
            {
                Console.WriteLine("Please enter name of product:");
                string productName = Console.ReadLine();
                Console.WriteLine("Please enter price of product: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter count of product:");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);


                marketingServices.AddProduct(productName, price, category, count);
                Console.WriteLine("Added new product succesfuly:)");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ooops,eror. {ex.Message}");
            }
        }

        public static void AddNewSales()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteProduct()
        {
            try
            {
                Console.WriteLine("Please enter Product ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                marketingServices.DeleteProduct(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }

        public static void DeleteSales()
        {
            try
            {
                Console.WriteLine("Please enter Sale ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                marketingServices.DeleteProduct(id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }

        public static void DisplayOfAllSales()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DisplayOfSalesAccordingGivenAmountRange()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DisplayOfSalesAccordingGivenDateRange()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Please enter name of product");
                string productName = Console.ReadLine();
                Console.WriteLine("Please enter ID:");
                int productId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter count:");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);
                marketingServices.UpdateProduct(productId, productName, count, price, category);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }

        public static void ReturnSale()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void SearchProductsByName()
        {
            try
            {
                Console.WriteLine("Please enter name of product for search:");
                string name = Console.ReadLine();
                var foundproducts = marketingServices.FindProductsByName(name);

                if (foundproducts.Count == 0)
                {
                    Console.WriteLine("No products found");
                }
                foreach (var product in foundproducts)
                {
                    Console.WriteLine($"Name:{product.ProductName}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error.{ex.Message}");
            }
        }

        public static void ShowAllProducts()
        {
            var products = marketingServices.ShowAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products yet!");
                return;
            }
            foreach (var product in products)
            {
                Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
            }
        }

        public static void ShowingInformationGivenIDMainlySalesWithThatID()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ShowingSalesOnGivenDate()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ShowProductsByCategory()
        {
            try
            {
                List<Category> categories = new List<Category>();
                Category category = Category.Food;
                Console.WriteLine(category);
                Category category1 = Category.Electronics;
                Console.WriteLine(category1);
                Category category2 = Category.Clothing;
                Console.WriteLine(category2);
                Category category3 = Category.Drink;
                Console.WriteLine(category3);
                Category category4 = Category.Kitchen;
                Console.WriteLine(category4);
                Category category5 = Category.Oil;
                Console.WriteLine(category5);
                Category category6 = Category.Seafood;
                Console.WriteLine(category6);
                Category category9 = Category.Fruits;
                Console.WriteLine("Please enter category name:");
                Category cateName = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                var foundproducts = marketingServices.ShowProductsByCategory(cateName);
                if (foundproducts.Count ==0)
                {
                    Console.WriteLine("Not product found");
                    return;
                }
                foreach (var product in foundproducts)
                {
                    Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }

        public static void ShowProductsByPriceRange()
        {
            try
            {
                Console.WriteLine("Please enter minamount:");
                decimal minPrice = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Please enter maxamount:");
                decimal maxPrice = Convert.ToDecimal(Console.ReadLine());
                var foundproduct = marketingServices.ViewProductsByPrice(minPrice, maxPrice);
                if (foundproduct.Count == 0)
                {
                    Console.WriteLine("No products found!");
                }
                foreach (var product in foundproduct)
                {
                    Console.WriteLine($"ID:{product.Id},Name:{product.ProductName}, Count:{product.ProductCount}, Price:{product.Price}, Category:{product.Category}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ooops,error.{ex.Message}");
            }
        }
    }
}
