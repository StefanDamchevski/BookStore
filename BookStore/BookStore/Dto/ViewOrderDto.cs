using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public List<BooksDto> Books { get; set; }
    }
}
