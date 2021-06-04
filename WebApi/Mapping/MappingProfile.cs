using AutoMapper;
using Common.DTO;
using Common.Entities;

namespace PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Developer, DeveloperDTO>()
                .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + ' ' + c.SecondName));
            CreateMap<Project, ProjectDTO>();

            //DTO to Entity
            CreateMap<DeveloperDTO, Developer>()
                .ForMember("FirstName", opt => opt.MapFrom(c => c.Name.Substring(0, c.Name.IndexOf(' '))))
                .ForMember("SecondName", opt => opt.MapFrom(c => c.Name.Substring(c.Name.IndexOf(' '))));
            CreateMap<ProjectDTO, Project>();
        }
    }
}
