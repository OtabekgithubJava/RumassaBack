using Rumassa.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double OrderPrice { get; set; }
        public double DeliveryPrice { get; set; }
        public double TotalPrice { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalAmount { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
