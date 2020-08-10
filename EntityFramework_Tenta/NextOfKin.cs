using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class NextOfKin
    {
        [Key]
        public int NextOfKinId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
    }
}
