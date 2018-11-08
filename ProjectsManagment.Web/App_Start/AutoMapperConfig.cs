using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.ViewModels;
using ProjectsManagment.Web.App_Start.Mappers;

namespace ProjectsManagment.Web.App_Start.MapperProfiles
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<RoleProfile>();
                //config.AddProfile<ProjectRoleProfile>();
                config.AddProfile<ProjectProfile>();
                config.AddProfile<UserProfile>();
                config.AddProfile<ProjectParticipationHistoryProfile>();
            });
        }
    }
}