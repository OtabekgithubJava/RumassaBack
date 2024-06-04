using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.CategoryCases.Commands;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CategoryCases.Handlers.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteCategoryCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Category Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Category is not found",
                StatusCode = 400
            };
        }
    }
}
