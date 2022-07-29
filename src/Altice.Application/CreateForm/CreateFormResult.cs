using Altice.Application.Common.Mappings;
using Altice.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altice.Application.CreateForm
{
    public class CreateFormResult : IMapFrom<FormResponse>
    {
        public string Result { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FormResponse, CreateFormResult>()
                .ForMember(d => d.Result, opt => opt.MapFrom(s => s.Sucesso));

        }
    }
}

