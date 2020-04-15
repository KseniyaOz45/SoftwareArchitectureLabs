using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helps
{
    public class TestHelps
    {
        public IEnumerable<Order> GetAllOrders(IRepository<Order> repository)
        {
            var heroes = repository.GetAll().ToList();
            return heroes;
        }

        public Order GetOrder(IRepository<Order> repository, int Id)
        {
            Order order = repository.GetAll().Where(b => b.Id == Id).FirstOrDefault();
            return order;
        }

        public List<Order> DeleteOrder(IRepository<Order> repository, int bookId)
        {
            Order dbEntry = repository.GetAll().ToList().Find(b => b.Id == bookId);
            List<Order> orders = repository.GetAll().ToList();
            if (dbEntry != null)
            {

                orders.Remove(dbEntry);
                return orders.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Order> SaveOrder(IRepository<Order> repository, Order order)
        {
            Order changed_order = null;
            if (order.Id == 0)
            {
                var orders = repository.GetAll().ToList();
                orders.Add(order);
                //books.Add(book);
                return orders.ToList();
            }
            else
            {
                changed_order = repository.GetAll().FirstOrDefault(b => b.Id == order.Id);
                if (changed_order != null)
                {
                    changed_order.Name = order.Name;
                }
                var orders = repository.GetAll().ToList();
                return orders;
            }
        }

        //--------------------------------------------------------------------

        public IEnumerable<Zone> GetAllZones(IRepository<Zone> repository)
        {
            var zones = repository.GetAll().ToList();
            return zones;
        }

        public Zone GetZone(IRepository<Zone> repository, int Id)
        {
            Zone zone = repository.GetAll().Where(b => b.Id == Id).FirstOrDefault();
            return zone;
        }

        public List<Zone> DeleteZone(IRepository<Zone> repository, int bookId)
        {
            Zone dbEntry = repository.GetAll().ToList().Find(b => b.Id == bookId);
            List<Zone> zones = repository.GetAll().ToList();
            if (dbEntry != null)
            {
                zones.Remove(dbEntry);
                return zones.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Zone> SaveZone(IRepository<Zone> repository, Zone zone)
        {
            Zone changed_zone = null;
            if (zone.Id == 0)
            {
                var zones = repository.GetAll().ToList();
                zones.Add(zone);
                //books.Add(book);
                return zones.ToList();
            }
            else
            {
                changed_zone = repository.GetAll().FirstOrDefault(b => b.Id == zone.Id);
                if (changed_zone != null)
                {
                    changed_zone.Name = zone.Name;
                }
                var zones = repository.GetAll().ToList();
                return zones;
            }
        }

        //------------------------------------------------------------------------------

        public IEnumerable<Atraction> GetAllAtractions(IRepository<Atraction> repository)
        {
            var atractions = repository.GetAll().ToList();
            return atractions;
        }

        public Atraction GetAtraction(IRepository<Atraction> repository, int Id)
        {
            Atraction atraction = repository.GetAll().Where(b => b.Id == Id).FirstOrDefault();
            return atraction;
        }

        public List<Atraction> DeleteAtraction(IRepository<Atraction> repository, int bookId)
        {
            Atraction dbEntry = repository.GetAll().ToList().Find(b => b.Id == bookId);
            List<Atraction> atractions = repository.GetAll().ToList();
            if (dbEntry != null)
            {
                atractions.Remove(dbEntry);
                return atractions.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Atraction> SaveAtraction(IRepository<Atraction> repository, Atraction atraction)
        {
            Atraction changed_atraction = null;
            if (atraction.Id == 0)
            {
                var atractions = repository.GetAll().ToList();
                atractions.Add(atraction);
                //books.Add(book);
                return atractions.ToList();
            }
            else
            {
                changed_atraction = repository.GetAll().FirstOrDefault(b => b.Id == atraction.Id);
                if (changed_atraction != null)
                {
                    changed_atraction.Name = atraction.Name;
                }
                var atractions = repository.GetAll().ToList();
                return atractions;
            }
        }

        //-----------------------------------------------------------------------------------

        public IEnumerable<Hero> GetAllHeroes(IRepository<Hero> repository)
        {
            var heroes = repository.GetAll().ToList();
            return heroes;
        }

        public Hero GetHero(IRepository<Hero> repository, int Id)
        {
            Hero hero = repository.GetAll().Where(b => b.HeroId == Id).FirstOrDefault();
            return hero;
        }

        public List<Hero> DeleteHero(IRepository<Hero> repository, int bookId)
        {
            Hero dbEntry = repository.GetAll().ToList().Find(b => b.HeroId == bookId);
            List<Hero> heroes = repository.GetAll().ToList();
            if (dbEntry != null)
            {
                heroes.Remove(dbEntry);
                return heroes.ToList();
            }
            else
            {
                return null;
            }
        }

        public List<Hero> SaveHero(IRepository<Hero> repository, Hero hero)
        {
            Hero changed_hero = null;
            if (hero.HeroId == 0)
            {
                var heroes = repository.GetAll().ToList();
                heroes.Add(hero);
                //books.Add(book);
                return heroes.ToList();
            }
            else
            {
                changed_hero = repository.GetAll().FirstOrDefault(b => b.HeroId == hero.HeroId);
                if (changed_hero != null)
                {
                    changed_hero.Name = hero.Name;
                }
                var heroes = repository.GetAll().ToList();
                return heroes;
            }
        }

    }
}
