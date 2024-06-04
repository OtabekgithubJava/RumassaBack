using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CouponCases.Queries
{
    public class GetCouponByIdQuery : IRequest<Coupon>
    {
        public Guid Id { get; set; }

    }
}
