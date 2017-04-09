using AstAppDL.DataContexts;
using AstAppSharedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppBL
{
    public class PoolManager
    {
        public List<ApplicationUser> GetUsers()
        {
            List<ApplicationUser> userList = new List<ApplicationUser>();
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                userList = ctx.Users.ToList();
            }
            return userList;
        }

        /// <summary>
        /// get the pool with userId as administrator
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Pool> GetPoolOfUser(string userId)
        {
            List<Pool> pools = new List<Pool>();
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    var user = (from u in ctx.Users
                                where u.Id == userId
                                select u).FirstOrDefault();

                    if (user != null)
                    {
                        var pool = (from p in ctx.Pools
                                     where p.PoolFounder == user && p.IsActive
                                    select p).ToList();
                        if (pool != null &&
                            pool.Any())
                            pools = pool;
                    }
                }
            }
            catch (Exception excp)
            {
                throw excp;
            }
            return pools;
        }

        /// <summary>
        /// get all available pools, except the one of the user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Pool> GetAvailablePools(string userId)
        {
            List<Pool> pools = new List<Pool>();
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    var user = (from u in ctx.Users
                                where u.Id == userId
                                select u).FirstOrDefault();

                    if (user != null)
                    {
                        var pool = (from p in ctx.Pools
                                    where p.PoolFounder != user && p.IsActive
                                    select p).ToList();
                        if (pool != null &&
                            pool.Any())
                            pools = pool;
                    }
                }
            }
            catch (Exception excp)
            {
                throw excp;
            }
            return pools;
        }

        /// <summary>
        /// get all active pools
        /// </summary>
        /// <returns></returns>
        public List<Pool> GetAllAvailablePools()
        {
            List<Pool> pools = new List<Pool>();
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {                    
                    var pool = (from p in ctx.Pools
                                where p.IsActive
                                select p).ToList();

                    if (pool != null &&
                        pool.Any())
                        pools = pool;
                    
                }
            }
            catch (Exception excp)
            {
                throw excp;
            }
            return pools;
        }
    }
}
