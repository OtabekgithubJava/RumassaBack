using MediatR;
using Microsoft.AspNetCore.Http;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.NewsCases.Commands
{
    public class CreateNewsCommand : IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public IFormFile CardPhoto { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
    }
}
