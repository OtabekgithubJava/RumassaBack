using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.NewsCases.Queries
{
    public class GetNewsByDateQuery : IRequest<List<News>>
    {
        public int Size {  get; set; }
    }
}
