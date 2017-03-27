using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities
{
    public class PoolRoom
    {
        [Required]
        public int Id { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual Pool Pool { get; set; }
        public virtual Item Item { get; set; } 

        public virtual ICollection<PoolState> PoolState { get; set; }
        public virtual ICollection<UserJoinPoolRoom> PoolRoomUsers { get; set; }

        public PoolRoom()
        {
            this.PoolState = new HashSet<PoolState>();
        }
    }
}
