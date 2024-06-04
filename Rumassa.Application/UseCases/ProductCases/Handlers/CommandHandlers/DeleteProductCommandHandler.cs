using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.ProductCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.ProductCases.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteProductCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, product.Name);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Product Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Product is not found",
                StatusCode = 400
            };
        }
    }
}
