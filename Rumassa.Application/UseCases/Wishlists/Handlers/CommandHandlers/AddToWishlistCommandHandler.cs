using MediatR;
using Microsoft.AspNetCore.Identity;
using Rumassa.Application.Abstractions;
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
    public class AddToWishlistCommandHandler : IRequestHandler<AddToWishlistCommand, ResponseModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IRumassaDbContext _dbContext;

        public AddToWishlistCommandHandler(UserManager<User> userManager, IRumassaDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<ResponseModel> Handle(AddToWishlistCommand request, CancellationToken cancellationToken)
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
                return new ResponseModel()
                {
                    StatusCode = 400,
                    IsSuccess = true,
                    Message = "Aleady Exists"
                };
            }

            var product = _dbContext.Products.FirstOrDefault(x => x.Id == request.ProductId);
            user.Wishlist.Add(product ?? throw new Exception());

            await _userManager.UpdateAsync(user);

            return new ResponseModel()
            {
                IsSuccess = true,
                Message = "Added",
                StatusCode = 201
            };
        }
    }
}