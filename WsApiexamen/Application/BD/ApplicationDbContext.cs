using Microsoft.EntityFrameworkCore;
using WsApiexamen.Domain;

namespace WsApiexamen.Application.BD
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<tblExamen> tblExamen { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblExamen>()
                .HasKey(e => e.idExamen);
        }
    }
}
