namespace ProjectsManagment.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectsManagment.Entity;
    using ProjectsManagment.Entity.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectsManagment.Data.PMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProjectsManagment.Data.PMContext";
        }

        protected override void Seed(ProjectsManagment.Data.PMContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.UserValidator = new UserValidator<User>(userManager);
            
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new Role() { Name = "Admin" });
            }


            if (!roleManager.RoleExists("Resource Manager"))
            {
                roleManager.Create(new Role() { Name = "Resource Manager" });
            }

            if (!roleManager.RoleExists("Project Manager"))
            {
                roleManager.Create(new Role() { Name = "Project Manager" });
            }

            if (!roleManager.RoleExists("Employee"))
            {
                roleManager.Create(new Role() { Name = "Employee" });
            }

            User admin = new User();
            admin.FirstName = "Admin";
            admin.LastName = "admin";
            admin.Email = "admin@admin.com";
            admin.UserName = "admin@admin.com";
            admin.EmailConfirmed = true;
            

            IdentityResult userResultAdm = userManager.Create(admin, "Password");

            if (userResultAdm.Succeeded)
            {
                var user1 = userManager.FindByName("admin@admin.com");
                userManager.AddToRole(admin.Id, "Admin");
            }

            User user = new User();
            user.FirstName = "Ivan";
            user.LastName = "Ivanov";
            user.Email = "ivan@mail.com";
            user.UserName = "ivan@mail.com";
            user.EmailConfirmed = true;
            
            IdentityResult userResult = userManager.Create(user, "Userpass");

            if (userResult.Succeeded)
            {
                var userIvan = userManager.FindByName("ivan@mail.com");
                userManager.AddToRole(userIvan.Id, "Employee");
            }
        }
    }
}
