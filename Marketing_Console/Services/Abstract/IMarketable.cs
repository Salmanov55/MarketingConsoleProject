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
        public void AddProduct(string productName, double price, Category category, int count);
        public void UpdateProduct(int productId, string productName, int count, double price, Category category);
        public void DeleteProduct(int productId);
        public List<Product> ShowAllProducts();
        public List<Product> ShowProductsByCategory(Category category);
        public List<Product> ViewProductsByPrice(double minPrice, double maxPrice);
        public List<Product> FindProductsByName(string productName);


        public void AddSale(List<ProductDto> productsDto);
        public void ReturnSale(int productId);
        public void DeleteSale(int productId);
        public List<Sale> DisplayOfAllSales();
        public List<Sale> ShowingSalesByDateRange(int saleId, double price, int productCount, DateTime startDate, DateTime endData);
        public List<SalesItem> ShowingSalesByAmountRange(int saleId, double price, int productCount, DateTime dateTime, double minPrice, double maxPrice);
        public void ShowingSalesOnGivenDate(int saleId, double price, DateTime dateTime);
        public void DisplayingTheInformationGivenIdSale(int saleId, double price, int productCount, DateTime Date, List<SalesItem> salesItems);
    }
}
