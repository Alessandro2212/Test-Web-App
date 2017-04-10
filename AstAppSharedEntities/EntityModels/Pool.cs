using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities.EntityModels
{
    public class Pool
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ApplicationUser PoolFounder { get; set; }
       

    }
}
