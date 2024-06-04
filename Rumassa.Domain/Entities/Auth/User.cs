using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<Product> Wishlist { get; set; }
        public virtual List<News> News { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
