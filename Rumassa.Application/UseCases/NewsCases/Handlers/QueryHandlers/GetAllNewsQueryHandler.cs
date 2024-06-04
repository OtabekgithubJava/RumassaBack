using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.NewsCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.NewsCases.Handlers.QueryHandlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<News>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllNewsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.News
                    .Skip(request.PageIndex - 1)
                        .Take(request.Size)
                            .ToListAsync(cancellationToken);
        }
    }
}
