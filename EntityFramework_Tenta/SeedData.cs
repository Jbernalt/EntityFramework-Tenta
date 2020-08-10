using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class SeedData
    {
        public static void SeedCabin()
            {
                var cabins = new List<Cabin>
                {
                    new Cabin() {Name = "Knights"},
                    new Cabin() {Name = "Wizards"},
                    new Cabin() {Name = "Ninjas"},
                    new Cabin() {Name = "Kings"},
                    new Cabin() {Name = "Paladins"},
                    new Cabin() {Name = "Warlocks"},
                    new Cabin() {Name = "Demons"},
                    new Cabin() {Name = "Samurai"},
                    new Cabin() {Name = "Warlords"}
                };

                using (var context = new CampContext())
                {
                    foreach (var c in cabins)
                    {
                        context.Cabins.Add(c);
                    }
                    context.SaveChanges();
                }
            }

            public static void SeedCamper()
            {
                var camper = new List<Camper>
                {
                    new Camper() {Firstname = "Sylvanas", Lastname="Windrunner",Phonenumber= 123},
                    new Camper() {Firstname = "Alleria", Lastname="Windrunner",Phonenumber= 234},
                    new Camper() {Firstname = "Vereesa", Lastname="Windrunner",Phonenumber= 345},
                    new Camper() {Firstname = "Dath'Remar", Lastname="Sunstrider",Phonenumber= 456},
                    new Camper() {Firstname = "Dar'Khan", Lastname="Drathir",Phonenumber= 567},
                    new Camper() {Firstname = "Lirath", Lastname="Windrunner",Phonenumber= 678},
                    new Camper() {Firstname = "Anasterian", Lastname="Sunstrider",Phonenumber= 789},
                    new Camper() {Firstname = "Kael'thas", Lastname="Sunstrider",Phonenumber= 987},
                    new Camper() {Firstname = "Zendarian", Lastname="Windrunner",Phonenumber= 876},
                };

                using (var context = new CampContext())
                {
                    var cabin = context.Cabins.Where(c => c.Campers.Count() < 3).ToList();
                    foreach (var c in camper)
                    {
                        AddCamper(c);
                    }
                }
            }
            public static void SeedCounsler()
            {
                var counsler = new List<Counsler>
                {
                    new Counsler() { Firstname = "Illidan", Lastname = "Stormrage", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Malfurion", Lastname = "Stormrage", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Tyrande", Lastname = "Whisperwind", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Maiev", Lastname = "Shadowsong", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Lady", Lastname = "Vashj", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Shandris", Lastname = "Feathermoon", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Lord", Lastname = "Xavius", Phonenumber = 123456 },
                    new Counsler() { Firstname = "Queen", Lastname = "Azshara", Phonenumber = 123456 },
                };
                using (var context = new CampContext())
                {
                    foreach (var c in counsler)
                    {
                        AddCounselor(c);
                    }
                }
            }
            public static void SeedNextOfKin()
            {
                using (var context = new CampContext())
                {
                    var nextofkin = new List<NextOfKin>
                    {
                        new NextOfKin() { Firstname = "Anduin", Lastname = "Lothar", Phonenumber = 123 },
                        new NextOfKin() { Firstname = "Arthas", Lastname = "Menethil", Phonenumber = 123 },
                        new NextOfKin() { Firstname = "Bolvar", Lastname = "Fordragon", Phonenumber = 123 },
                        new NextOfKin() { Firstname = "Darion", Lastname = "Mograine", Phonenumber = 123 },
                        new NextOfKin() { Firstname = "Genn", Lastname = "Greymane", Phonenumber = 123 }
                    };

                    foreach (var n in nextofkin)
                    {
                        context.NextOfKins.Add(n);
                    }
                    context.SaveChanges();

                    var relations = new List<Relation>
                    {
                        new Relation() { Camper = context.Campers.Where(c => c.Firstname == "Sylvanas").FirstOrDefault(), NextOfKin = context.NextOfKins.Where(n => n.Firstname=="Anduin").FirstOrDefault() },
                        new Relation() { Camper = context.Campers.Where(c => c.Firstname == "Alleria").FirstOrDefault(), NextOfKin = context.NextOfKins.Where(n => n.Firstname=="Arthas").FirstOrDefault() },
                        new Relation() { Camper = context.Campers.Where(c => c.Firstname == "Vereesa").FirstOrDefault(), NextOfKin = context.NextOfKins.Where(n => n.Firstname=="Bolvar").FirstOrDefault() },
                        new Relation() { Camper = context.Campers.Where(c => c.Firstname == "Lirath").FirstOrDefault(), NextOfKin = context.NextOfKins.Where(n => n.Firstname=="Darion").FirstOrDefault() },
                        new Relation() { Camper = context.Campers.Where(c => c.Firstname == "Zendarian").FirstOrDefault(), NextOfKin = context.NextOfKins.Where(n => n.Firstname=="Genn").FirstOrDefault() },
                    };
                    foreach (var relation in relations)
                    {
                        context.Relations.Add(relation);
                    }
                    context.SaveChanges();
                }
            }

            public static void AddCamper(Camper camper)
            {
                using (var context = new CampContext())
                {
                    var cabin = context.Cabins.Where(c => c.Campers.Count() < 3).FirstOrDefault();
                    if (cabin.Campers.Count() < 3)
                    {
                        context.Campers.Add(camper);
                        cabin.Campers.Add(camper);
                        context.SaveChanges();
                    }
                }
            }
            public static void AddCounselor(Counsler counselor)
            {
                using (var context = new CampContext())
                {
                    var cabin = context.Cabins.Where(c => c.Counsler == null).FirstOrDefault();
                    var cabins = context.Cabins.Include("Counsler").Where(c => c.Counsler == null).FirstOrDefault();
                    if (cabins != null)
                    {
                        if (cabins.Counsler == null)
                        {
                            context.Counslers.Add(counselor);
                            cabin.Counsler = counselor;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Counslers.Add(counselor);
                            context.SaveChanges();
                        }
                    }
                }
            }
    }
}
