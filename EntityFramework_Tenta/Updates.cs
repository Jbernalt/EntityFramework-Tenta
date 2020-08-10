using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    class Updates
    {
        public static void UpdateCabin()
        {
            Console.WriteLine("Enter in cabin name you want to change:");
            string cabinname = Console.ReadLine();
            Console.WriteLine("Enter in new cabin name:");
            string cabinname2 = Console.ReadLine();
            using (var context = new CampContext())
            {
                var cabin = context.Cabins.Where(c => c.Name == cabinname).FirstOrDefault();
                cabin.Name = cabinname2;
                context.SaveChanges();
            }
        }

        public static void UpdateCamper()
        {
            using (var context = new CampContext())
            {
                Console.WriteLine("Enter Firstname:");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter Lastname:");
                string lastname = Console.ReadLine();
                var camper = context.Campers.Where(c => c.Firstname == firstname && c.Lastname == lastname).FirstOrDefault();
                if (camper != null)
                {
                    Console.WriteLine("{0} {1} {2}", camper.Firstname, camper.Lastname, camper.Phonenumber);
                    Console.WriteLine("1. First name \n2. Last name \n3. Phone number\n4. Update cabin");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter new Firstname:");
                            string newFirstName = Console.ReadLine();
                            camper.Firstname = newFirstName;
                            context.SaveChanges();
                            break;

                        case "2":
                            Console.WriteLine("Enter new Lastname:");
                            string newLastName = Console.ReadLine();
                            camper.Lastname = newLastName;
                            context.SaveChanges();
                            break;

                        case "3":
                            Console.WriteLine("Enter new phonenumber:");
                            int newPhone = Convert.ToInt32(Console.ReadLine());
                            camper.Phonenumber = newPhone;
                            context.SaveChanges();
                            break;

                        case "4":
                            Console.WriteLine("Enter cabin name you want to change to:");
                            string newcabin = Console.ReadLine();
                            var cabin = context.Cabins.Where(c => c.Name == newcabin).FirstOrDefault();
                            if (cabin.Campers.Count() < 3)
                            {
                                camper.Cabin = cabin;
                                context.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Cabin is full");
                                Console.ReadKey();
                            }
                            break;

                        default:
                            Console.WriteLine("Wrong Input Try Again!");
                            Console.ReadKey();
                            break;
                    }
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Didnt find a camper with that ID");
                    Console.ReadKey();
                }
            }
        }

        public static void UpdateCounsler()
        {
            using (var context = new CampContext())
            {
                Console.WriteLine("Enter Firstname:");
                string firstname = Console.ReadLine();
                Console.WriteLine("Enter Lastname:");
                string lastname = Console.ReadLine();
                var counselor = context.Counslers.Where(c => c.Firstname == firstname && c.Lastname == lastname).FirstOrDefault();
                if (counselor != null)
                {
                    Console.WriteLine("{0} {1} {2}", counselor.Firstname, counselor.Lastname, counselor.Phonenumber);
                    Console.WriteLine("1. First name \n2. Last name \n3. Phone number\n4. Cabin");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter new Firstname:");
                            string newFirstName = Console.ReadLine();
                            counselor.Firstname = newFirstName;
                            context.SaveChanges();
                            break;

                        case "2":
                            Console.WriteLine("Enter new Lastname:");
                            string newLastName = Console.ReadLine();
                            counselor.Lastname = newLastName;
                            context.SaveChanges();
                            break;

                        case "3":
                            Console.WriteLine("Enter new phone-number");
                            int newphonenumber = int.Parse(Console.ReadLine());
                            counselor.Phonenumber = newphonenumber;
                            context.SaveChanges();
                            break;

                        case "4":
                            Console.WriteLine("Enter cabin name you want to change to:");
                            string newcabin = Console.ReadLine();
                            var cabin = context.Cabins.Where(pm => pm.Name == newcabin).FirstOrDefault();
                            if (cabin.Counsler == null)
                            {
                                counselor.Cabin = cabin;
                                context.SaveChanges();
                            }
                            else
                            {
                                Console.WriteLine("Cabin already have a counselor.");
                            }
                            break;
                        default:
                            Console.WriteLine("Wrong Input Try Again!");
                            Console.ReadKey();
                            break;
                    }
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Didnt find a counsler with that ID");
                    Console.ReadKey();
                }
            }
        }

        public static void UpdateNextOfKin()
        {
            using (var context = new CampContext())
            {
                Console.WriteLine("Enter ID for the Next Of Kin you want to update:");
                int nextofkinid = Convert.ToInt32(Console.ReadLine());
                var nextofkin = context.NextOfKins.Where(n => n.NextOfKinId == nextofkinid).FirstOrDefault();
                if (nextofkin != null)
                {
                    Console.WriteLine("{0} {1} {2}", nextofkin.Firstname, nextofkin.Lastname, nextofkin.Phonenumber);
                    Console.WriteLine("1. First name \n2. Last name \n3. Phone number");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter new Firstname:");
                            string newFirstName = Console.ReadLine();
                            nextofkin.Firstname = newFirstName;
                            context.SaveChanges();
                            break;

                        case "2":
                            Console.WriteLine("Enter new Lastname:");
                            string newLastName = Console.ReadLine();
                            nextofkin.Lastname = newLastName;
                            context.SaveChanges();
                            break;

                        case "3":
                            Console.WriteLine("Enter new phonenumber");
                            int newphonenumber = int.Parse(Console.ReadLine());
                            nextofkin.Phonenumber = newphonenumber;
                            context.SaveChanges();
                            break;

                        default:
                            Console.WriteLine("Wrong Input Try Again!");
                            Console.ReadKey();
                            break;
                    }
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Didnt find a Next Of Kin with that ID");
                    Console.ReadKey();
                }
            }
        }

    }
}
