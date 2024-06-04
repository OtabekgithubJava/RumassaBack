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
using Rumassa.Application.UseCases.CouponCases.Commands;

namespace Rumassa.Application.UseCases.CouponCases.Handlers.CommandHandlers
{
    public class CreateCouponCommandHandler : IRequestHandler<CreateCouponCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateCouponCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var coupon = new Coupon()
                {
                    Code = request.Code,
                    ExpireDate = request.ExpireDate,
                    Limit = request.Limit,
                    Percent = request.Percent,
                };

                await _context.Coupons.AddAsync(coupon, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Coupon Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Coupon is might be null",
                StatusCode = 400
            };
        }
    }
}
