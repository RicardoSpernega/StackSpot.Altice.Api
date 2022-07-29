using Altice.Domain.Interfaces.Services;
using Altice.Domain.Models;
using Altice.Domain.Request;
using Altice.Infrastructure.Data.Repository.FormRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Services
{
    public  class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public async Task<FormResponse> Create(FormRequest formRequest)
        {
            return await _formRepository.NewForm(formRequest);
        }

        public async Task<IEnumerable<FormResponse>> GetAllFormByEmail(string email)
        {
            return await _formRepository.GetAllFormByEmail(email);
        }
    }
}
