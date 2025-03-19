using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventDrivenTradingPlatform.Handlers.Trade
{
    public class TradeExecutedEventHandler : INotificationHandler<TradeExecutedEvent>
    {
        private readonly IMediator _mediator;

        public TradeExecutedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(TradeExecutedEvent notification, CancellationToken cancellationToken)
        {
            // Logic for handling trade execution
            System.Console.WriteLine($"Trade {notification.TradeId} executed: BuyOrder {notification.BuyOrderId}, SellOrder {notification.SellOrderId}, Quantity {notification.Quantity}, Price {notification.Price}.");

            // Notify the trader about the trade execution
            string notificationMessage = $"Your trade with ID {notification.TradeId} has been successfully executed.";
            await _mediator.Publish(new TradeNotificationEvent(notification.BuyOrderId, notificationMessage), cancellationToken);
        }
    }
}