using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Domain.Request
{
    public class FormRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public string Nif { get; set; }

        public string Morada { get; set; }
    }
}
