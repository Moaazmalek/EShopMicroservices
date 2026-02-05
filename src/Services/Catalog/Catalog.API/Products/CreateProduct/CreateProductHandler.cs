
using MediatR;
using BuildingBlocks.CQRS;
using Catalog.API.Models;
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
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
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

             return new CreateProductResult(Guid.NewGuid());

            
        }
    }
}
