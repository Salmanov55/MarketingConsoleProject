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
            if (price <= 0) throw new Exception("Price can not be equals to 0 and less than 0");
            if (count <= 0) throw new Exception("Count can not be equals to 0 and less than 0");
            if (category == null) throw new Exception("Category can not be null");
            while (products.Any(p => p.ProductName.ToLower().Trim() == productName.ToLower().Trim() && p.Category == category))
            {
                Console.WriteLine("Same name of product alredy have! Please enter another name!");
                productName = Console.ReadLine();

            }
            var product = new Product(productName.Trim(), price, category, count);
            products.Add(product);
        } //Product addition service
        public void AddSale(List<ProductDto> productsDto)
        {
            List<SalesItem> salesItems = new();
            foreach (var productDto in productsDto)
            {
                Product product = products.FirstOrDefault(p => p.Id == productDto.Id);
                product.ProductCount = product.ProductCount - productDto.Count;


                SalesItem salesItem = new(product, productDto.Count);
                salesItems.Add(salesItem);

            }

            Sale sale = new(salesItems.Sum(s => s.TotalPrice()), salesItems, DateTime.Now);
            sales.Add(sale);
            Console.WriteLine("The sale was successful");
            Console.WriteLine("\n");
        } //Sales addition service
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
        } //Product deletion service
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
        } //Product deletion service
        public List<Sale> DisplayingTheInformationGivenIdSale(int saleId)
        {
            if (saleId < 0)
            {
                Console.WriteLine("ID can't be less than 0!");
                return new List<Sale>();
            }

            var salesList = sales.Where(sale => sale.Id == saleId).ToList();

            if (salesList.Count == 0)
            {
                Console.WriteLine($"No sale found with the given ID: {saleId}");
            }

            return salesList;
        } //The given Id mainly shows the amount of the sale, the number of products, and the date
        public List<Sale> DisplayOfAllSales()
        {
            return sales;
        } //All sales display service
        public List<Product> FindProductsByName(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Name can't be empty!");

            var foundProduct = products.Where(x => x.ProductName.ToLower().Trim() == productName.ToLower().Trim()).ToList();

            return foundProduct;
        } //Search service by production name
        public void ReturnSale(int saleId)
        {
            int incorrectChoose = 0;
            Sale sale = sales.FirstOrDefault(s => s.Id == saleId);
            foreach (SalesItem item in sale.SalesItems)
            {
                Console.WriteLine($"Id:{item.Product.Id} , Prodcutin Name : {item.Product.ProductName} , Sale Count: {item.Count}");
            }
            Console.WriteLine("Enter the Id of which Product you want to return!");
            int productId = Convert.ToInt32(Console.ReadLine());
            while (sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId) == null)
            {
                incorrectChoose++;
                if (incorrectChoose > 3)
                {
                    Console.WriteLine("Error record limit exceeded!");
                    Submenu.SaleSubMenu();
                    return;
                }
                Console.WriteLine("Id entered incorrectly! Make the right choice!");
                productId = Convert.ToInt32(Console.ReadLine());
            }
            incorrectChoose = 0;
            Console.WriteLine("Enter the Product Name to be returned:");
            int productCountToReturn = Convert.ToInt32(Console.ReadLine());
            while (sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId).Count < productCountToReturn)
            {
                incorrectChoose++;
                if (incorrectChoose > 3)
                {
                    Console.WriteLine("Error record limit exceeded!");
                    Submenu.SaleSubMenu();
                    return;
                }
                Console.WriteLine("Enter correctly!");
                productCountToReturn = Convert.ToInt32(Console.ReadLine());
            }
            sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId).Count -= productCountToReturn;
            Product product = sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId).Product;
            product.ProductCount += productCountToReturn;
            sale.SalesAmount -= (product.Price * productCountToReturn);
            if (sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId).Count == 0 && sale.SalesItems.Count < 2)
            {
                sales.Remove(sale);
                Console.WriteLine("Sale deleted!");
                Submenu.SaleSubMenu();
                return;
            }
            if (sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId).Count == 0)
            {
                sale.SalesItems.Remove(sale.SalesItems.FirstOrDefault(s => s.Product.Id == productId));
                Console.WriteLine("The products were returned!");
                Submenu.SaleSubMenu();
                return;
            }
            else
            {
                Console.WriteLine("The products were returned!");
                Submenu.SaleSubMenu();
                return;
            }
        } //Search service by production name
        public List<Product> ShowAllProducts()
        {
            return products;
        } //All products display service
        public List<Sale> ShowingSalesByAmountRange(double minPrice, double maxPrice)
        {
            if (minPrice > maxPrice)
            {
                return sales.Where(s => s.SalesAmount <= minPrice && s.SalesAmount >= maxPrice).ToList();
            }
            else
            {
                return sales.Where(s => s.SalesAmount >= minPrice && s.SalesAmount <= maxPrice).ToList();
            }
        } //Service to Display Sales by Amount Range
        public List<Sale> ShowingSalesByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) throw new Exception("Min date cannot be greater than the Max date.");

            return sales.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();
        } //Service to Display Sales by Date Range
        public List<Sale> ShowingSalesOnGivenDate(DateTime dateTime)
        {
            var salesOnDate = sales.Where(sale => sale.Date.Date == dateTime.Date).ToList();
            return salesOnDate;
        } //Sales display service for a given date
        public List<Product> ShowProductsByCategory(Category category)
        {
            if (category == null) throw new Exception("Category name can not be null");
            var foundProducts = products.Where(x => x.Category == category ).ToList();
            return foundProducts;
        } //Product display service by category
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
        } //Product update service
        public List<Product> ViewProductsByPrice(double minPrice, double maxPrice)
        {
            if (minPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (maxPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (minPrice > maxPrice) throw new ArgumentOutOfRangeException("Mininmum price can not be more than maximum price");
            return products.Where(x=> x.Price >= minPrice && x.Price <= maxPrice).ToList();
        } //Product display service by price range
    }
}
