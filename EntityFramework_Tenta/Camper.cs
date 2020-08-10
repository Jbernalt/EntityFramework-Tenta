using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class Camper
    {
        [Key]
        public int CamperId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Phonenumber { get; set; }
        [Required]
        public Cabin Cabin { get; set; }
        public virtual List<Relation> Relations { get; set; }
    }
}
