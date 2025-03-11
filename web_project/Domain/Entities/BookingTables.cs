using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Entities
{
    public class BookingTables
    {
        public int ID_BookingTable { get; set; } // Первичный ключ
        public int ID_booking { get; set; }
        public Booking Booking { get; set; }

        public int TableId { get; set; } // Связь с Table
        public Table Table { get; set; }
        public int ID_table { get; set; }
    }
}