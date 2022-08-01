using System;
using System.Runtime.Serialization;
using AutoMapper;
using Altice.Application.Common.Mappings;
using Altice.Domain.Models;
using Xunit;

namespace Altice.Application.UnitTests.Common.Mappings
{
    public class MappingProfileTests
    {

        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingProfileTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddProfile<MappingProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }


        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type)!;

            return FormatterServices.GetUninitializedObject(type);
        }
    }
}