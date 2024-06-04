using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.NewsCases.Queries;
using Rumassa.Domain.Entities;

namespace Rumassa.Application.UseCases.NewsCases.Handlers.QueryHandlers
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, News>
    {
        private readonly IRumassaDbContext _context;

        public GetNewsByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<News> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (news != null)
            {
                return news;
            }

            throw new Exception("News Not Found!");
        }
    }
}
