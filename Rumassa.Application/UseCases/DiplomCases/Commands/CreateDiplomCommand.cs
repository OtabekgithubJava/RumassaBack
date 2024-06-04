using MediatR;
using Microsoft.AspNetCore.Http;
using Rumassa.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rumassa.Application.UseCases.DiplomCases.Commands
{
    public class CreateDiplomCommand: IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}
