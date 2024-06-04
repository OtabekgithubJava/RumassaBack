using MediatR;
using Microsoft.AspNetCore.Identity;
using Rumassa.Application.UseCases.Wishlists.Queries;
using Rumassa.Domain.Entities;
using Rumassa.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.Wishlists.Handlers.QueryHandlers
{
    public class GetAllFromWishlistsQueryHandler(UserManager<User> userManager) : IRequestHandler<GetAllFromWishlistsQuery, IEnumerable<Product>>
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<IEnumerable<Product>> Handle(GetAllFromWishlistsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return Enumerable.Empty<Product>();
            }
            return user.Wishlist.ToList();
        }
    }
}
