using MediatR;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CouponCases.Commands
{
    public class UpdateCouponCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
        public int Limit { get; set; }
        public short Percent { get; set; }
    }
}
