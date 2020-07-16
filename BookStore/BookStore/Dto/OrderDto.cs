using System.Collections.Generic;

namespace BookStore.Dto
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
        public string Status { get; set; }
        public List<BooksDto> Books { get; set; }
    }
}
