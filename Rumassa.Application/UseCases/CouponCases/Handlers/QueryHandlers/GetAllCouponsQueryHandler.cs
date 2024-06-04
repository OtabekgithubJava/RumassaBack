using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.CouponCases.Queries;
using Rumassa.Application.UseCases.OrderCases.Queries;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CouponCases.Handlers.QueryHandlers
{
    public class GetAllCouponsQueryHandler : IRequestHandler<GetAllCouponsQuery, IEnumerable<Coupon>>
    {
        private readonly IRumassaDbContext _context;

        public GetAllCouponsQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Coupon>> Handle(GetAllCouponsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Coupons.ToListAsync(cancellationToken);
        }
    }
}
