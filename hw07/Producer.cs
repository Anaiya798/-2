using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace EF
{
    [Table("Producer")]
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int NumberOfReagents { get; set; }   

    }
}
