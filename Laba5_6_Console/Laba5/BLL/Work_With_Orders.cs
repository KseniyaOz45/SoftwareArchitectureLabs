using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Work_With_Orders : IRepository<Order>
    {
        private Laba5DBContext context;

        public Work_With_Orders(Laba5DBContext context)
        {
            this.context = context;
        }

        public void Create(Order item)
        {
            context.OrderEntities.Add(item);
        }

        public void Delete(int id)
        {
            Order order = context.OrderEntities.Find(id);
            if (order != null)
            {
                context.OrderEntities.Remove(order);
            }
        }

        public Order Get(int id)
        {
            return context.OrderEntities.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return context.OrderEntities;
        }

        public void Update(Order item)
        {
            Order dbEntry = context.OrderEntities.Find(item.Id);

            dbEntry.Name = item.Name;
            dbEntry.Type = item.Type;
            dbEntry.Time = item.Time;
            dbEntry.Type = item.Type;
            dbEntry.HeroId = item.HeroId;
            dbEntry.OrderPrice = item.OrderPrice;
            dbEntry.Zones = item.Zones;
            //context.Entry(item).State = EntityState.Modified;
        }
    }
}
