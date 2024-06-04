using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.NewsCases.Queries
{
    public class GetAllNewsQuery : IRequest<IEnumerable<News>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
