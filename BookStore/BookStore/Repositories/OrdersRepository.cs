using BookStore.Data;
using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStore.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly BookStroreDbContext context;

        public OrdersRepository(BookStroreDbContext context)
        {
            this.context = context;
        }
        public void Create(Order newOrder)
        {
            context.Orders.Add(newOrder);
            context.SaveChanges();
        }

        public Order GetOrder(string email, string orderCode)
        {
            return context.Orders
                .Include(x => x.BookOrders)
                    .ThenInclude(x => x.Book)
                .FirstOrDefault(x => x.Email == email && x.OrderCode == orderCode);
        }
    }
}
