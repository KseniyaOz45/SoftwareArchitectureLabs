using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderPriceModel
    {
        [ForeignKey("Order")]
        public int Id { get; set; }

        public int Price { get; set; }

        public virtual Order Order { get; set; }
    }
}
