using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.ProductCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;
using System.Xml.Linq;

namespace Rumassa.Application.UseCases.ProductCases.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UpdateProductCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product != null)
            {
                if (request.Photos != null)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, product.Name);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    var photosFile = request.Photos;
                    string photoPath = "";
                    string photoName = "";
                    List<string> photosPaths = new List<string>();

                    try
                    {
                        foreach (var photoFile in photosFile)
                        {
                            photoName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
                            photoPath = Path.Combine(_webHostEnvironment.ContentRootPath, request.Name, photoName);

                            using (var stream = new FileStream(photoPath, FileMode.Create))
                            {
                                await photoFile.CopyToAsync(stream);
                            }

                            photosPaths.Add('/' + request.Name + '/' + photoName); 
                        }

                        product.PhotoPaths = photosPaths;
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
                }

                product.Name = request.Name;
                product.Price = request.Price;
                product.CategoryId = request.CategoryId;
                product.OrderId = request.OrderId;
                product.NewsId = request.NewsId;

                _context.Products.Update(product);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Product Updated",
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
