using API.DTO;
using AutoMapper;
using Service.Entities;

namespace API
{
    public class MappingProfiles : Profile
    {
            public MappingProfiles()
            {
                CreateMap<ExampleEntity, ExampleEntityDTO>();
                CreateMap<ExampleEntityDTO, ExampleEntity>();
            }
    }
}