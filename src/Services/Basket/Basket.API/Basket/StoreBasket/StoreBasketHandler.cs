


namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketCommand(ShoppingCart Cart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);
    public class StorBasketCommandValidator:AbstractValidator<StoreBasketCommand>
    {
        public StorBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can't be null");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
    public class StoreBasketCommandHandler(IBasketRepository repository): ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            var cart = command.Cart;

            //TODO: update cache
            await repository.StoreBasket(cart,cancellationToken);
            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
