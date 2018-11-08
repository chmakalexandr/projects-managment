using AutoMapper;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectsManagment.Web.App_Start.Mappers
{
    public class ProjectParticipationHistoryProfile : Profile
    {
        public ProjectParticipationHistoryProfile()
        {
            CreateMap<ProjectParticipationHistory, ProjectParticipationHistoryViewModel>();
            CreateMap<ProjectParticipationHistoryViewModel, ProjectParticipationHistory>();
        }
    }
    
}