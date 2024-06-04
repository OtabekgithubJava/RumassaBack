using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.CommentCases.Queries;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CommentCases.Handlers.QueryHandlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<Comment>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllCommentsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comments.ToListAsync(cancellationToken);
        }
    }
}
