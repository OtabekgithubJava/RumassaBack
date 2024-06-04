using MediatR;
using Microsoft.AspNetCore.Hosting;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.ProductCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.ProductCases.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateProductCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var photosFile = request.Photos;
                string photoPath = Path.Combine(_webHostEnvironment.WebRootPath, request.Name);
                string photoName = "";
                var product = new Product()
                {
                    Name = request.Name,
                    Price = request.Price,
                    CategoryId = request.CategoryId,
                    OrderId = request.OrderId ?? null,
                    NewsId = request.NewsId ?? null
                };

                try
                {
                    if (!Directory.Exists(photoPath))
                    {
                        Directory.CreateDirectory(photoPath);
                        Console.WriteLine("Directory created successfully.");
                    }

                    foreach (var photoFile in photosFile)
                    {
                        photoName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
                        photoPath = Path.Combine(_webHostEnvironment.WebRootPath, request.Name, photoName);

                        using (var stream = new FileStream(photoPath, FileMode.CreateNew))
                        {
                            await photoFile.CopyToAsync(stream);
                        }

                        product.PhotoPaths.Add('/' + request.Name + '/' + photoName); // Add photo path to the list
                    }

                }
                catch (Exception ex)
                {
                    return new ResponseModel()
                    {
                        Message = ex.Message,
                        StatusCode = 500,
                        IsSuccess = false
                    };
                }

                await _context.Products.AddAsync(product, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Product Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Product is might be null",
                StatusCode = 400
            };
        }
    }
}
