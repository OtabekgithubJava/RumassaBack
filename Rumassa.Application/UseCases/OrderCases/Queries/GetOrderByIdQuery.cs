using MediatR;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.OrderCases.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid Id { get; set; }
    }
}
