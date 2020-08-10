using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
        public class Cabin
        {
            [Key]
            public int CabinId { get; set; }
            public string Name { get; set; }

            public Counsler Counsler { get; set; }
            public virtual List<Camper> Campers { get; set; }
        }

}
