using Altice.Domain.Models;
using Altice.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Domain.Interfaces.Services
{
    public interface IFormService
    {
        Task<FormResponse> Create(FormRequest formRequest);
        Task<IEnumerable<FormResponse>> GetAllFormByEmail(string email);
    }
}
