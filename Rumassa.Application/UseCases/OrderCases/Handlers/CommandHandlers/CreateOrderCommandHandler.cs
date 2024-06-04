using MediatR;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.OrderCases.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateOrderCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var order = new Order()
                {
                    Date = request.Date,
                    OrderPrice = request.OrderPrice,
                    DeliveryPrice = request.DeliveryPrice,
                    TotalPrice = request.TotalPrice,
                    PaymentMethod = request.PaymentMethod,
                    TotalAmount = request.TotalAmount,
                    UserId = request.UserId
                };

                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Order is might be null",
                StatusCode = 400
            };
        }
    }
}
