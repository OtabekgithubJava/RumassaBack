using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Application.UseCases.NewsCases.Commands;
using Rumassa.Application.UseCases.NewsCases.Queries;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using Rumassa.Application.UseCases.DiplomCases.Commands;
using Rumassa.Application.UseCases.DiplomCases.Queries;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiplomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiplomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateDiplomCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Diplom>> GetAll(int pageIndex, int size)
        {
            var result = await _mediator.Send(new GetAllDiplomsQuery()
            {
                PageIndex = pageIndex,
                Size = size
            });

            return result;
        }

        [HttpGet]
        public async Task<Diplom> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAllDiplomsByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateDiplomCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteDiplomCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
