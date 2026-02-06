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
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic to create a product goes here

            //Create  Product entity from command object
            //Save to database 
            //Return the result
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
