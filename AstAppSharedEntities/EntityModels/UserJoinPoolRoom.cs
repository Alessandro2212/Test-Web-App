using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AstAppSharedEntities.TypeAndEnums.Enum;

namespace AstAppSharedEntities.EntityModels
{
    public class UserJoinPoolRoom
    {
        [Required]
        public int Id { get; set; }
        public UserStateEnum UserState { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual PoolRoom PoolRoom { get; set; }

    }
}
