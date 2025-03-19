using MediatR;

namespace EventDrivenTradingPlatform.Handlers.Queries
{
    public record GetTradesQuery(string TraderId) : IRequest<IEnumerable<Trade>>;

    public class Trade
    {
        public string TradeId { get; set; }
        public string TraderId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class GetTradesQueryHandler : IRequestHandler<GetTradesQuery, IEnumerable<Trade>>
    {
        public Task<IEnumerable<Trade>> Handle(GetTradesQuery request, CancellationToken cancellationToken)
        {
            // Placeholder logic to fetch trades
            var trades = new List<Trade>
            {
                new Trade { TradeId = "1", TraderId = request.TraderId, Quantity = 10, Price = 100 },
                new Trade { TradeId = "2", TraderId = request.TraderId, Quantity = 5, Price = 200 }
            };

            return Task.FromResult<IEnumerable<Trade>>(trades);
        }
    }
}