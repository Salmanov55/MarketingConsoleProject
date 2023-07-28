using Marketing_Console.Data.Enums;
using Marketing_Console.Data.Models;
using Marketing_Console.Helpers;
using Marketing_Console.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Marketing_Console.Services.Concrete
{
    public class MarketingServices : IMarketable
    {
        private List<Product> products;
        private List<Sale> sales;
        private List<SalesItem> salesItems;

        public MarketingServices() 
        {
            products = new();
            sales = new();
            salesItems = new();
        }
        public void AddProduct(string productName, double price, Category category, int count)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Name can not be null!");
            if (price <= 0) throw new Exception("Price ca not be equals to 0 and less than 0");
            if (count <= 0) throw new Exception("Count can not be equals to 0 and less than 0");
            if (category == null) throw new Exception("Category can not be null");
            while (products.Any(p => p.ProductName.ToLower().Trim() == productName.ToLower().Trim() && p.Category == category))
            {
                Console.WriteLine("Same name of product alredy have! Please enter another name!");
                productName = Console.ReadLine();

            }
            var product = new Product(productName.Trim(), price, category, count);
            products.Add(product);
        }

        public void AddSale(List<ProductDto> productsDto)
        {
            List<SalesItem> salesItems = new();
            foreach (var productDto in productsDto)
            {
                Product product = products.FirstOrDefault(p => p.Id == productDto.Id);
                while (product.ProductCount < productDto.Count)
                {
                    Console.WriteLine($"The number of {product.ProductName} sent is more than the actual number");
                    Console.WriteLine("Enter the number again!");
                    productDto.Count = Convert.ToInt32(Console.ReadLine());
                }

                product.ProductCount = product.ProductCount - productDto.Count;


                SalesItem salesItem = new(product, productDto.Count);
                salesItems.Add(salesItem);

            }

            Sale sale = new(salesItems.Sum(s => s.TotalPrice()), salesItems, DateTime.Now);
            sales.Add(sale);
            Console.WriteLine("The sale was successful");
        }
        public void DeleteProduct(int productId)
        {
            if (productId < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");
            var existingStudent = products.FirstOrDefault(x => x.Id == productId);
            if (existingStudent == null) throw new Exception("Not found!");
            if (salesItems.Any(s => s.Product.Id == productId))
            {
                Console.WriteLine("It is not possible to delete, there is a product with this ID in the sale!");
                Submenu.ProductSubMenu();
                return;
            }
            else
            {
                products = products.Where(x => x.Id != productId).ToList();
            }
        }

        public void DeleteSale(int saleId)
        {
            if (sales.FirstOrDefault(s => s.Id == saleId) == null)
            {
                Console.WriteLine("You have entered the wrong ID!");
                Submenu.SaleSubMenu();
            }

            Sale sale = sales.FirstOrDefault(x => x.Id == saleId);
            foreach (SalesItem item in sale.SalesItems)
            {
                item.Product.ProductCount = item.Product.ProductCount + item.Count;
            }
            sales.Remove(sale);
        }

        public void DisplayingTheInformationGivenIdSale(int saleId, double price, int productCount, DateTime Date, List<SalesItem> salesItems)
        {
            throw new NotImplementedException();
        }

        public List<Sale> DisplayOfAllSales()
        {
            return sales;
        }


        public List<Product> FindProductsByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Name can't be empty!");

            var foundStudents = products.Where(x => x.ProductName.ToLower().Trim() == productName.ToLower().Trim()).ToList();

            return foundStudents;
        }

        public void ReturnSale(int productId)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAllProducts()
        {
            return products;
        }

        public List<SalesItem> ShowingSalesByAmountRange(int saleId, double price, int productCount, DateTime dateTime, double minPrice, double maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Sale> ShowingSalesByDateRange(int saleId, double price, int productCount, DateTime startDate, DateTime endData)
        {
            throw new NotImplementedException();
        }

        public void ShowingSalesOnGivenDate(int saleId, double price, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowProductsByCategory(Category category)
        {
            if (category == null) throw new Exception("Category name can not be null");
            var foundProducts = products.Where(x => x.Category == category ).ToList();
            return foundProducts;
        }

        public void UpdateProduct(int Id, string productName, int count, double price, Category category)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Name can not be null!");
            if (Id < 0) throw new Exception("ID can not be less than 0");
            if (count <= 0) throw new Exception("Count can not be equals to 0 and less than 0");
            if (price <= 0) throw new Exception("Proce can not be equals to 0 and less than 0");
            if (category == null) throw new Exception("Category can not be null!");
            var existingproduct = products.FirstOrDefault(x => x.Id == Id);
            if (existingproduct == null) throw new Exception("Product not found!");
            existingproduct.Price = price;
            existingproduct.Category = category;
            existingproduct.ProductName = productName;
        }

        public List<Product> ViewProductsByPrice(double minPrice, double maxPrice)
        {
            if (minPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (maxPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (minPrice > maxPrice) throw new ArgumentOutOfRangeException("Mininmum price can not be more than maximum price");
            return products.Where(x=> x.Price >= minPrice && x.Price <= maxPrice).ToList();
        }
    }
}
