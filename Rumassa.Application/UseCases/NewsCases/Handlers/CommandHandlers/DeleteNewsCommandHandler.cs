using MediatR;
using Microsoft.EntityFrameworkCore;
using Rumassa.Application.Abstractions;
using Rumassa.Application.UseCases.NewsCases.Commands;
using Rumassa.Domain.Entities.DTOs;

namespace Rumassa.Application.UseCases.NewsCases.Handlers.CommandHandlers
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, ResponseModel>
    {
        private readonly IRumassaDbContext _context;

        public DeleteNewsCommandHandler(IRumassaDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _context.News.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (news != null)
            {
                var photoPath = news.CardPhotoPath;
                if (File.Exists(photoPath))
                {
                    File.Delete(photoPath);
                }

                _context.News.Remove(news);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"News Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "News is not found",
                StatusCode = 400
            };
        }
    }
}
