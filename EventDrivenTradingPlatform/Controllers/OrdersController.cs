using EventDrivenTradingPlatform.Handlers.Order;
using EventDrivenTradingPlatform.Handlers.Queries;
using EventDrivenTradingPlatform.Handlers.Trade;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventDrivenTradingPlatform.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request)
        {
            var orderId = Guid.NewGuid();

            // Trigger OrderPlacedEvent
            await _mediator.Publish(new OrderPlacedEvent(orderId, request.TraderId, request.OrderType, request.Quantity, request.Price));

            return Ok(new { OrderId = orderId, Message = "Order placed successfully." });
        }

        [HttpGet("orders/{traderId}")]
        public async Task<IActionResult> GetOrders(string traderId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetOrdersQuery(traderId), cancellationToken);
            return Ok(result);
        }

        [HttpGet("trades/{traderId}")]
        public async Task<IActionResult> GetTrades(string traderId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetTradesQuery(traderId), cancellationToken);
            return Ok(result);
        }
    }

    public class PlaceOrderRequest
    {
        public string TraderId { get; set; }
        public string OrderType { get; set; } // "Buy" or "Sell"
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}