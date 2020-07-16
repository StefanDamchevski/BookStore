using BookStore.Data;
using BookStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public List<Order> GetAll()
        {
            return context.Orders
                .Include(x => x.BookOrders)
                    .ThenInclude(x => x.Book)
                .ToList();
        }

        public Order GetById(int id)
        {
            return context.Orders
                .Include(x => x.BookOrders)
                    .ThenInclude(x => x.Book)
                .FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrder(string email, string orderCode)
        {
            return context.Orders
                .Include(x => x.BookOrders)
                    .ThenInclude(x => x.Book)
                .FirstOrDefault(x => x.Email == email && x.OrderCode == orderCode);
        }

        public void Update(Order dbOrder)
        {
            context.Orders.Update(dbOrder);
            context.SaveChanges();
        }
    }
}
