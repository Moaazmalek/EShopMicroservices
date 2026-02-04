
using MediatR;

namespace BuildingBlocks.CQRS
{
    //Empty ICommand
    public interface ICommand : ICommand<Unit>
    {
    }
    //Generic Command with response
    public interface ICommand<out TResponse>:IRequest<TResponse>
    {
    }
}
