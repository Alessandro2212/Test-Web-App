using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstAppSharedEntities
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public double StartingPrice { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual Pool Pool { get; set; }
    }
}
