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
        //SubMenu services
        public static void AddNewProduct()
        {
            try
            {
                bool choose = true;

                while (choose)
                {
                    Console.WriteLine("Please enter name of product:");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please enter price of product: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter count of product:");
                    int count = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please choose and enter one category in list:");
                    foreach (var item in Enum.GetNames(typeof(Category)))
                    {
                        Console.WriteLine($"{item}");
                    }
                    Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(), true);

                    Console.WriteLine("Will there be more fruit? Enter Y or N");
                    string answer = Console.ReadLine();
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            choose = true;
                            break;
                        case "N":
                            choose = false;
                            break;
                        default:
                            Console.WriteLine("Enter correctly!");
                            Console.WriteLine("Will there be a harvest? Y or N");
                            answer = Console.ReadLine();
                            break;
                    }
                    marketingServices.AddProduct(productName, price, category, count);
                    Console.WriteLine("Added new product succesfuly:)");
                }
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
                if (marketingServices.ShowAllProducts().Count == 0)
                {
                    Console.WriteLine("Product is not available in the database!");
                    return;
                }
                int productId;
                int prodCount;
                bool choose = true;
                List<ProductDto> products = new List<ProductDto>();
                while (choose)
                {
                    Console.WriteLine("Enter the Id of the product for sale");
                    foreach (Product item in marketingServices.ShowAllProducts())
                    {
                        if (products != null && products.FirstOrDefault(p => p.Id == item.Id) != null)
                        {
                            Console.WriteLine($"{item.Id} - {item.ProductName} : count {item.ProductCount - products.FirstOrDefault(p => p.Id == item.Id).Count}");
                        }
                        else
                        {
                            Console.WriteLine($"{item.Id} - {item.ProductName} : count {item.ProductCount}");
                        }
                    }
                    productId = Convert.ToInt32(Console.ReadLine());
                    while (marketingServices.ShowAllProducts().FirstOrDefault(p => p.Id == productId) == null)
                    {
                        Console.WriteLine("The Id you entered was wrong!");
                        productId = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Enter the number of the product");
                    prodCount = Convert.ToInt32(Console.ReadLine());

                    while (prodCount > marketingServices.ShowAllProducts().FirstOrDefault(p => p.Id == productId).ProductCount)
                    {
                        Console.WriteLine($"The number of {marketingServices.ShowAllProducts().FirstOrDefault(p => p.Id == productId).ProductName} sent is more than the actual number");
                        Console.WriteLine("Enter the number again!");
                        prodCount = Convert.ToInt32(Console.ReadLine());
                    }

                    if (products.FirstOrDefault(p => p.Id == productId) != null)
                    {
                        products.FirstOrDefault(p => p.Id == productId).Count = products.FirstOrDefault(p => p.Id == productId).Count + prodCount;
                    }
                    else
                    {
                        ProductDto productDto = new()
                        {
                            Id = productId,
                            Count = prodCount,
                        };
                        products.Add(productDto);
                    }
                    Console.WriteLine("Will there be more fruit? Enter Y or N");
                    string answer = Console.ReadLine();
                    while (answer.ToUpper() != "Y" && answer.ToUpper() != "N")
                    {
                        Console.WriteLine("Enter correctly!");
                        answer = Console.ReadLine();
                    }
                    switch (answer.ToUpper())
                    {
                        case "Y":
                            choose = true;
                            break;
                        case "N":
                            choose = false;
                            break;
                        default:
                            break;
                    }
                }
                marketingServices.AddSale(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ooops,eror. {ex.Message}");
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
                if (marketingServices.DisplayOfAllSales().Count > 0)
                {
                    Console.WriteLine("Please enter Sale ID:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    marketingServices.DeleteSale(id);
                }
                else
                {
                    Console.WriteLine("The sales list is empty!");
                }
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
                if (marketingServices.DisplayOfAllSales().Count > 0)
                {
                    foreach (Sale item in marketingServices.DisplayOfAllSales())
                    {
                        Console.WriteLine($"ID - {item.Id} , Date : {item.Date} , Sales Amount : {item.SalesAmount}");
                        foreach (SalesItem salesItem in item.SalesItems)
                        {
                            Console.WriteLine($"Product : {salesItem.Product.ProductName}, Product Count : {salesItem.Count} , Product Price : {salesItem.Product.Price}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The sales list is empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void DisplayOfSalesAccordingGivenAmountRange()
        {
            try
            {
                if (marketingServices.DisplayOfAllSales().Count > 0)
                {
                    Console.WriteLine("Enter the minimum price in which range you want to see the sales");
                    double minPrice = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the maximum amount");
                    double maxPrice = Convert.ToDouble(Console.ReadLine());
                    foreach (Sale item in marketingServices.ShowingSalesByAmountRange(minPrice, maxPrice))
                    {
                        Console.WriteLine($"Id:{item.Id}, Amount : {item.SalesAmount} , Date : {item.Date} , Product-Count : {item.SalesItems.Sum(s => s.Count)}");
                    }
                }
                else
                {
                    Console.WriteLine("The sales list is empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops,error. {ex.Message}");
            }
        }
        public static void DisplayOfSalesAccordingGivenDateRange()
        {
            try
            {
                if (marketingServices.DisplayOfAllSales().Count > 0)
                {
                    Console.WriteLine("Enter the start date");
                    DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter the end date");
                    DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                    foreach (Sale item in marketingServices.ShowingSalesByDateRange(startDate, endDate))
                    {
                        Console.WriteLine($"Id:{item.Id}, Amount : {item.SalesAmount} , Date : {item.Date} , Product-Count : {item.SalesItems.Sum(s => s.Count)}");
                    }
                }
                else
                {
                    Console.WriteLine("The sales list is empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops,error. {ex.Message}");
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
                double price = Convert.ToDouble(Console.ReadLine());
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
                if (marketingServices.DisplayOfAllSales().Count > 0)
                {
                    Console.WriteLine("Enter the Id of the required sale!");
                    foreach (Sale item in marketingServices.DisplayOfAllSales())
                    {
                        Console.WriteLine($"Id:{item.Id} ,Date of Sale: {item.Date}, Amount: {item.SalesAmount}");
                    }
                    int saleId = Convert.ToInt32(Console.ReadLine());
                    while (marketingServices.DisplayOfAllSales().FirstOrDefault(s => s.Id == saleId) == null)
                    {
                        Console.WriteLine("Wrong Id entered! Try again!");
                        saleId = Convert.ToInt32(Console.ReadLine());
                    }
                    marketingServices.ReturnSale(saleId);
                }
                else
                {
                    Console.WriteLine("The sales list is empty!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops,error. {ex.Message}");
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
                //Console.WriteLine("Please enter Id of sale for search:");
                //int Id = Convert.ToInt32(Console.ReadLine());
                //var foundsale = marketingServices.DisplayingTheInformationGivenIdSale(Id);

                //foreach (var sales in foundsale)
                //{
                //    Console.WriteLine($"Name:{sales.Id}, Price:{sales.salesAmount}, Count:{sales.saleCount}");
                //}
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
            //    if (marketingServices.DisplayOfAllSales().Count > 0)
            //    {
            //        Console.WriteLine("Enter the date");
            //        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
            //        foreach (Sale item in marketingServices.ShowingSalesOnGivenDate(dateTime))
            //        {
            //            Console.WriteLine($"Id:{item.Id}, Amount : {item.SalesAmount} , Date : {item.Date} , Product-Count : {item.SalesItems.Sum(s => s.Count)}");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("The sales list is empty!");
            //    }
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
                Category category7 = Category.Fruits;
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
                double minPrice = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Please enter maxamount:");
                double maxPrice = Convert.ToDouble(Console.ReadLine());
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
