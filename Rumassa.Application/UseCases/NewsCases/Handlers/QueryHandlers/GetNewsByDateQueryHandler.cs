using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.NewsCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.NewsCases.Handlers.QueryHandlers
{
    public class GetNewsByDateQueryHandler : IRequestHandler<GetNewsByDateQuery, List<News>>
    {
        private readonly IRumassaDbContext _rumassaDbContext;

        public GetNewsByDateQueryHandler(IRumassaDbContext rumassaDbContext)
        {
            _rumassaDbContext = rumassaDbContext;
        }

        public async Task<List<News>> Handle(GetNewsByDateQuery request, CancellationToken cancellationToken)
        {
            return await _rumassaDbContext.News.OrderByDescending(p => p.Date).Take(request.Size).ToListAsync();

        }
    }
}
