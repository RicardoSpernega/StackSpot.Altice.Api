using System;
using AutoMapper;
using Altice.Application.Common.Mappings;
using Altice.Domain.Enums;
using Altice.Domain.Models;

namespace Altice.Application.CreateHelloWorld
{
    public class CreateHelloWorldResult : IMapFrom<HelloWorldResponse>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public UserLevel Level { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HelloWorldResponse, CreateHelloWorldResult>()
                .ForMember(d => d.Level, opt => opt.MapFrom(s => (UserLevel)s.Level))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));
        }
    }
}