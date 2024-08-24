using AutoMapper;
using WebApi.Controllers.Data.ValueObject;
using WebApi.Models;

namespace WebApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<StudentVO, Student>();
                config.CreateMap<Student, StudentVO>();
            });
            return mappingConfig;
        }
    }
}