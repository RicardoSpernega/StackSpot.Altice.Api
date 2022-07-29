﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Altice.Domain.Models
{
    public class FormResponse : BaseEntity
    {
        public int FormId { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public string Nif { get; set; }

        public string Morada { get; set; }
    }
}
