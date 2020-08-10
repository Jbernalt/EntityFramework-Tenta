using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class Counsler
    {
        [Key, ForeignKey("Cabin")]
        public int CounslerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }

        public Cabin Cabin { get; set; }
    }
}
