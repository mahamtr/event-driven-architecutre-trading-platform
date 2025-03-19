using MediatR;

namespace EventDrivenTradingPlatform.Handlers.Order
{
    public class OrderProcessedEventHandler : INotificationHandler<OrderProcessedEvent>
    {
        private readonly IMediator _mediator;

        public OrderProcessedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(OrderProcessedEvent notification, CancellationToken cancellationToken)
        {
            if (notification.IsValid)
            {
                // Logic to add the order to the order book for matching
                // For now, this is a placeholder for actual order book logic
                System.Console.WriteLine($"Order {notification.OrderId} added to the order book.");

                // Check if the processed order matches with any existing order
                bool isMatched = CheckForMatchingOrder(notification.OrderId); // Placeholder for matching logic

                if (isMatched)
                {
                    // Trigger OrderMatchedEvent
                    var buyOrderId = notification.OrderId; // Example placeholder
                    var sellOrderId = System.Guid.NewGuid(); // Example placeholder
                    decimal matchedQuantity = 100; // Example placeholder
                    decimal matchedPrice = 50; // Example placeholder

                    await _mediator.Publish(new OrderMatchedEvent(buyOrderId, sellOrderId, matchedQuantity, matchedPrice), cancellationToken);
                }
            }
            else
            {
                // Log or handle invalid order
                System.Console.WriteLine($"Order {notification.OrderId} is invalid: {notification.Reason}");
            }
        }

        private bool CheckForMatchingOrder(Guid orderId)
        {
            // Placeholder logic for checking matching orders
            // In a real implementation, this would query the order book
            return true; // Assume a match is found for demonstration purposes
        }
    }
}