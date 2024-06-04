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
    public class UpdateDiplomCommand: IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FormFile PhotoPath { get; set; }
    }
}
