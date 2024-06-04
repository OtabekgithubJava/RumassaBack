
using MediatR;
using Microsoft.AspNetCore.Identity;
using Rumassa.Application.UseCases.Wishlists.Commands;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.Auth;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.Wishlists.Handlers.CommandHandlers
{
    public class RemoveFromWishlistCommandHandler : IRequestHandler<RemoveFromWishlistCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;

        public RemoveFromWishlistCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseModel> Handle(RemoveFromWishlistCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return new ResponseModel()
                {
                    Message = "Not found user",
                    StatusCode = 404,
                    IsSuccess = false
                };
            }

            var indexToRemove = user.Wishlist.FindIndex(x => x.Id == request.ProductId);
            
            if (indexToRemove >= 0)
            {
                user.Wishlist.RemoveAt(indexToRemove);
                await _userManager.UpdateAsync(user);
                return new ResponseModel()
                {
                    StatusCode = 200,
                    IsSuccess = true,
                    Message = "Deleted"
                };
            }


            return new ResponseModel()
            {
                StatusCode = 500,
                IsSuccess = true,
                Message = "Errore"
            };
        }
    }
}
