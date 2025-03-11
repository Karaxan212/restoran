using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Common;
using Web.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<BookingTables> BookingTables { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingTables>()
                .HasKey(bt => bt.ID_BookingTable);

            modelBuilder.Entity<BookingTables>()
                .HasOne(bt => bt.Booking)
                .WithMany(b => b.BookingTables)
                .HasForeignKey(bt => bt.ID_booking);

            modelBuilder.Entity<BookingTables>()
                .HasOne(bt => bt.Table)
                .WithMany(t => t.BookingTables)
                .HasForeignKey(bt => bt.ID_table);
        }
    }
}
