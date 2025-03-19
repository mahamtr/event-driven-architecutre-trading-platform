using MediatR;

namespace EventDrivenTradingPlatform
{
    public record OrderPlacedEvent(Guid OrderId, string TraderId, string OrderType, decimal Quantity, decimal Price) : INotification;

    public record OrderProcessedEvent(Guid OrderId, bool IsValid, string Reason) : INotification;

    public record OrderMatchedEvent(Guid BuyOrderId, Guid SellOrderId, decimal MatchedQuantity, decimal MatchedPrice) : INotification;

    public record TradeExecutedEvent(Guid TradeId, Guid BuyOrderId, Guid SellOrderId, decimal Quantity, decimal Price) : INotification;

    public record TradeNotificationEvent(Guid TraderId, string NotificationMessage) : INotification;
}