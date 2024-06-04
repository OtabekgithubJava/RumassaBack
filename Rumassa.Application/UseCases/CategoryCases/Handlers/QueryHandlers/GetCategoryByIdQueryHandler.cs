using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.CategoryCases.Queries;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CategoryCases.Handlers.QueryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IRumassaDbContext _context;

        public GetCategoryByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (category != null)
            {
                return category;
            }

            throw new Exception("Category Not Found!");
        }
    }
}
