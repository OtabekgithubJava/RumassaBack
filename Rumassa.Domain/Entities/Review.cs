using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
