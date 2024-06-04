using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Application.UseCases.ReviewCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ReviewCases.Handlers.CommandHandlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, ResponseModel>
    {

        private readonly IRumassaDbContext _context;

        public DeleteReviewCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Review is not found",
                StatusCode = 400
            };
        }

    }
}
