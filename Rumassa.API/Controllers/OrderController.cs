using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Application.UseCases.OrderCases.Queries;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAll()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());

            return result;
        }

        [HttpGet]
        public async Task<Order> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteOrderCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
