using AutoMapper;

namespace MyForum.Business.Core.Infrastructure.Mappers
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}