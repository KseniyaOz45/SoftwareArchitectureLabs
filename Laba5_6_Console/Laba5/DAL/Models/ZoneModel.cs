using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ZoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Atraction> Atractions { get; set; }
    }
}
