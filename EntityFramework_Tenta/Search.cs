using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    class Search
    {
        public static void SearchCabin()
        {
            Console.WriteLine("Search cabin:");
            string cabin = Console.ReadLine();
            using(var context = new CampContext())
            {
                var search = (from ca in context.Cabins
                              join co in context.Counslers on ca.Counsler equals co
                              where ca.Name == cabin
                              select new
                                  {
                                      Cabin = "Cabin: " + ca.Name,
                                      Counselor = "Counsler: " + co.Firstname + " " + co.Lastname + " Phonenumber: " + co.Phonenumber
                                  }).FirstOrDefault();

                var search1 = (from c in context.Campers
                               join ca in context.Cabins on c.Cabin equals ca
                               where ca.Name == cabin
                               select new { Camper = "Camper: " + c.Firstname + " " + c.Lastname + " Phonenumber: " + c.Phonenumber }
                                   ).ToList();

                var search2 = (from c in context.Cabins
                               where c.Name == cabin
                               select new { Cabin = c.Name }).FirstOrDefault();

                if (search != null)
                {
                    Console.WriteLine("{0}\n{1}", search.Cabin, search.Counselor);
                    if (search1 != null)
                    {
                        foreach (var item in search1)
                        {
                            Console.WriteLine(item.Camper);
                        }
                    }
                    Console.ReadKey();
                    return;
                }

                if (search2 != null)
                {
                    Console.WriteLine("{0}\n{1}", search2.Cabin);
                    if (search1 != null)
                    {
                        foreach (var item in search1)
                        {
                            Console.WriteLine(item.Camper);
                        }
                    }
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("No cabin with the name: {0}", cabin);
                }
            }   
        }

        public static void SearchCamper()
        {
            Console.WriteLine("Enter ID");
            int camperid = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var search = (from n in context.NextOfKins
                              join r in context.Relations on n equals r.NextOfKin
                              join c in context.Campers on r.Camper equals c
                              join ca in context.Cabins on c.Cabin equals ca
                              where c.CamperId == camperid
                              select new
                                {
                                    NextOfKin = n.Firstname + " " + n.Lastname + " Phonenumber: " + n.Phonenumber,
                                    Camper = c.Firstname + " " + c.Lastname + " Phonenumber: " + c.Phonenumber,
                                    Cabin = ca.Name
                                }).FirstOrDefault();

                var search2 = (from c in context.Campers
                               join ca in context.Cabins on c.Cabin equals ca
                               where c.CamperId == camperid
                               select new
                                    {
                                        Camper = c.Firstname + " " + c.Lastname + " Phonenumber. " + c.Phonenumber,
                                        Cabin = ca.Name
                                    }).FirstOrDefault();
                
                if (search != null)
                {
                    Console.WriteLine("Cabin: {0}\nCamper: {1}\nNext of Kin: {2}", search.Cabin, search.Camper, search.NextOfKin);
                    Console.ReadKey();
                    return;
                }
                if (search2 != null)
                {
                    Console.WriteLine("Cabin: {0}\nCamper: {1}\n No next of kin", search2.Cabin, search2.Camper);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No camper with ID: {0}", camperid);
                    Console.ReadKey();
                }
            }
        }

        public static void CampOverview()
        {
            using (var context = new CampContext())
            {
                var cabin = (from c in context.Cabins
                             select c).ToList();
                var counsler = (from c in context.Counslers
                             select c).ToList();
                var camper = (from c in context.Campers
                             select c).ToList();

                foreach (var c in cabin)
                {
                    if (c.Campers.Count == 0 && c.Counsler == null)
                    {
                        Console.WriteLine("\nCabin : {0} is empty", c.Name);
                    }
                    else
                    {
                        Console.WriteLine("\nCabin : {0}", c.Name);
                        if (c.Counsler != null)
                        {
                            Console.WriteLine("Counselor : {0} {1}", c.Counsler.Firstname, c.Counsler.Lastname);
                        }
                        foreach (var item in c.Campers)
                        {
                            Console.WriteLine("Camper : {0} {1}", item.Firstname, item.Lastname);
                        }
                    }
                }
                foreach (var c in counsler)
                {
                    if (c.Cabin == null)
                    {
                        Console.WriteLine("\nCounselor : {0} {1} is not assigned to any cabin", c.Firstname, c.Lastname);
                    }
                }
            }
        }
    }
}
