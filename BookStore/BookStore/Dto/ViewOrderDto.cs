using BookStore.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Dto
{
    public class ViewOrderDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string OrderCode { get; set; }
        [Required]
        public decimal FullPrice { get; set; }
        public string Status { get; set; }
        public List<BooksDto> Books { get; set; }
    }
}
