using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EventDrivenTradingPlatform.Handlers.Order
{
    public class OrderPlacedEventHandler(IMediator mediator) : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IMediator _mediator = mediator;

        public async Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            // Validate the order
            bool isValid = notification.Quantity > 0 && notification.Price > 0;
            string reason = isValid ? "Order is valid." : "Invalid order details.";

            // Trigger OrderProcessedEvent
            await _mediator.Publish(new OrderProcessedEvent(notification.OrderId, isValid, reason), cancellationToken);
        }
    }
}