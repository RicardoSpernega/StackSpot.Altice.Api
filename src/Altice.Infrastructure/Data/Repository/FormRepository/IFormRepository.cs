using Altice.Domain.Models;
using Altice.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Data.Repository.FormRepository
{
    public interface IFormRepository
    {
        Task<FormResponse> NewForm(FormRequest formRequest);
        Task<IEnumerable<FormResponse>> GetAllFormByEmail(string email);
    }
}
