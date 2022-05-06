using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {}

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {}

        public DbSet<Publication> Publication { get; set; }
        public DbSet<PublicationLike> PublicationLike { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SubscribeRequest> SubscribeRequest { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var appsettingsPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "PhotoManager");

                var appsettings = new ConfigurationBuilder()
                    .SetBasePath(appsettingsPath)
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

                var connectionString = appsettings["ConnectionStrings:DefaultConnection"];

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
