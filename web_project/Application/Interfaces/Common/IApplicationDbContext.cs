using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Application.Interfaces.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Table> Tables { get; set; }
    }
}