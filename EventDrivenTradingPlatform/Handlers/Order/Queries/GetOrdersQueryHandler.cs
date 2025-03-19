using MediatR;

namespace EventDrivenTradingPlatform.Handlers.Queries
{
    public record GetOrdersQuery(string TraderId) : IRequest<IEnumerable<Order>>;

    public class Order
    {
        public string OrderId { get; set; }
        public string TraderId { get; set; }
        public string OrderType { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        public Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            // Placeholder logic to fetch orders
            var orders = new List<Order>
            {
                new Order { OrderId = "1", TraderId = request.TraderId, OrderType = "Buy", Quantity = 10, Price = 100 },
                new Order { OrderId = "2", TraderId = request.TraderId, OrderType = "Sell", Quantity = 5, Price = 200 }
            };

            return Task.FromResult<IEnumerable<Order>>(orders);
        }
    }
}