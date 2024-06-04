using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumassa.Domain.Entities.DTOs;
using Rumassa.Domain.Entities;
using Rumassa.Application.UseCases.CouponCases.Commands;
using Rumassa.Application.UseCases.CouponCases.Queries;

namespace Rumassa.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CouponController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponseModel> Create(CreateCouponCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Coupon>> GetAll()
        {
            var result = await _mediator.Send(new GetAllCouponsQuery());

            return result;
        }

        [HttpGet]
        public async Task<Coupon> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCouponByIdQuery()
            {
                Id = id
            });

            return result;
        }

        [HttpPut]
        public async Task<ResponseModel> Update(UpdateCouponCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpDelete]
        public async Task<ResponseModel> Delete(DeleteCouponCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
