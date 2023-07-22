using Marketing_Console.Data.Enums;
using Marketing_Console.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Services.Abstract
{
    public interface IProductService
    {
        public int AddProduct(string productName, decimal price, string category);
        public void UpdateProduct(int productId, string productName, decimal price, string category);
        public void DeleteProduct(int productId);
        public List<Product> ShowAllProducts(int productId, string productName, string category, int count, decimal price);
        public List<Product> ShowProductsByCategory(int productId, string productName, string category, int count, decimal price);
        public List<Product> ViewProductsByPrice(decimal minPrice, decimal maxPrice);
        public List<Product> FindProductsByName(string productName);
    }
}
