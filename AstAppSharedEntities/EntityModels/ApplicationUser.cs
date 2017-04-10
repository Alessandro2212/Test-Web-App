using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            PoolsFounded = new List<Pool>();
        }

        public bool IsFounder { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<UserJoinPoolRoom> UserPoolRooms { get; set; }
        public virtual ICollection<Pool> PoolsFounded { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
