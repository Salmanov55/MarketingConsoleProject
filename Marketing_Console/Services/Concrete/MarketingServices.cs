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
        public void AddProduct(string productName, decimal price, string category)
        {
            throw new NotImplementedException();
        }

        public int AddSale(int saleId, List<SalesItem> salesItems)
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


        public List<Product> FindProductsByName(int productId, string productName)
        {
            if (string.IsNullOrWhiteSpace(productName)) throw new Exception("Name can't be empty!");

            var foundStudents = products.Where(x => x.ProductnName.ToLower().Trim() == productName.ToLower().Trim()).ToList();

            return foundStudents;
        }

        public void ReturnProduct(int saleId, int productId, int count)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowAllProducts(int productId, string productName, string category, int count, decimal price)
        {
            return products;
        }

        public void ShowingSalesByAmountRange(int saleId, decimal price, int productCount, DateTime dateTime, decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public void ShowingSalesByDateRange(int saleId, decimal price, int productCount, DateTime startDate, DateTime endData)
        {
            throw new NotImplementedException();
        }

        public void ShowingSalesOnGivenDate(int saleId, decimal price, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Product> ShowProductsByCategory(int productId, string productName, string category, int count, decimal price)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int productId, string productName, decimal price, string category)
        {
            throw new NotImplementedException();
        }

        public List<Product> ViewProductsByPrice(decimal minPrice, decimal maxPrice)
        {
            throw new NotImplementedException();
        }
    }
}
