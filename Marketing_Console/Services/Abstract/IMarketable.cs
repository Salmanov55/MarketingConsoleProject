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
        public void AddProduct(string productName, decimal price, Category category, int count);
        public void UpdateProduct(int productId, string productName, int count, decimal price, Category category);
        public void DeleteProduct(int productId);
        public List<Product> ShowAllProducts();
        public List<Product> ShowProductsByCategory(Category category);
        public List<Product> ViewProductsByPrice(decimal minPrice, decimal maxPrice);
        public List<Product> FindProductsByName(string productName);


        public int AddSale( List<SalesItem> salesItems, double salesAmount);
        public void ReturnSale(int productId);
        public void DeleteSale(int productId);
        public void DisplayOfAllSales(int saleId, decimal price, int productcount, DateTime date);
        public List<Sale> ShowingSalesByDateRange(int saleId, decimal price, int productCount, DateTime startDate, DateTime endData);
        public List<SalesItem> ShowingSalesByAmountRange(int saleId, decimal price, int productCount, DateTime dateTime, decimal minPrice, decimal maxPrice);
        public void ShowingSalesOnGivenDate(int saleId, decimal price, DateTime dateTime);
        public void DisplayingTheInformationGivenIdSale(int saleId, decimal price, int productCount, DateTime Date, List<SalesItem> salesItems);
    }
}
