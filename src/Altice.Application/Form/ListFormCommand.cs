using Altice.Application.CreateForm;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Application.Form
{
    public class ListFormCommand : IRequest<IEnumerable<CreateFormResult>>
    {
        [FromRoute]
        public string Email { get; set; }
    }
}
