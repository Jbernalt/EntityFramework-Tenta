using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    class Deletes
    {

        public static void DeleteCabin()
        {
            Console.WriteLine("Enter cabin name:");
            string cabinname = Console.ReadLine();
            using (var context = new CampContext())
            {
                var deletecabin = context.Cabins.Where(c => c.Name == cabinname).FirstOrDefault();
                context.Cabins.Remove(deletecabin);
                context.SaveChanges();
            }
        }

        public static void DeleteCamper()
        {
            Console.WriteLine("Enter Camper ID:");
            int camperid = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var deletecamper = context.Campers.Where(c => c.CamperId == camperid).FirstOrDefault();
                context.Campers.Remove(deletecamper);
                context.SaveChanges();
            }
        }

        public static void DeleteCounsler()
        {
            Console.WriteLine("Enter Counsler ID:");
            int counslerid = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var deletecounsler = context.Counslers.Where(c => c.CounslerId == counslerid).FirstOrDefault();
                context.Counslers.Remove(deletecounsler);
                context.SaveChanges();
            }
        }

        public static void DeleteNextOfKin()
        {
            Console.WriteLine("Enter Next Of Kin ID:");
            int nextofkinid = Convert.ToInt32(Console.ReadLine());
            using (var context = new CampContext())
            {
                var deletenextofkin = context.NextOfKins.Where(n => n.NextOfKinId == nextofkinid).FirstOrDefault();
                context.NextOfKins.Remove(deletenextofkin);
                context.SaveChanges();
            }
        }
    }
}
