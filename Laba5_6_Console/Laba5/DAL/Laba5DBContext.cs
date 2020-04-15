namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Laba5DBContext : DbContext
    {
        // Контекст настроен для использования строки подключения "Laba5DBContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "DAL.Laba5DBContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Laba5DBContext" 
        // в файле конфигурации приложения.
        public Laba5DBContext()
            : base("name=Laba5DBContext")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Order> OrderEntities { get; set; }
        public virtual DbSet<Zone> ZoneEntities { get; set; }
        public virtual DbSet<Atraction> AtractionEntities { get; set; }
        public virtual DbSet<Hero> HeroEntities { get; set; }
        public virtual DbSet<OrderPrice> OrderPrices { get; set; }

        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}