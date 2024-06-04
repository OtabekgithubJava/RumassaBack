using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ProductCases.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int PageIndex { get; set; }
        public int Size { get; set; }
    }
}
