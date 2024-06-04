using MediatR;
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
    public class DeleteDiplomCommandHandler : IRequestHandler<DeleteDiplomCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteDiplomCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteDiplomCommand request, CancellationToken cancellationToken)
        {
            var diplom = await _context.Diploms.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (diplom != null)
            {
                var photoPath = diplom.PhotoPath;
                if (File.Exists(photoPath))
                {
                    File.Delete(photoPath);
                }

                _context.Diploms.Remove(diplom);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Diplom Deleted",
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
