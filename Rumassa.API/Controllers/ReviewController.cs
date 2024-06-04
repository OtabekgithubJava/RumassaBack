using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using Rumassa.Application.UseCases.ReviewCases.Commands;
using Rumassa.Application.UseCases.ReviewCases.Queries;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateReviewCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Review>> GetAll()
        {
            var result = await _mediator.Send(new GetAllReviewsQuery());

            return result;
        }

        [HttpGet]
        public async Task<Review> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetReviewByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateReviewCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteReviewCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
