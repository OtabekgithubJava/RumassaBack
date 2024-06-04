using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.OrderCases.Handlers.QueryHandlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IRumassaDbContext _context;

        public GetOrderByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                return order;
            }

            throw new Exception("Order Not Found!");
        }
    }
}
