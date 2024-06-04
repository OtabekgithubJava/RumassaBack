using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.OrderCases.Handlers.QueryHandlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllOrdersQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken);
        }
    }
}
