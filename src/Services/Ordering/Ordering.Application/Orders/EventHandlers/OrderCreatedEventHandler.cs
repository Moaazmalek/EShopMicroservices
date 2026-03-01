namespace Ordering.Application.Orders.EventHandlers
{
    public class OrderCreatedEventHandler
        (Logger<OrderCreatedEventHandler> logger)
        : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain handled: {DomainEvent}",notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
