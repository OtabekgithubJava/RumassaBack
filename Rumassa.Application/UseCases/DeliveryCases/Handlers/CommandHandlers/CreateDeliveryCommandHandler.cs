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
using Rumassa.Application.UseCases.DeliveryCases.Commands;
using System.IO;
using System.Text.RegularExpressions;

namespace Rumassa.Application.UseCases.DeliveryCases.Handlers.CommandHandlers
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateDeliveryCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var delivery = new Delivery()
                {
                  FullName=request.FullName,
                  Email=request.Email,
                  Country=request.Country,
                  Region=request.Region,
                  City=request.City,
                  Index=request.Index,
                  StreetHouse=request.StreetHouse,
                  Details=request.Details,
                };

                await _context.Deliveries.AddAsync(delivery, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Delivery Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Delivery is might be null",
                StatusCode = 400
            };
        }
    }
}
