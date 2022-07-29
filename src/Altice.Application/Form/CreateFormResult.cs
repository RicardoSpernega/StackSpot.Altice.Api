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
        public int FormId { get; set; }
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public string Nif { get; set; }

        public string Morada { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<FormResponse, CreateFormResult>()
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Nome, opt => opt.MapFrom(s => s.Nome))
                .ForMember(d => d.FormId, opt => opt.MapFrom(s => s.FormId))
                .ForMember(d => d.Nascimento, opt => opt.MapFrom(s => s.Nascimento))
                .ForMember(d => d.Nif, opt => opt.MapFrom(s => s.Nif))
                .ForMember(d => d.Morada, opt => opt.MapFrom(s => s.Morada));


        }
    }
}

