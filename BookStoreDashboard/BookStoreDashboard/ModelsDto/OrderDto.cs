using System.Collections.Generic;

namespace BookStoreDashboard.ModelsDto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OrderCode { get; set; }
        public decimal FullPrice { get; set; }
        public StatusEnum Status { get; set; }
        public List<BookDto> Books { get; set; }
    }
}
