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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteOrderCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Order Deleted",
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
