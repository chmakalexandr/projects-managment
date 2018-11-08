using AutoMapper;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;
using ProjectsManagment.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsManagment.Web.App_Start.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();
        }
    }
}