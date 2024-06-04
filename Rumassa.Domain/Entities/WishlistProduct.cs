using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class WishlistProduct
    {
        public Guid WishlistId { get; set; }
       //s public virtual Wishlist Wishlist { get; set; }
        public Guid ProductId { get; set; }
        //public virtual Product Product { get; set; }
    }
}
