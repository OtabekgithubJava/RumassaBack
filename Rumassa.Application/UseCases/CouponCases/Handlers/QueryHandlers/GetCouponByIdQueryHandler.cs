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
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, Coupon>
    {
        private readonly IRumassaDbContext _context;

        public GetCouponByIdQueryHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (coupon != null)
            {
                return coupon;
            }

            throw new Exception("Coupon Not Found!");
        }
    }
}
