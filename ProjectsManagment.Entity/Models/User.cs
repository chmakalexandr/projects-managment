using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectsManagment.Entity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectsManagment.Entity 
{
    public class User : IdentityUser
    {

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }


        [MaxLength(100)]
        public string LastName { get; set; }

        
        public ICollection<ProjectParticipationHistory> ProjectParticipationHistories { get; set; }

        public User()
        {
            ProjectParticipationHistories = new List<ProjectParticipationHistory>();
            
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> userManager, string authenticationType)
        {
            var userIdentity = await userManager.CreateIdentityAsync(this, authenticationType);
            userIdentity.AddClaim(new Claim(ClaimTypes.Email, this.Email));
            userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, this.FirstName));
            userIdentity.AddClaim(new Claim(ClaimTypes.Surname, this.LastName));

            return userIdentity;
        }
    }
}
