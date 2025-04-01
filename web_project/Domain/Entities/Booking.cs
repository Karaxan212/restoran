using System.ComponentModel.DataAnnotations;

namespace Web.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        public int ID_table { get; set; } // Связь со столиком

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        // Навигационные свойства
        public Table? Table { get; set; } 
        public ICollection<BookingTables> BookingTables { get; set; } = new List<BookingTables>();
    }
}