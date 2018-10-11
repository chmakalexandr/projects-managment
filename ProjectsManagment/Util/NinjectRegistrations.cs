using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Ninject.Modules;

namespace ProjectsManagment.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IScheduleRepository>().To<ScheduleRepository>();
            Bind<IProjectRoleRepository>().To<ProjectRoleRepository>();
            Bind<IParticipationTypeRepository>().To<ParticipationTypeRepository>();
        }
    }
}