using AutoMapper;

using System.Collections.Generic;

using Entities = Diiage.Directory.Core.Entities;
using Models = Diiage.Directory.Core.Models;

namespace Diiage.Directory.Infrastructure.Mapping
{
    internal class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Entities.Employee, Models.Employee>();
            CreateMap<Entities.Address, Models.Address>();
            CreateMap<IList<Entities.Employee>, Models.EmployeesSearchResponse>()
                .ForMember(dest => dest.Employees, o => o.MapFrom(src => src));
        }
    }
}
