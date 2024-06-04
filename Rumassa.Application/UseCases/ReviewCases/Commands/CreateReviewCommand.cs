using MediatR;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ReviewCases.Commands
{
    public class CreateReviewCommand : IRequest<ResponseModel>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public Guid? ProductId { get; set; }

    }
}
