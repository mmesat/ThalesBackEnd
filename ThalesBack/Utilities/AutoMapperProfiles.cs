using AutoMapper;
using ThalesBack.DTOs;
using ThalesBack.Entity;

namespace ThalesBack.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
