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
        //Interface of the product class
        public void AddProduct(string productName, double price, Category category, int count);
        public void UpdateProduct(int productId, string productName, int count, double price, Category category);
        public void DeleteProduct(int productId);
        public List<Product> ShowAllProducts();
        public List<Product> ShowProductsByCategory(Category category);
        public List<Product> ViewProductsByPrice(double minPrice, double maxPrice);
        public List<Product> FindProductsByName(string productName);

        //Interface of the sales class
        public void AddSale(List<ProductDto> productsDto);
        public void ReturnSale(int saleId);
        public void DeleteSale(int productId);
        public List<Sale> DisplayOfAllSales();
        public List<Sale> ShowingSalesByDateRange(DateTime startDate, DateTime endDate);
        public List<Sale> ShowingSalesByAmountRange(double minPrice, double maxPrice);
        public List<Sale> ShowingSalesOnGivenDate(DateTime dateTime);
        public List<Sale> DisplayingTheInformationGivenIdSale(int saleId);
    }
}
