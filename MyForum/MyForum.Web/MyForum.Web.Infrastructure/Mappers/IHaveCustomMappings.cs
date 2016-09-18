using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Mappers
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}