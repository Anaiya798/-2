using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EF
{
    [Table("Expertise")]
    public class Expertise
    { 
        [Key]
        public int Id { get; set;}     
        [Required]
        public int ReagentID { get; set; }
        [StringLength(20)]
        [Required]
        public string Toxicity { get; set; }
        [StringLength(20)]
        [Required]
        public string WaterSolubility { get; set; }
    }
}
