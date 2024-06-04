using Rumassa.Domain.Entities.Auth;

namespace Rumassa.Domain.Entities
{
    public class Wishlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        //public IList<Product> WishlistProducts { get; set; }
    }
}
