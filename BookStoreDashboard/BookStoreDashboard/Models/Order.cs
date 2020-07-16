using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDashboard.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OrderCode { get; set; }
        public decimal FullPrice { get; set; }
        public string Status { get; set; }
        public List<Book> Books { get; set; }
    }
}
