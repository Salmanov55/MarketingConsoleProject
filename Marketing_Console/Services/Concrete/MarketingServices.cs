using Marketing_Console.Data.Enums;
using Marketing_Console.Data.Models;
using Marketing_Console.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public void AddProduct(string productName, decimal price, Category category, int count)
        {
            if (productName == null) throw new Exception("Name can not be null!");
            if (price <= 0) throw new Exception("Price ca not be equals to 0 and less than 0");
            if (count <= 0) throw new Exception("Count can not be equals to 0 and less than 0");
            if (category == null) throw new Exception("Category can not be null");
            var product = new Product(productName, price, category, count);
            products.Add(product);
        }

        public int AddSale(List<SalesItem> salesItems, double salesAmount)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            if (productId < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            var existingStudent = products.FirstOrDefault(x => x.Id == productId);

            if (existingStudent == null) throw new Exception("Not found!");

            products = products.Where(x => x.Id != productId).ToList();
        }

        public void DeleteSale(int productId)
        {
            throw new NotImplementedException();
        }

        public void DisplayingTheInformationGivenIdSale(int saleId, decimal price, int productCount, DateTime Date, List<SalesItem> salesItems)
        {
            throw new NotImplementedException();
        }

        public void DisplayOfAllSales(int saleId, decimal price, int productcount, DateTime date)
        {
            throw new NotImplementedException();
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

        public List<SalesItem> ShowingSalesByAmountRange(int saleId, decimal price, int productCount, DateTime dateTime, decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Sale> ShowingSalesByDateRange(int saleId, decimal price, int productCount, DateTime startDate, DateTime endData)
        {
            throw new NotImplementedException();
        }

        public void ShowingSalesOnGivenDate(int saleId, decimal price, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowProductsByCategory(Category category)
        {
            if (category == null) throw new Exception("Category name can not be null");
            var foundProducts = products.Where(x => x.Category == category ).ToList();
            return foundProducts;
        }

        public void UpdateProduct(int Id, string productName, int count, decimal price, Category category)
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

        public List<Product> ViewProductsByPrice(decimal minPrice, decimal maxPrice)
        {
            if (minPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (maxPrice <= 0) throw new ArgumentOutOfRangeException("Price can not be equals to 0 and less than 0");
            if (minPrice > maxPrice) throw new ArgumentOutOfRangeException("Mininmum price can not be more than maximum price");
            return products.Where(x=> x.Price >= minPrice && x.Price <= maxPrice).ToList();
        }
    }
}
