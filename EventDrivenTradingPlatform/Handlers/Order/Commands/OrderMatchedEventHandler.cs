using MediatR;

namespace EventDrivenTradingPlatform.Handlers.Order
{
    public class OrderMatchedEventHandler : INotificationHandler<OrderMatchedEvent>
    {
        private readonly IMediator _mediator;

        public OrderMatchedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderMatchedEvent notification, CancellationToken cancellationToken)
        {
            // Logic for handling order matching
            // For now, this is a placeholder for actual matching logic
            System.Console.WriteLine($"Orders {notification.BuyOrderId} and {notification.SellOrderId} matched.");

            // Trigger TradeExecutedEvent
            var tradeId = System.Guid.NewGuid();
            await _mediator.Publish(new TradeExecutedEvent(tradeId, notification.BuyOrderId, notification.SellOrderId, notification.MatchedQuantity, notification.MatchedPrice), cancellationToken);
        }
    }
}