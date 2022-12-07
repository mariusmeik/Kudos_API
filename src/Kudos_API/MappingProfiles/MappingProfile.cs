using AutoMapper;
using Core.Entities;
using KudosAPI.DTOs;

namespace KudosAPI.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeDTO, EmployeeEntity>();
            CreateMap<EmployeeEntity, ReturnEmployeDTO>();

            CreateMap<CreateKudosDTO, KudosEntity>();
            CreateMap<KudosEntity, ReturnKudosDTO>();
        }
    }
}
