using BuildingBlocks.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler :
        ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //Create order entity from command object
            //save to database
            //return result
            
        }
    }
}
