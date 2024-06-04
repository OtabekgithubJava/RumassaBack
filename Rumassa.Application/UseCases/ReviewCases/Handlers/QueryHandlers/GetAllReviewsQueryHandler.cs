using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Application.UseCases.ReviewCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ReviewCases.Handlers.QueryHandlers
{
    public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery, IEnumerable<Review>>
    {

        private readonly IRumassaDbContext _context;

        public GetAllReviewsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reviews.ToListAsync(cancellationToken);
        }

    }
}
