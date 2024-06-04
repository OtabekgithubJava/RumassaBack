using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.NewsCases.Queries
{
    public class GetNewsByIdQuery : IRequest<News>
    {
        public Guid Id { get; set; }
    }
}
