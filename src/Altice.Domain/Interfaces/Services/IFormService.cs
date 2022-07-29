using Altice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Domain.Interfaces.Services
{
    public interface IFormService
    {
        Task<FormResponse> Create();
    }
}
