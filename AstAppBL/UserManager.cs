using AstAppDL.DataContexts;
using AstAppSharedEntities.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppBL
{
    public class UserManager
    {

        public ApplicationUser GetUser(string userId)
        {
            ApplicationUser user = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var q = (from u in ctx.Users
                         where u.Id.Equals(userId)
                         select u).FirstOrDefault();
                if (q != null)
                    user = q;
            }
            return user;
        }

    }
}
