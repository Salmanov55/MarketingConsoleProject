using Marketing_Console.Data.Enums;
using Marketing_Console.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Services.Abstract
{
    public interface IMarketable
    {
        public void AddProduct(string productName, decimal price, string category);
        public void UpdateProduct(int productId, string productName, decimal price, string category);
        public void DeleteProduct(int productId);
        public List<Product> ShowAllProducts(int productId, string productName, string category, int count, decimal price);
        public List<Product> ShowProductsByCategory(int productId, string productName, string category, int count, decimal price);
        public List<Product> ViewProductsByPrice(decimal minPrice, decimal maxPrice);
        public List<Product> FindProductsByName(int productId, string productName);


        public int AddSale(int saleId, List<SalesItem> salesItems);
        public void ReturnProduct(int saleId, int productId, int count);
        public void DeleteSale(int productId);
        public void DisplayOfAllSales(int saleId, decimal price, int productcount, DateTime date);
        public void ShowingSalesByDateRange(int saleId, decimal price, int productCount, DateTime startDate, DateTime endData);
        public void ShowingSalesByAmountRange(int saleId, decimal price, int productCount, DateTime dateTime, decimal minPrice, decimal maxPrice);
        public void ShowingSalesOnGivenDate(int saleId, decimal price, DateTime dateTime);
        public void DisplayingTheInformationGivenIdSale(int saleId, decimal price, int productCount, DateTime Date, List<SalesItem> salesItems);
    }
}
