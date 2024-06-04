using MediatR;
using Microsoft.AspNetCore.Hosting;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.DiplomCases.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DiplomCases.Handlers.CommandHandlers
{
    public class CreateDiplomCommandHandler : IRequestHandler<CreateDiplomCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public CreateDiplomCommandHandler(IRumassaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        private readonly IWebHostEnvironment _webHostEnvironment;
        public async Task<ResponseModel> Handle(CreateDiplomCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
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

                var diplom = new Diplom()
                {
                    Name = request.Name,
                    PhotoPath = "/DiplomPhotos/" + fileName,
                };

                await _context.Diploms.AddAsync(diplom, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel()
                {
                    StatusCode = 201,
                    Message = $"Diplom Created",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Diplom is might be null",
                StatusCode = 400
            };
        }
    }
}
