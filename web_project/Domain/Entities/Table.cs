namespace Web.Entities
{
    public class Table
    {
        public int Id { get; set; } // Первичный ключ
        public int Number { get; set; }
        public int SeatsCount { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public ICollection<BookingTables> BookingTables { get; set; }
    }
}