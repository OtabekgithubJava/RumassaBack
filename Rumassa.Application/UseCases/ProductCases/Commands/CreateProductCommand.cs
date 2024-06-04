using MediatR;
using Microsoft.AspNetCore.Http;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.ProductCases.Commands
{
    public class CreateProductCommand : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public List<IFormFile> Photos { get; set; }
        public short CategoryId { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? NewsId { get; set; }
    }
}
