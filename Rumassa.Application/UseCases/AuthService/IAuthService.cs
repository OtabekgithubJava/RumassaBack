using Rumassa.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.AuthService
{
    public interface IAuthService
    {

        public string GenerateToken(User user);

    }
}
