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
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, Review>
    {

        private readonly IRumassaDbContext _context;

        public GetReviewByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                return review;
            }

            throw new Exception("Review Not Found!");
        }

    }
}
