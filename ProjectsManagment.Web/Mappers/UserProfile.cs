using AutoMapper;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;
using ProjectsManagment.Entity.ViewModels;
using ProjectsManagment.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsManagment.Web.App_Start.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
                       
        }
    }
}