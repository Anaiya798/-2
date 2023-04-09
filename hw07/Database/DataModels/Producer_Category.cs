using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF
{
    [Table("Producer_Category")]
    public class Producer_Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }

}
