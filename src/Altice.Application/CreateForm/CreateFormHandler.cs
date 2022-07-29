using Altice.Domain.Interfaces.Services;
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
    public  class CreateFormHandler : IRequestHandler<CreateFormCommand, CreateFormResult>
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
            var response = await _formService.Create();
            return _mapper.Map<CreateFormResult>(response);
        }
    }
}
