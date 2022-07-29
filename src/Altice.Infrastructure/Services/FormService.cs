using Altice.Domain.Interfaces.Services;
using Altice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Services
{
    public  class FormService : IFormService
    {
        public async Task<FormResponse> Create()
        {
            await Task.Delay(2000);
            return new FormResponse
            {
                Sucesso = "Testando command"
            };
        }
    }
}
