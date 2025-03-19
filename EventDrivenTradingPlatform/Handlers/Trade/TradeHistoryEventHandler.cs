using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventDrivenTradingPlatform.Handlers.Trade
{
    public class TradeHistoryEventHandler : INotificationHandler<TradeExecutedEvent>
    {
        public Task Handle(TradeExecutedEvent notification, CancellationToken cancellationToken)
        {
            // Logic to add trade history to the database
            // Placeholder for actual database logic
            System.Console.WriteLine($"Trade history added for Trade ID: {notification.TradeId}");

            return Task.CompletedTask;
        }
    }
}