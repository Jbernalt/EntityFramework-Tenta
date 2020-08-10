using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class Adds
    {
        public static void AddCabin()
        {
            Console.WriteLine("Enter cabin name you want to add:");
            string cabinname = Console.ReadLine();
            using (var context = new CampContext())
            {
                var newCabin = context.Cabins.Add(new Cabin() { Name = cabinname });
                context.SaveChanges();
            }   
        }

        public static void AddCamper()
        {
            Console.WriteLine("Enter Firstname:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Lastname:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Phonenumber:");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var newCamper = new Camper
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Phonenumber = phonenumber,
                };

                var cabin = context.Cabins.Where(c => c.Campers.Count() < 3).FirstOrDefault();

                if (cabin == null)
                {
                    Console.WriteLine("All cabins are full");
                    Console.WriteLine("Press Any Key to Exit");
                    Console.ReadKey();
                }
                else if (cabin.Campers.Count() < 3)
                {
                    context.Campers.Add(newCamper);
                    cabin.Campers.Add(newCamper);
                    Console.WriteLine("{0} placed {1}", newCamper.Firstname, cabin.Name);
                    Console.ReadKey();
                    context.SaveChanges();
                }
            }
        }

        public static void AddCounsler()
        {
            Console.WriteLine("Enter Firstname:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Lastname:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Phonenumber:");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var newcounsler = new Counsler
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Phonenumber = phonenumber,
                };

                var cabin = context.Cabins.Where(c => c.Counsler == null).FirstOrDefault();
                var cab = context.Cabins.Include("Counsler").Where(c => c.Counsler == null).FirstOrDefault();
                if (cab != null)
                {
                    if (cab.Counsler == null)
                    {
                        context.Counslers.Add(newcounsler);
                        cabin.Counsler = newcounsler;
                        Console.WriteLine("{0} placed {1}", newcounsler.Firstname, cabin.Name);
                        Console.ReadKey();
                        context.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("All cabins are full");
                    Console.WriteLine("You want to add counsler wihtout a cabin?");
                    Console.WriteLine("1: Yes. 2: No");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            context.Counslers.Add(newcounsler);
                            Console.WriteLine("Press Any Key to Exit");
                            Console.ReadKey();
                            context.SaveChanges();
                            break;
                        case "2":
                            Console.WriteLine("Press Any Key to Exit");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }

        public static void AddNextOfKin()
        {
            Console.WriteLine("Enter Firstname:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Enter Lastname:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Phonenumber:");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Camper/Kid you are Next of kin for:");
            string campername = Console.ReadLine();
            using (var context = new CampContext())
            {
                var newNextOfKin = new NextOfKin
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Phonenumber = phonenumber
                };

                var newCamper = context.Campers.Where(c => c.Firstname == campername).FirstOrDefault();

                var newRelation = new Relation
                {
                    Camper = newCamper,
                    NextOfKin = newNextOfKin
                };

                context.NextOfKins.Add(newNextOfKin);
                context.Relations.Add(newRelation);
                context.SaveChanges();
            }
        }

    }
}
