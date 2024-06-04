using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DeliveryCases.Queries
{
    public class GetAllDeliveriesQuery : IRequest<IEnumerable<Delivery>>
    {
    }
}
