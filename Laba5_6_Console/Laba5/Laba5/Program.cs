using AutoMapper;
using BLL;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            Order order;
            Atraction atraction;
            Zone zone;
            Hero hero;

            OrderModel orderModel;
            AtractionModel atractionModel;
            ZoneModel zoneModel;
            HeroModel heroModel;

            int choise = 0;
            string menu_name = "Menu.txt";
            string filename = Path.Combine(Environment.CurrentDirectory, menu_name);
            string[] readText = File.ReadAllLines(filename);
            
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Orders");
                Console.WriteLine("2. Zones");
                Console.WriteLine("3. Atractions");
                Console.WriteLine("4. Heroes");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.WriteLine("Your choise: ");

                choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1://Orders
                        string Order_Name, Order_type;
                        int Order_time, order_zones_count, order_zone_id, order_hero_id,Order_Id;
                        OrderPrice order_price = new OrderPrice();
                        Hero order_hero;
                        List<Zone> order_zones = new List<Zone>();
                        List<Order> all_orders = unitOfWork.Orders.GetAll().ToList();

                        var config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
                        var mapper = new Mapper(config);

                        foreach (string s in readText)
                        {
                            Console.WriteLine(s);
                        }
                        choise = int.Parse(Console.ReadLine());

                        if (choise == 1)
                        {
                            orderModel = new OrderModel();

                            Console.WriteLine("Name: ");
                            Order_Name = Console.ReadLine();
                            Console.WriteLine("Type: ");
                            Order_type = Console.ReadLine();
                            Console.WriteLine("Time: ");
                            Order_time = int.Parse(Console.ReadLine());
                            Console.WriteLine("Price: ");
                            order_price.Id = orderModel.Id;
                            order_price.Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Hero ID: ");
                            order_hero_id = int.Parse(Console.ReadLine());
                            order_hero = unitOfWork.Heroes.Get(order_hero_id);
                            Console.WriteLine("Zones count: ");
                            order_zones_count = int.Parse(Console.ReadLine());

                            for (int i=0;i< order_zones_count;i++)
                            {
                                Console.WriteLine("Zone Id: ");
                                order_zone_id = int.Parse(Console.ReadLine());
                                order_zones.Add(unitOfWork.Zones.Get(order_zone_id));
                            }

                            orderModel.Name = Order_Name;
                            orderModel.Type = Order_type;
                            orderModel.Time = Order_time;
                            orderModel.OrderPrice = order_price;
                            orderModel.HeroId = orderModel.HeroId;
                            orderModel.Hero = order_hero;
                            orderModel.Zones = order_zones;

                            order = mapper.Map<Order>(orderModel);

                            unitOfWork.Orders.Create(order);
                            unitOfWork.Save();
                        }
                        else if (choise == 2)
                        {
                            config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
                            mapper = new Mapper(config);

                            Console.WriteLine("Id: ");
                            Order_Id = int.Parse(Console.ReadLine());
                            order = unitOfWork.Orders.Get(Order_Id);
                            var map_order = mapper.Map<OrderModel>(order);
                            Console.WriteLine("Name: ");
                            Order_Name = Console.ReadLine();
                            Console.WriteLine("Type: ");
                            Order_type = Console.ReadLine();
                            Console.WriteLine("Time: ");
                            Order_time = int.Parse(Console.ReadLine());
                            Console.WriteLine("Price: ");
                            order_price.Id = order.Id;
                            order_price.Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Hero ID: ");
                            order_hero_id = int.Parse(Console.ReadLine());
                            order_hero = unitOfWork.Heroes.Get(order_hero_id);
                            Console.WriteLine("Zones count: ");
                            order_zones_count = int.Parse(Console.ReadLine());

                            for (int i = 0; i < order_zones_count; i++)
                            {
                                Console.WriteLine("Zone Id: ");
                                order_zone_id = int.Parse(Console.ReadLine());
                                order_zones.Add(unitOfWork.Zones.Get(order_zone_id));
                            }

                            map_order.Name = Order_Name;
                            map_order.Type = Order_type;
                            map_order.Time = Order_time;
                            map_order.OrderPrice = order_price;
                            map_order.HeroId = order.HeroId;
                            map_order.Hero = order_hero;
                            map_order.Zones = order_zones;

                            config = new MapperConfiguration(cfg => cfg.CreateMap<OrderModel, Order>());
                            mapper = new Mapper(config);

                            order = mapper.Map<Order>(map_order);

                            unitOfWork.Orders.Update(order);
                            unitOfWork.Save();
                        }
                        else if (choise == 3)
                        {
                            Console.WriteLine("Id: ");
                            Order_Id = int.Parse(Console.ReadLine());

                            unitOfWork.Orders.Delete(Order_Id);
                            unitOfWork.Save();
                        }
                        else if (choise == 4)
                        {
                            config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderModel>());
                            mapper = new Mapper(config);

                            all_orders= unitOfWork.Orders.GetAll().ToList();
                            var map_orders = mapper.Map<List<OrderModel>>(all_orders);

                            foreach (var o in map_orders)
                            {
                                o.Hero = unitOfWork.Heroes.Get(o.HeroId);

                                Console.WriteLine("-------------------------------");
                                Console.WriteLine("Id: "+o.Id);
                                Console.WriteLine("Name: "+o.Name);
                                Console.WriteLine("Type: "+o.Type);
                                Console.WriteLine("Time: "+o.Time);
                                Console.WriteLine("Hero: "+o.Hero.Name);
                                foreach(var z in o.Zones)
                                {
                                    Console.WriteLine("Zone: "+z.Name);
                                }
                                Console.WriteLine("Price: "+o.OrderPrice.Price);
                            }

                        }

                        break;
                    case 2://Zones
                        string ZoneName, ZoneType;
                        int ZoneId, zone_atractions_count, zone_atraction_id, zone_orders_count, zone_order_id;
                        List<Order> Zone_orders = new List<Order>();
                        List<Atraction> Zone_atractions = new List<Atraction>();
                        List<Zone> all_zones = unitOfWork.Zones.GetAll().ToList();

                        var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ZoneModel, Zone>());
                        var mapper2 = new Mapper(config2);

                        foreach (string s in readText)
                        {
                            Console.WriteLine(s);
                        }
                        choise = int.Parse(Console.ReadLine());

                        if (choise == 1)
                        {
                            zoneModel = new ZoneModel();

                            Console.WriteLine("Name: ");
                            ZoneName = Console.ReadLine();
                            Console.WriteLine("Type: ");
                            ZoneType = Console.ReadLine();
                            Console.WriteLine("Atractions count: ");
                            zone_atractions_count = int.Parse(Console.ReadLine());

                            for(int i=0;i< zone_atractions_count; i++)
                            {
                                Console.WriteLine("Atraction Id: ");
                                zone_atraction_id = int.Parse(Console.ReadLine());
                                Zone_atractions.Add(unitOfWork.Atractions.Get(zone_atraction_id));
                            }

                            zoneModel.Name = ZoneName;
                            zoneModel.Type = ZoneType;
                            zoneModel.Atractions = Zone_atractions;

                            zone = mapper2.Map<Zone>(zoneModel);

                            unitOfWork.Zones.Create(zone);
                            unitOfWork.Save();
                        }
                        else if (choise == 2)
                        {
                            Console.WriteLine("Id: ");
                            ZoneId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Name: ");
                            ZoneName = Console.ReadLine();
                            Console.WriteLine("Type: ");
                            ZoneType = Console.ReadLine();
                            Console.WriteLine("Atractions count: ");
                            zone_atractions_count = int.Parse(Console.ReadLine());

                            for (int i = 0; i < zone_atractions_count; i++)
                            {
                                Console.WriteLine("Atraction Id: ");
                                zone_atraction_id = int.Parse(Console.ReadLine());
                                Zone_atractions.Add(unitOfWork.Atractions.Get(zone_atraction_id));
                            }

                            Console.WriteLine("Orders count: ");
                            zone_orders_count = int.Parse(Console.ReadLine());

                            for (int i = 0; i < zone_orders_count; i++)
                            {
                                Console.WriteLine("Order Id: ");
                                zone_order_id = int.Parse(Console.ReadLine());
                                Zone_orders.Add(unitOfWork.Orders.Get(zone_order_id));
                            }

                            config2 = new MapperConfiguration(cfg => cfg.CreateMap<Zone, ZoneModel>());
                            mapper2 = new Mapper(config2);
                            zone = unitOfWork.Zones.Get(ZoneId);
                            var map_zone = mapper2.Map<ZoneModel>(zone);

                            map_zone.Name = ZoneName;
                            map_zone.Type = ZoneType;
                            map_zone.Atractions = Zone_atractions;
                            map_zone.Orders = Zone_orders;

                            config2 = new MapperConfiguration(cfg => cfg.CreateMap<ZoneModel, Zone>());
                            mapper2 = new Mapper(config2);
                            zone = mapper2.Map<Zone>(map_zone);

                            unitOfWork.Zones.Update(zone);
                            unitOfWork.Save();
                        }
                        else if (choise == 3)
                        {
                            Console.WriteLine("Id: ");
                            ZoneId = int.Parse(Console.ReadLine());

                            unitOfWork.Zones.Delete(ZoneId);
                            unitOfWork.Save();
                        }
                        else if (choise == 4)
                        {
                            config2 = new MapperConfiguration(cfg => cfg.CreateMap<Zone, ZoneModel>());
                            mapper2 = new Mapper(config2);

                            all_zones = unitOfWork.Zones.GetAll().ToList();
                            var map_zones = mapper2.Map<List<ZoneModel>>(all_zones);

                            foreach (var z in map_zones)
                            {
                                Console.WriteLine("-------------------------------");
                                Console.WriteLine("Id: "+ z.Id);
                                Console.WriteLine("Name: "+z.Name);
                                Console.WriteLine("Type: "+z.Type);
                                foreach(var a in z.Atractions)
                                {
                                    Console.WriteLine("Atraction: "+a.Name);
                                }
                            }
                        }

                        break;
                    case 3://Atractions
                        string AtractionName, AtractionType;
                        int Capacity, zones_count,zone_id,atraction_id;
                        List<Zone> zones = new List<Zone>();
                        List<Atraction> all_atractions = unitOfWork.Atractions.GetAll().ToList();

                        var config3 = new MapperConfiguration(cfg => cfg.CreateMap<AtractionModel, Atraction>());
                        var mapper3 = new Mapper(config3);

                        foreach (string s in readText)
                        {
                            Console.WriteLine(s);
                        }
                        choise = int.Parse(Console.ReadLine());

                        if (choise == 1)
                        {
                            atractionModel = new AtractionModel();

                            Console.WriteLine("Name: ");
                            AtractionName = Console.ReadLine();
                            Console.WriteLine("Atraction Type: ");
                            AtractionType = Console.ReadLine();
                            Console.WriteLine("Capacity: ");
                            Capacity = int.Parse(Console.ReadLine());

                            atractionModel.Name = AtractionName;
                            atractionModel.Type = AtractionType;
                            atractionModel.Capacity = Capacity;

                            atraction = mapper3.Map<Atraction>(atractionModel);

                            unitOfWork.Atractions.Create(atraction);
                            unitOfWork.Save();
                        }
                        else if (choise == 2)
                        {
                            Console.WriteLine("Enter id: ");
                            atraction_id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Name: ");
                            AtractionName = Console.ReadLine();
                            Console.WriteLine("Atraction Type: ");
                            AtractionType = Console.ReadLine();
                            Console.WriteLine("Capacity: ");
                            Capacity = int.Parse(Console.ReadLine());
                            Console.WriteLine("Zones count: ");
                            zones_count = int.Parse(Console.ReadLine());
                            for (int i=0;i< zones_count;i++)
                            {
                                Console.WriteLine("Enter zone id: ");
                                zone_id = int.Parse(Console.ReadLine());
                                zones.Add(unitOfWork.Zones.Get(zone_id));
                            }

                            atraction = unitOfWork.Atractions.Get(atraction_id);
                            config3 = new MapperConfiguration(cfg => cfg.CreateMap<Atraction, AtractionModel>());
                            mapper3 = new Mapper(config3);
                            atractionModel = mapper3.Map<AtractionModel>(atraction);


                            atractionModel.Name = AtractionName;
                            atractionModel.Type = AtractionType;
                            atractionModel.Capacity = Capacity;
                            atractionModel.Zones = zones;

                            config3 = new MapperConfiguration(cfg => cfg.CreateMap<AtractionModel, Atraction>());
                            mapper3 = new Mapper(config3);
                            atraction = mapper3.Map<Atraction>(atractionModel);

                            unitOfWork.Atractions.Update(atraction);
                            unitOfWork.Save();

                        }
                        else if (choise == 3)
                        {
                            Console.WriteLine("Enter id: ");
                            atraction_id = int.Parse(Console.ReadLine());

                            unitOfWork.Atractions.Delete(atraction_id);
                            unitOfWork.Save();
                        }
                        else if (choise == 4)
                        {
                            config3 = new MapperConfiguration(cfg => cfg.CreateMap<Atraction, AtractionModel>());
                            mapper3 = new Mapper(config3);

                            all_atractions = unitOfWork.Atractions.GetAll().ToList();
                            var map_atractions = mapper3.Map<List<AtractionModel>>(all_atractions);

                            foreach (var a in map_atractions)
                            {
                                Console.WriteLine("-------------------------------");
                                Console.WriteLine("Id: "+a.Id);
                                Console.WriteLine("Name: " + a.Name);
                                Console.WriteLine("Type: " + a.Type);
                                Console.WriteLine("Capacity: " + a.Capacity);
                                foreach (var z in a.Zones)
                                {
                                    Console.WriteLine("Zone: "+z.Name);
                                }
                            }
                        }

                        break;
                    case 4: //Heroes
                        string HeroName;
                        int heroId;
                        int orders_count;
                        int order_id;
                        List<Order> hero_orders = new List<Order>();
                        List<Hero> heroes;
                        var config4 = new MapperConfiguration(cfg => cfg.CreateMap<HeroModel, Hero>());
                        var mapper4 = new Mapper(config4);

                        foreach (string s in readText)
                        {
                            Console.WriteLine(s);
                        }
                        choise = int.Parse(Console.ReadLine());

                        if (choise == 1)
                        {
                            //hero = new Hero();
                            heroModel = new HeroModel();

                            Console.WriteLine("Name: ");
                            HeroName = Console.ReadLine();

                            heroModel.Name = HeroName;

                            hero = mapper4.Map<Hero>(heroModel);

                            unitOfWork.Heroes.Create(hero);
                            unitOfWork.Save();

                        }
                        else if (choise == 2)
                        {
                            Console.WriteLine("Enter id: ");
                            heroId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Name: ");
                            HeroName = Console.ReadLine();
                            Console.WriteLine("Enter orders count: ");
                            orders_count = int.Parse(Console.ReadLine());
                            for (int i=0;i<orders_count;i++)
                            {
                                Console.WriteLine("Enter order id: ");
                                order_id = int.Parse(Console.ReadLine());
                                hero_orders.Add(unitOfWork.Orders.Get(order_id));
                            }

                            hero = unitOfWork.Heroes.Get(heroId);

                            config4 = new MapperConfiguration(cfg => cfg.CreateMap<Hero, HeroModel>());
                            mapper4 = new Mapper(config4);

                            var map_hero = mapper4.Map<HeroModel>(hero);

                            map_hero.Name = HeroName;
                            map_hero.Orders = hero_orders;

                            config4 = new MapperConfiguration(cfg => cfg.CreateMap<HeroModel, Hero>());
                            mapper4 = new Mapper(config4);

                            hero = mapper4.Map<Hero>(map_hero);

                            unitOfWork.Heroes.Update(hero);
                            unitOfWork.Save();
                        }
                        else if (choise == 3)
                        {
                            Console.WriteLine("Enter id: ");
                            heroId = int.Parse(Console.ReadLine());

                            unitOfWork.Heroes.Delete(heroId);
                            unitOfWork.Save();
                        }
                        else if (choise == 4)
                        {
                            config4 = new MapperConfiguration(cfg => cfg.CreateMap<Hero, HeroModel>());
                            mapper4 = new Mapper(config4);

                            heroes = unitOfWork.Heroes.GetAll().ToList();
                            var map_heroes = mapper4.Map<List<HeroModel>>(unitOfWork.Heroes.GetAll().ToList());
                            foreach (var h in map_heroes)
                            {
                                Console.WriteLine("-------------------------------");
                                Console.WriteLine("Id: "+h.HeroId);
                                Console.WriteLine("Name: "+h.Name);
                                foreach (var o in h.Orders)
                                {
                                    Console.WriteLine("Order: "+ o.Name);
                                }
                            }
                        }

                        break;
                }

            } while (choise != 5);
        }
    }
}
