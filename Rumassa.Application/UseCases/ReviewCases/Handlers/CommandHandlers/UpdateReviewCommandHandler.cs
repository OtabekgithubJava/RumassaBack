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
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ResponseModel>
    {

        private readonly IRumassaDbContext _context;

        public UpdateReviewCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review != null)
            {
                review.Username = request.Username;
                review.Email = request.Email;
                review.Text = request.Text;
                review.ProductId = request.ProductId;

                _context.Reviews.Update(review);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Review Updated",
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
