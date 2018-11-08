using AutoMapper;
using ProjectsManagment.Entity.Models;
using ProjectsManagment.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsManagment.Web.Mappers
{
    public class ProjectRoleProfile : Profile
    {
        public ProjectRoleProfile()
        {
            CreateMap<ProjectRole, ProjectRoleViewModel>();
            CreateMap<ProjectRoleViewModel, ProjectRole>();
        }
    }
}