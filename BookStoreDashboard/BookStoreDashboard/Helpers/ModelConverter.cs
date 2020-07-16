using BookStoreDashboard.Models;
using BookStoreDashboard.ModelsDto;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace BookStoreDashboard.Helpers
{
    public static class ModelConverter
    {
        public static UserDtoModel ToUserDto(this IdentityUser user)
        {
            return new UserDtoModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };
        }
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto 
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                Price = book.Price,
                Quantity = book.Quantity,
            };
        }

        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                Name = order.Name,
                Phone = order.Phone,
                Email = order.Email,
                Address = order.Address,
                FullPrice = order.FullPrice,
                OrderCode = order.OrderCode,
                Books = order.Books.Select(x => x.ToBookDto()).ToList(),
                Status = GetStatusEnum(order.Status),
            };
        }
        public static StatusEnum GetStatusEnum(string orderStatus)
        {
            StatusEnum.TryParse(orderStatus, out StatusEnum result);
            return result;
        }
    }
}