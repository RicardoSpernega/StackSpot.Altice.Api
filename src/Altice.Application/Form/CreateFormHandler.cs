using Altice.Application.Form;
using Altice.Domain.Interfaces.Services;
using Altice.Domain.Request;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altice.Application.CreateForm
{
    public  class CreateFormHandler : IRequestHandler<CreateFormCommand, CreateFormResult>,
                                      IRequestHandler<ListFormCommand, IEnumerable<CreateFormResult>>
    {
        private readonly IFormService _formService;
        private readonly IMapper _mapper;

        public CreateFormHandler(IFormService formService, IMapper mapper)
        {
            _formService = formService;
            _mapper = mapper;

        }
        public async Task<CreateFormResult> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            var response = await _formService.Create(new FormRequest() { Email = request.Email, Morada = request.Morada, Nif = request.Nif, Nascimento = request.DataNascimento, Nome = request.Nome});
            return _mapper.Map<CreateFormResult>(response);
        }

        public async Task<IEnumerable<CreateFormResult>> Handle(ListFormCommand command, CancellationToken cancellationToken)
        {
            var response = await _formService.GetAllFormByEmail(command.Email);
            return _mapper.Map<IEnumerable<CreateFormResult>>(response);
        }
    }
}
