using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Rumassa.Application.UseCases.CategoryCases.Commands;

namespace Rumassa.Application.UseCases.CategoryCases.Handlers.CommandHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateCategoryCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var category = new Category()
                {
                    Name = request.Name
                };

                await _context.Categories.AddAsync(category, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Category Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Category is might be null",
                StatusCode = 400
            };
        }
    }
}
