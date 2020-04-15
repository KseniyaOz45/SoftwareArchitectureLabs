using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Work_With_Atractions : IRepository<Atraction>
    {
        private Laba5DBContext context;

        public Work_With_Atractions(Laba5DBContext context)
        {
            this.context = context;
        }

        public void Create(Atraction item)
        {
            context.AtractionEntities.Add(item);
        }

        public void Delete(int id)
        {
            Atraction atraction = context.AtractionEntities.Find(id);
            if (atraction != null)
            {
                context.AtractionEntities.Remove(atraction);
            }
        }

        public Atraction Get(int id)
        {
            return context.AtractionEntities.Find(id);
        }

        public IEnumerable<Atraction> GetAll()
        {
            return context.AtractionEntities;
        }

        public void Update(Atraction item)
        {
            Atraction dbEntry = context.AtractionEntities.Find(item.Id);

            dbEntry.Name = item.Name;
            dbEntry.Type = item.Type;
            dbEntry.Capacity = item.Capacity;
            dbEntry.Zones = item.Zones;
            //context.Entry(item).State = EntityState.Modified;
        }
    }
}
