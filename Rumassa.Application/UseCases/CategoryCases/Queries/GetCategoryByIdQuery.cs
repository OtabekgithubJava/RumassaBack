using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CategoryCases.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public short Id { get; set; }

    }
}
