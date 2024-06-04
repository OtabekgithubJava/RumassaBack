using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using Rumassa.Application.UseCases.NewsCases.Commands;
using Rumassa.Application.UseCases.NewsCases.Queries;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly IMediator _mediator;
        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateNewsCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<News>> GetAll(int pageIndex, int size)
        {
            var result = await _mediator.Send(new GetAllNewsQuery()
            {
                PageIndex = pageIndex,
                Size = size
            });

            return result;
        }

        [HttpGet]
        public async Task<News> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetNewsByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpGet]
        public async Task<List<News>> GetByDate(int size)
        {
            var result = await _mediator.Send(new GetNewsByDateQuery()
            {
                Size = size
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateNewsCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteNewsCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
