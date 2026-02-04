
using MediatR;
using BuildingBlocks.CQRS;
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
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Business logic to create a product goes here

            throw new NotImplementedException();
        }
    }
}
