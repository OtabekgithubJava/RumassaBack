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
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public UpdateCommentCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (comment != null)
            {
                comment.Name = request.Name;
                comment.Email = request.Email;
                comment.TelegramLogin = request.TelegramLogin;
                comment.Text = request.Text;
                comment.UserId = request.UserId;

                _context.Comments.Update(comment);

                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"Comment Updated",
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
