using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.OrderCases.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public UpdateOrderCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                order.Date = request.Date;
                order.OrderPrice = request.OrderPrice;
                order.DeliveryPrice = request.DeliveryPrice;
                order.TotalPrice = request.TotalPrice;
                order.PaymentMethod = request.PaymentMethod;
                order.TotalAmount = request.TotalAmount;
                order.UserId = request.UserId;

                _context.Orders.Update(order);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Order is not found",
                StatusCode = 400
            };
        }
    }
}
