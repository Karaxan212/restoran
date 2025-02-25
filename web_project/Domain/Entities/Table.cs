using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int SeatsCount { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
