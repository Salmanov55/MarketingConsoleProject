using Marketing_Console.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing_Console.Data.Models
{
    public class Sale : BaseEntitiy
    {
        private static int count = 0;
        public Sale(double salesAmount, List<SalesItem> salesItems, DateTime date)
        {
            SalesAmount = salesAmount;
            SalesItems = salesItems;
            Date = date;

            Id = count;
            count++;
        }
        public double SalesAmount { get; set; }
        public List<SalesItem> SalesItems { get; set; }
        public DateTime Date { get; set; }
    }
}
