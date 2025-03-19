using MediatR;

namespace EventDrivenTradingPlatform.Handlers.Trade
{
    public class TradeNotificationEventHandler : INotificationHandler<TradeNotificationEvent>
    {
        public Task Handle(TradeNotificationEvent notification, CancellationToken cancellationToken)
        {
            // Logic for sending trade notifications
            // For now, this is a placeholder for actual notification logic
            System.Console.WriteLine($"Notification sent to Trader {notification.TraderId}: {notification.NotificationMessage}");

            return Task.CompletedTask;
        }
    }
}