using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AstAppSharedEntities.TypeAndEnums.Enum;

namespace AstAppSharedEntities
{
    public class PoolState
    {
        [Required]
        public int Id { get; set; }
        public PoolStateEnum PoolRoomState { get; set; }
        public virtual ICollection<PoolRoom> PoolRooms { get; set; }

        public PoolState()
        {
            this.PoolRooms = new HashSet<PoolRoom>();
        }

    }
}
