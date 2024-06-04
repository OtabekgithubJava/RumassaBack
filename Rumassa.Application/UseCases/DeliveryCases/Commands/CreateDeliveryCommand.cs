using MediatR;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DeliveryCases.Commands
{
    public class CreateDeliveryCommand : IRequest<ResponseModel>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Index { get; set; }
        public string StreetHouse { get; set; }
        public string Details { get; set; }
    }
}
