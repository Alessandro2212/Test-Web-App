using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities.EntityModels
{
    public class Offer
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime TmpInsert { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Item Item { get; set; }
    }
}
