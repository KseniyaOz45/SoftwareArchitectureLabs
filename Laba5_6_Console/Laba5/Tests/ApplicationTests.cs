using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL;
using BLL.Helps;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void Can_Get_All_Orders()
        {
            Mock<IRepository<Order>> mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Order> {
                new Order { Id = 1, Name = "Order1"},
                new Order { Id = 2, Name = "Order2"},
                new Order { Id = 3, Name = "Order3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var orders = repository.GetAllOrders(mock.Object).ToList();

            Assert.AreEqual(3, orders.Count);
        }

        [TestMethod]
        public void Can_Get_Book()
        {
            int id = 2;

            Mock<IRepository<Order>> mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Order> {
                new Order { Id = 1, Name = "Order1"},
                new Order { Id = 2, Name = "Order2"},
                new Order { Id = 3, Name = "Order3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var order = repository.GetOrder(mock.Object, id);

            Assert.AreEqual(id, order.Id);
            Assert.AreEqual("Order2", order.Name);
        }

        [TestMethod]
        public void Can_Add_Book()
        {
            Order order = new Order { Id = 0, Name = "Order4" };

            //var myBooks = new List<Book>()
            //{
            //    new Book { Id = 1, Name = "Book1"},
            //    new Book { Id = 2, Name = "Book2"},
            //    new Book { Id = 3, Name = "Book3"}
            //};

            //var dbContext = new Mock<BookDBContext>();
            //var dbSet = new Mock<DbSet<Book>>();

            //dbContext.Setup(b => b.Books).Returns(() => dbSet.Object);
            //var queryable = myBooks.AsQueryable();
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(queryable.Provider);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(queryable.Expression);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //var repo = new BookRepository(dbContext.Object);
            //var results = repo.Save(book);
            //Assert.AreEqual(4,results.Count());

            Mock<IRepository<Order>> mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Order> {
                new Order { Id = 1, Name = "Order1"},
                new Order { Id = 2, Name = "Order2"},
                new Order { Id = 3, Name = "Order3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Order> orders = repository.SaveOrder(mock.Object, order);

            Assert.AreEqual(4, orders.Count);
            Assert.AreEqual("Order4", orders.Find(b => b.Id == order.Id).Name);
        }

        [TestMethod]
        public void Can_Change_Book()
        {
            Order order = new Order { Id = 3, Name = "Order3_New" };

            Mock<IRepository<Order>> mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Order> {
                new Order { Id = 1, Name = "Order1"},
                new Order { Id = 2, Name = "Order2"},
                new Order { Id = 3, Name = "Order3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Order> orders = repository.SaveOrder(mock.Object, order);

            Assert.AreEqual(3, orders.Count);
            Assert.AreEqual("Order3_New", orders.Find(b => b.Id == 3).Name);
        }

        [TestMethod]
        public void Can_Delete_Book()
        {
            int id = 3;

            Mock<IRepository<Order>> mock = new Mock<IRepository<Order>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Order> {
                new Order { Id = 1, Name = "Order1"},
                new Order { Id = 2, Name = "Order2"},
                new Order { Id = 3, Name = "Order3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Order> orders = repository.DeleteOrder(mock.Object, id);

            Assert.AreEqual(2, orders.Count);
        }

        [TestMethod]
        public void Can_Get_All_Zones()
        {
            Mock<IRepository<Zone>> mock = new Mock<IRepository<Zone>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Zone> {
                new Zone { Id = 1, Name = "Zone1"},
                new Zone { Id = 2, Name = "Zone2"},
                new Zone { Id = 3, Name = "Zone3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var zones = repository.GetAllZones(mock.Object).ToList();

            Assert.AreEqual(3, zones.Count);
        }

        [TestMethod]
        public void Can_Get_Zone()
        {
            int id = 2;

            Mock<IRepository<Zone>> mock = new Mock<IRepository<Zone>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Zone> {
                new Zone { Id = 1, Name = "Zone1"},
                new Zone { Id = 2, Name = "Zone2"},
                new Zone { Id = 3, Name = "Zone3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var zone = repository.GetZone(mock.Object, id);

            Assert.AreEqual(id, zone.Id);
            Assert.AreEqual("Zone2", zone.Name);
        }

        [TestMethod]
        public void Can_Add_Zone()
        {
            Zone zone = new Zone { Id = 0, Name = "Order4" };

            //var myBooks = new List<Book>()
            //{
            //    new Book { Id = 1, Name = "Book1"},
            //    new Book { Id = 2, Name = "Book2"},
            //    new Book { Id = 3, Name = "Book3"}
            //};

            //var dbContext = new Mock<BookDBContext>();
            //var dbSet = new Mock<DbSet<Book>>();

            //dbContext.Setup(b => b.Books).Returns(() => dbSet.Object);
            //var queryable = myBooks.AsQueryable();
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(queryable.Provider);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(queryable.Expression);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //var repo = new BookRepository(dbContext.Object);
            //var results = repo.Save(book);
            //Assert.AreEqual(4,results.Count());

            Mock<IRepository<Zone>> mock = new Mock<IRepository<Zone>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Zone> {
                new Zone { Id = 1, Name = "Zone1"},
                new Zone { Id = 2, Name = "Zone2"},
                new Zone { Id = 3, Name = "Zone3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Zone> zones = repository.SaveZone(mock.Object,zone);

            Assert.AreEqual(4, zones.Count);
            Assert.AreEqual("Order4", zones.Find(b => b.Id == zone.Id).Name);
        }

        [TestMethod]
        public void Can_Change_Zone()
        {
            Zone zone = new Zone { Id = 3, Name = "Zone3_New" };

            Mock<IRepository<Zone>> mock = new Mock<IRepository<Zone>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Zone> {
                new Zone { Id = 1, Name = "Zone1"},
                new Zone { Id = 2, Name = "Zone2"},
                new Zone { Id = 3, Name = "Zone3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Zone> zones = repository.SaveZone(mock.Object, zone);

            Assert.AreEqual(3, zones.Count);
            Assert.AreEqual("Zone3_New", zones.Find(b => b.Id == 3).Name);
        }

        [TestMethod]
        public void Can_Delete_Zone()
        {
            int id = 3;

            Mock<IRepository<Zone>> mock = new Mock<IRepository<Zone>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Zone> {
                new Zone { Id = 1, Name = "Zone1"},
                new Zone { Id = 2, Name = "Zone2"},
                new Zone { Id = 3, Name = "Zone3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Zone> zones = repository.DeleteZone(mock.Object, id);

            Assert.AreEqual(2, zones.Count);
        }

        [TestMethod]
        public void Can_Get_All_Atractions()
        {
            Mock<IRepository<Atraction>> mock = new Mock<IRepository<Atraction>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Atraction> {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var atractions = repository.GetAllAtractions(mock.Object).ToList();

            Assert.AreEqual(3, atractions.Count);
        }

        [TestMethod]
        public void Can_Get_Atraction()
        {
            int id = 2;

            Mock<IRepository<Atraction>> mock = new Mock<IRepository<Atraction>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Atraction> {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var atraction = repository.GetAtraction(mock.Object, id);

            Assert.AreEqual(id, atraction.Id);
            Assert.AreEqual("Atraction2", atraction.Name);
        }

        [TestMethod]
        public void Can_Add_Atraction()
        {
            Atraction atraction = new Atraction { Id = 0, Name = "Atraction4" };

            //var myBooks = new List<Book>()
            //{
            //    new Book { Id = 1, Name = "Book1"},
            //    new Book { Id = 2, Name = "Book2"},
            //    new Book { Id = 3, Name = "Book3"}
            //};

            //var dbContext = new Mock<BookDBContext>();
            //var dbSet = new Mock<DbSet<Book>>();

            //dbContext.Setup(b => b.Books).Returns(() => dbSet.Object);
            //var queryable = myBooks.AsQueryable();
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(queryable.Provider);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(queryable.Expression);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //var repo = new BookRepository(dbContext.Object);
            //var results = repo.Save(book);
            //Assert.AreEqual(4,results.Count());

            Mock<IRepository<Atraction>> mock = new Mock<IRepository<Atraction>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Atraction> {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Atraction> atractions = repository.SaveAtraction(mock.Object, atraction);

            Assert.AreEqual(4, atractions.Count);
            Assert.AreEqual("Atraction4", atractions.Find(b => b.Id == atraction.Id).Name);
        }

        [TestMethod]
        public void Can_Change_Atraction()
        {
            Atraction atraction = new Atraction { Id = 3, Name = "Atraction3_New" };

            Mock<IRepository<Atraction>> mock = new Mock<IRepository<Atraction>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Atraction> {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Atraction> atractions = repository.SaveAtraction(mock.Object, atraction);

            Assert.AreEqual(3, atractions.Count);
            Assert.AreEqual("Atraction3_New", atractions.Find(b => b.Id == 3).Name);
        }

        [TestMethod]
        public void Can_Delete_Atraction()
        {
            int id = 3;

            Mock<IRepository<Atraction>> mock = new Mock<IRepository<Atraction>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Atraction> {
                new Atraction { Id = 1, Name = "Atraction1"},
                new Atraction { Id = 2, Name = "Atraction2"},
                new Atraction { Id = 3, Name = "Atraction3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Atraction> atractions = repository.DeleteAtraction(mock.Object, id);

            Assert.AreEqual(2, atractions.Count);
        }

        [TestMethod]
        public void Can_Get_All_Heroes()
        {
            Mock<IRepository<Hero>> mock = new Mock<IRepository<Hero>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Hero> {
                new Hero { HeroId = 1, Name = "Hero1"},
                new Hero { HeroId = 2, Name = "Hero2"},
                new Hero { HeroId = 3, Name = "Hero3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var heroes = repository.GetAllHeroes(mock.Object).ToList();

            Assert.AreEqual(3, heroes.Count);
        }

        [TestMethod]
        public void Can_Get_Hero()
        {
            int id = 2;

            Mock<IRepository<Hero>> mock = new Mock<IRepository<Hero>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Hero> {
                new Hero { HeroId = 1, Name = "Hero1"},
                new Hero { HeroId = 2, Name = "Hero2"},
                new Hero { HeroId = 3, Name = "Hero3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            var atraction = repository.GetHero(mock.Object, id);

            Assert.AreEqual(id, atraction.HeroId);
            Assert.AreEqual("Hero2", atraction.Name);
        }

        [TestMethod]
        public void Can_Add_Hero()
        {
            Hero hero = new Hero { HeroId = 0, Name = "Hero4" };

            //var myBooks = new List<Book>()
            //{
            //    new Book { Id = 1, Name = "Book1"},
            //    new Book { Id = 2, Name = "Book2"},
            //    new Book { Id = 3, Name = "Book3"}
            //};

            //var dbContext = new Mock<BookDBContext>();
            //var dbSet = new Mock<DbSet<Book>>();

            //dbContext.Setup(b => b.Books).Returns(() => dbSet.Object);
            //var queryable = myBooks.AsQueryable();
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(queryable.Provider);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(queryable.Expression);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            //dbSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //var repo = new BookRepository(dbContext.Object);
            //var results = repo.Save(book);
            //Assert.AreEqual(4,results.Count());

            Mock<IRepository<Hero>> mock = new Mock<IRepository<Hero>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Hero> {
                new Hero { HeroId = 1, Name = "Hero1"},
                new Hero { HeroId = 2, Name = "Hero2"},
                new Hero { HeroId = 3, Name = "Hero3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Hero> heroes = repository.SaveHero(mock.Object, hero);

            Assert.AreEqual(4, heroes.Count);
            Assert.AreEqual("Hero4", heroes.Find(b => b.HeroId == hero.HeroId).Name);
        }

        [TestMethod]
        public void Can_Change_Hero()
        {
            Hero hero = new Hero { HeroId = 3, Name = "Hero3_New" };

            Mock<IRepository<Hero>> mock = new Mock<IRepository<Hero>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Hero> {
                new Hero { HeroId = 1, Name = "Hero1"},
                new Hero { HeroId = 2, Name = "Hero2"},
                new Hero { HeroId = 3, Name = "Hero3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Hero> heroes = repository.SaveHero(mock.Object, hero);

            Assert.AreEqual(3, heroes.Count);
            Assert.AreEqual("Hero3_New", heroes.Find(b => b.HeroId == 3).Name);
        }

        [TestMethod]
        public void Can_Delete_Hero()
        {
            int id = 3;

            Mock<IRepository<Hero>> mock = new Mock<IRepository<Hero>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Hero> {
                new Hero { HeroId = 1, Name = "Hero1"},
                new Hero { HeroId = 2, Name = "Hero2"},
                new Hero { HeroId = 3, Name = "Hero3"},
            });

            //BookRepository repository = new BookRepository();
            TestHelps repository = new TestHelps();

            List<Hero> heroes = repository.DeleteHero(mock.Object, id);

            Assert.AreEqual(2, heroes.Count);
        }
    }
}
