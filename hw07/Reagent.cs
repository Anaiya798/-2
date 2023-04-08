using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EF
{
    [Table("Reagent")]
    public class Reagent
    {
        [Key]
        public int ID { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public int ProducerID { get; set; }
       
        public int ExpertiseID { get; set; }
        Category category = new Category();
    }
}
