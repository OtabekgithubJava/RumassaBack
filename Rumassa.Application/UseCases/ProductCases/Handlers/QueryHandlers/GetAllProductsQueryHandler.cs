using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.ProductCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllProductsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                    .Skip(request.PageIndex - 1)
                        .Take(request.Size)
                            .ToListAsync(cancellationToken);
        }
    }
}
