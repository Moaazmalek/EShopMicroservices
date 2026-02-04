
using MediatR;

namespace BuildingBlocks.CQRS
{
  
    //Generic Query with response
    public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
    {
    }
}
