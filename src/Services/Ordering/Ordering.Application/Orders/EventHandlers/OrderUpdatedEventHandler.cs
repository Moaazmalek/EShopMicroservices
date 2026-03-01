namespace Ordering.Application.Orders.EventHandlers
{
    public class OrderUpdatedEventHandler
        (Logger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain handled: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
