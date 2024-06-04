using MediatR;
using Rumassa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.ReviewCases.Queries
{
    public class GetAllReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
