namespace Web.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Table
    {
        [Key]
        public int ID_table { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int Seats_count { get; set; }

        [Required]
        [StringLength(50)]
        public string? Type { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }
    }

}