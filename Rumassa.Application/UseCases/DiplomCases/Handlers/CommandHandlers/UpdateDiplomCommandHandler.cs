using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.DiplomCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DiplomCases.Handlers.CommandHandlers
{
    public class UpdateDiplomCommandHandler : IRequestHandler<UpdateDiplomCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpdateDiplomCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ResponseModel> Handle(UpdateDiplomCommand request, CancellationToken cancellationToken)
        {
            var diplom = await _context.Diploms.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (diplom != null)
            {
                if (request.PhotoPath != null)
                {
                    var photoPath = diplom.PhotoPath;
                    if (File.Exists(photoPath))
                    {
                        File.Delete(photoPath);
                    }

                    var file = request.PhotoPath;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "DiplomPhotos");
                    string fileName = "";

                    try
                    {
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                            Console.WriteLine("Directory created successfully.");
                        }

                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        filePath = Path.Combine(_webHostEnvironment.WebRootPath, "DiplomPhotos", fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        diplom.PhotoPath = "/DiplomPhotos/" + fileName;
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

                diplom.Name = request.Name;
                _context.Diploms.Update(diplom);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Diplom Updated",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Diplom is not found",
                StatusCode = 400
            };
        }
    }
}
