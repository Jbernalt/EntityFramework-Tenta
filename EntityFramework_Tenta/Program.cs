using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_Tenta
{
    
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new CampContext())
            {
                var cab = (from c in context.Cabins
                           select c).FirstOrDefault();
                if (cab == null)
                {
                    SeedData.SeedCabin();
                }

                var camper = (from c in context.Campers
                              select c).FirstOrDefault();
                if (camper == null)
                {
                    SeedData.SeedCamper();
                }

                var counsler = (from c in context.Counslers
                                select c).FirstOrDefault();
                if (counsler == null)
                {
                    SeedData.SeedCounsler();
                }

                var nextofkin = (from n in context.NextOfKins
                                 select n).FirstOrDefault();
                if (nextofkin == null)
                {
                    SeedData.SeedNextOfKin();
                }
            }

            bool Exit = true;
            while (Exit)
            {
                Console.WriteLine(
                    "1: Cabin\n" +
                    "2: Camper\n" +
                    "3: Counsler\n" +
                    "4: NextOfKin\n" +
                    "-1: Exit"
                    );

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("\nEnter\n" +
                                            "1: Add Cabin\n" +
                                            "2: Update Cabin\n" +
                                            "3: Delete Cabin\n" +
                                            "4: Search Cabin");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Adds.AddCabin();
                                break;

                            case "2":
                                Updates.UpdateCabin();
                                break;

                            case "3":
                                Deletes.DeleteCabin();
                                break;

                            case "4":
                                Search.SearchCabin();
                                break;

                            default:
                                Console.WriteLine("Wrong Input Try Again!");
                                break;
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nEnter\n" +
                                            "1: Add Camper\n" +
                                            "2: Update Camper\n" +
                                            "3: Delete Camper\n" +
                                            "4: Search Camper");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Adds.AddCamper();
                                break;

                            case "2":
                                Updates.UpdateCamper();
                                break;

                            case "3":
                                Deletes.DeleteCamper();
                                break;

                            case "4":
                                Search.SearchCamper();
                                break;

                            default:
                                Console.WriteLine("Wrong Input Try Again!");
                                break;
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nEnter\n" +
                                            "1: Add Counsler\n" +
                                            "2: Update Counsler\n" +
                                            "3: Delete Counsler");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Adds.AddCounsler();
                                break;

                            case "2":
                                Updates.UpdateCounsler();
                                break;

                            case "3":
                                Deletes.DeleteCounsler();
                                break;

                            default:
                                Console.WriteLine("Wrong Input Try Again!");
                                break;
                        }
                        break;

                    case "4":
                        Console.WriteLine("\nEnter\n" +
                                            "1: Add Next Of Kin\n" +
                                            "2: Update Next Of Kin\n" +
                                            "3: Delete Next Of Kin");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Adds.AddNextOfKin();
                                break;

                            case "2":
                                Updates.UpdateNextOfKin();
                                break;

                            case "3":
                                Deletes.DeleteNextOfKin();
                                break;

                            default:
                                Console.WriteLine("Wrong Input Try Again!");
                                break;
                        }
                        break;

                    case "-1":
                        Exit = false;
                        break;

                    default:
                        Console.WriteLine("Wrong Input Try Again!");
                        break;
                }
            }
        }
    }
}
