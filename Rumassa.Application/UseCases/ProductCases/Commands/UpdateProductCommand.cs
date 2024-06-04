using MediatR;
using Microsoft.AspNetCore.Http;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ProductCases.Commands
{
    public class UpdateProductCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<IFormFile> Photos { get; set; }
        public short CategoryId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? NewsId { get; set; }
    }
}
