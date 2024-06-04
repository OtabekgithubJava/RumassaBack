using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.DiplomCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DiplomCases.Handlers.QueriesHandler
{
    public class GetAllDiplomsQueryHandler : IRequestHandler<GetAllDiplomsQuery, IEnumerable<Diplom>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllDiplomsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Diplom>> Handle(GetAllDiplomsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Diploms.ToListAsync(cancellationToken);
        }
    }
}
