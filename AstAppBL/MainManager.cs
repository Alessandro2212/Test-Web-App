using AstAppDL.DataContexts;
using AstAppSharedEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppBL
{
    public class MainManager
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

    }
}
