using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;


namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=test8;Trusted_Connection=True; TrustServerCertificate=True");
            //optionsBuilder.UseSqlServer(@"Data Source=104.247.162.242\MSSQLSERVER2019;Database=aymodam1_blog;Integrated Security=false;User ID=aymodam1_furkan;Password=R0$lu03w3;TrustServerCertificate=True");
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ContactUser> ContactUser { get; set; }
        public DbSet<Writer> Writer { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
    }
}
