using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.ProductCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.ProductCases.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IRumassaDbContext _context;

        public GetProductByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                return product;
            }

            throw new Exception("Product Not Found!");
        }
    }
}
