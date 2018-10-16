using AutoMapper;
using Svc.Tasks;
using Svc.Tasks.Dtos;

namespace Svc
{
    internal static class DtoMappings
    {
        public static void Map(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Task, TaskDto>();
        }
    }
}
