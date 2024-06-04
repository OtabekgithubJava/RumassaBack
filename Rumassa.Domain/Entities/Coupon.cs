using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public DateTimeOffset ExpireDate { get; set; }
        public int Limit { get; set; } = 2;
        public short Percent { get; set; } = 10;
    }
}
