using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.CommentCases.Commands;
using Rumassa.Application.UseCases.OrderCases.Commands;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.CommentCases.Handlers.CommandHandlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteCommentCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Comment Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Comment is not found",
                StatusCode = 400
            };
        }
    }
}
