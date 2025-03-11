using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Application.Interfaces.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Booking> Bookings { get; set; }
        DbSet<Table> Tables { get; set; }
        DbSet<BookingTables> BookingTables { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}