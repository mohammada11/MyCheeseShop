using MyCheeseShop.Model;
using Microsoft.EntityFrameworkCore;




namespace MyCheeseShop.Context
{
    public class OrderProvider
    {
        private readonly DatabaseContext _context;
        public OrderProvider(DatabaseContext context) 
        {
            _context = context;
        }
        public async Task CreateOrder(User user, IEnumerable<CartItem> items)
        {
            var order = new Order
            {
                User = user,
                Items = items.Select(item => new OrderItem
                {
                    Cheese = item.Cheese,
                    Quantity = item.Quantity,
                }).ToList(),
                Created = DateTime.Now,
                Status = OrderStatus.Placed
            };
             
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

        }
    }
}
