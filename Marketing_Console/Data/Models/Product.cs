using Marketing_Console.Data.Common;
using Marketing_Console.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Data.Models
{
    public class Product : BaseEntitiy
    {
        private static int count = 0;
        public Product(string productName, double price, Category category, int productCount)
        {
            ProductName = productName;
            Price = price;
            Category = category;
            ProductCount = productCount;

            Id = count;
            count++;
        }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int ProductCount { get; set; }
        public object ProductId { get; set; }
    }
}
