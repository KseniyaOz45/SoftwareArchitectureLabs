using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }

        public virtual OrderPrice OrderPrice { get; set; }

        public int HeroId { get; set; }
        public Hero Hero { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }
    }
}
