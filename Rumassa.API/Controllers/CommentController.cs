using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Application.UseCases.CommentCases.Commands;
using Rumassa.Application.UseCases.CommentCases.Queries;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateCommentCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCommentsQuery());

            return result;
        }

        [HttpGet]
        public async Task<Comment> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCommentByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateCommentCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteCommentCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
