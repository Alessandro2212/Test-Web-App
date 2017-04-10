using AstAppSharedEntities.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AstAppDL.DataContexts
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("AstAppWebConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<PoolRoom> PoolRooms { get; set; }
        public DbSet<PoolState> PoolStates { get; set; }
        public DbSet<UserJoinPoolRoom> UserJoinPoolRooms { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
