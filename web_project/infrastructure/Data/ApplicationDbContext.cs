using Application.Interfaces.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Table> Tables { get; set; }

        public object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public int Max(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
