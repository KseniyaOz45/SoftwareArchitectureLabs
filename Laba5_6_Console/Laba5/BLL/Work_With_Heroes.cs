using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Work_With_Heroes : IRepository<Hero>
    {
        private Laba5DBContext context;

        public Work_With_Heroes(Laba5DBContext context)
        {
            this.context = context;
        }
        
        public void Create(Hero item)
        {
            context.HeroEntities.Add(item);
        }

        public void Delete(int id)
        {
            Hero hero = context.HeroEntities.Find(id);
            if(hero != null)
            {
                context.HeroEntities.Remove(hero);
            }
        }

        public Hero Get(int id)
        {
            return context.HeroEntities.Find(id);
        }

        public IEnumerable<Hero> GetAll()
        {
            return context.HeroEntities;
        }

        public void Update(Hero item)
        {
            Hero dbEntry = Get(item.HeroId);
            dbEntry.Name = item.Name;
            dbEntry.Orders = item.Orders;
            //context.Entry(item).State = EntityState.Modified;
        }
    }
}
