using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderPrice
    {
        [ForeignKey("Order")]
        public int Id { get; set; }

        public int Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
