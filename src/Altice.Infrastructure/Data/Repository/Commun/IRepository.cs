using Altice.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Infrastructure.Data.Repository.Commun
{
    public interface IRepository<T> where T : BaseEntity
    {
    }
}
