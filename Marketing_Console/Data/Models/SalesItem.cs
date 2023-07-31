using Marketing_Console.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Data.Models
{
    public class SalesItem : BaseEntitiy
    {
        private static int count = 0;
        public SalesItem(Product product, int count)
        {
            Product = product;
            Count = count;

            Id = count;
            count++;
        }
        public Product Product { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }
        public double TotalPrice()
        {
            return Product.Price * Count;
        }
    }
}
