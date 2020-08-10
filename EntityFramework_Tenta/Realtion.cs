using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class Relation
    {
        [Key]
        public int RelationId { get; set; }

        [Required]
        public Camper Camper { get; set; }
        [Required]
        public NextOfKin NextOfKin { get; set; }
    }
}
