using AutoMapper;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper {
    public class MappingProfiles:Profile {
        public MappingProfiles() {
            CreateMap<Employee,EmployeeDto>();
            CreateMap<EmployeeDto,Employee>();

            CreateMap<Manager,ManagerDto>();
            CreateMap<ManagerDto,Manager>();

            CreateMap<TaskDto,Domain.Models.Task>();

            CreateMap<Domain.Models.Task,TaskDto>();
         }
    }
}
