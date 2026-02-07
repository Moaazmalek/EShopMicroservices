

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        string Description,
        List<string> Category,
        string ImageFile,
        decimal Price
    ):ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    //business logic 
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            

        }

    }
    internal class CreateProductCommandHandler
        (IDocumentSession session,
        IValidator<CreateProductCommand> validator)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create a product goes here

            //Create  Product entity from command object
            //Save to database 
            //Return the result
            var result = await validator.ValidateAsync(command, cancellationToken);
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            if (errors.Any())
                throw new ValidationException(errors.FirstOrDefault());
            
            var product = new Product
            {
                Name = command.Name,
                Description = command.Description,
                Category = command.Category,
                ImageFile = command.ImageFile,
                Price = command.Price


            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);

            
        }
    }
}
