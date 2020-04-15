using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Work_With_Zones : IRepository<Zone>
    {
        private Laba5DBContext context;

        public Work_With_Zones(Laba5DBContext context)
        {
            this.context = context;
        }

        public void Create(Zone item)
        {
            context.ZoneEntities.Add(item);
        }

        public void Delete(int id)
        {
            Zone zone = context.ZoneEntities.Find(id);
            if (zone != null)
            {
                context.ZoneEntities.Remove(zone);
            }
        }

        public Zone Get(int id)
        {
            return context.ZoneEntities.Find(id);
        }

        public IEnumerable<Zone> GetAll()
        {
            return context.ZoneEntities;
        }

        public void Update(Zone item)
        {
            Zone dbEntry = context.ZoneEntities.Find(item.Id);

            dbEntry.Name = item.Name;
            dbEntry.Type = item.Type;
            dbEntry.Atractions = item.Atractions;
            dbEntry.Orders = item.Orders;
            //context.Entry(item).State = EntityState.Modified;
        }
    }
}
