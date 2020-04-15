using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork : IDisposable
    {
        private Laba5DBContext context;
        private Work_With_Atractions AtractionsRepository;
        private Work_With_Heroes HeroesRepository;
        private Work_With_Orders OrdersRepository;
        private Work_With_Zones ZonesRepository;

        public UnitOfWork()
        {
            context = new Laba5DBContext();
        }

        public UnitOfWork(Laba5DBContext context)
        {
            this.context = context;
        }

        public Work_With_Atractions Atractions
        {
            get {
                if(AtractionsRepository == null)
                {
                    AtractionsRepository = new Work_With_Atractions(context);
                }
                return AtractionsRepository;
            }
        }

        public Work_With_Heroes Heroes
        {
            get
            {
                if (HeroesRepository == null)
                {
                    HeroesRepository = new Work_With_Heroes(context);
                }
                return HeroesRepository;
            }
        }

        public Work_With_Orders Orders
        {
            get
            {
                if (OrdersRepository == null)
                {
                    OrdersRepository = new Work_With_Orders(context);
                }
                return OrdersRepository;
            }
        }

        public Work_With_Zones Zones
        {
            get
            {
                if (ZonesRepository == null)
                {
                    ZonesRepository = new Work_With_Zones(context);
                }
                return ZonesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = true;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
