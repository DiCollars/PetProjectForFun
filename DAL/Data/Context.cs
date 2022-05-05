using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Publication> Publication { get; set; }
        public DbSet<PublicationLike> PublicationLike { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SubscribeRequest> SubscribeRequest { get; set; }
        public DbSet<RegistrationRequest> RegistrationRequests { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;Username=postgres;Password=здесь_указывается_пароль_от_postgres");
        //}
    }
}
