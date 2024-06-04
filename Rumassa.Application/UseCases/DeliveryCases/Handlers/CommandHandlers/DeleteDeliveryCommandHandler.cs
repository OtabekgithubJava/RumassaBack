using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.DeliveryCases.Commands;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DeliveryCases.Handlers.CommandHandlers
{
    public class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteDeliveryCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteDeliveryCommand request, CancellationToken cancellationToken)
        {
            var delivery = await _context.Deliveries.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Delivery Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Delivery is not found",
                StatusCode = 400
            };
        }
    }
}
