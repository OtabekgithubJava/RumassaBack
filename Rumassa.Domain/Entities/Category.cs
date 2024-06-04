using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class Category
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
