using EntityLayer.Concrete;
using EntityLayer.Contrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory =
        new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
        });


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=test10;Trusted_Connection=True; TrustServerCertificate=True");
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ContactUser> ContactUser { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }
        public DbSet<MailLog> MailLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// UrlTitle alanına tekil indeks eklemek
			modelBuilder.Entity<Blog>()
				.HasIndex(e => e.UrlTitle)
				.IsUnique();

            //modelBuilder.HasDefaultSchema("aymodam1_personal");
        }
    }
}
