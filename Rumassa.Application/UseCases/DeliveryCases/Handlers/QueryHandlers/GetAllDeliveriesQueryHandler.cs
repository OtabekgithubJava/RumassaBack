using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.DeliveryCases.Queries;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DeliveryCases.Handlers.QueryHandlers
{
    public class GetAllDeliveriesQueryHandler : IRequestHandler<GetAllDeliveriesQuery, IEnumerable<Delivery>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllDeliveriesQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Delivery>> Handle(GetAllDeliveriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Deliveries.ToListAsync(cancellationToken);
        }
    }
}
