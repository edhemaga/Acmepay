using Acmepay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acmepay.Infrastructure.Persistance.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<CardHolder> CardHolders { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}