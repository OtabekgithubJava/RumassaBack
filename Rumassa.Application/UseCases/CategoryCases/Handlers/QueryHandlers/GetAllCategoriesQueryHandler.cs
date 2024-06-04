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
    public class GetAllCategoriesQueryHandler: IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllCategoriesQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
