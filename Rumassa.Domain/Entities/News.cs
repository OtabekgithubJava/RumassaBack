using Rumassa.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CardPhotoPath { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual List<Product> Products  { get; set; }
    }
}
