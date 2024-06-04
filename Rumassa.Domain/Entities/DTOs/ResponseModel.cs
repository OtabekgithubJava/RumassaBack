using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Domain.Entities.DTOs
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
