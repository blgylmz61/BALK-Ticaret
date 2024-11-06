using DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductLike> ProductLikes { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>().HasData(
          new UserRole()
          {
              Id = 1,
              Role = "Admin",
              Description = "Yönetici"

          });
            modelBuilder.Entity<User>().HasData(
           new User()
           {
               Id = 1,
               Email = "admin@gmail.com",
               Name = "Bilge",
               Surname = "Karaca",
               Password = "0661",
               Username = "blgkrc61",
               UserRoleId = 1
           });
            modelBuilder.Entity<ProductDetail>()
            .HasOne(pd => pd.Country)
            .WithMany() // Country içinde ProductDetail koleksiyonu yok
            .HasForeignKey(pd => pd.CountryId)
            .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve City arasındaki ilişki
            modelBuilder.Entity<ProductDetail>()
                .HasOne(pd => pd.City)
                .WithMany() // City içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve District arasındaki ilişki
            modelBuilder.Entity<ProductDetail>()
                .HasOne(pd => pd.District)
                .WithMany() // District içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);

           

            modelBuilder.Entity<UserDetail>()
           .HasOne(pd => pd.Country)
           .WithMany() // Country içinde ProductDetail koleksiyonu yok
           .HasForeignKey(pd => pd.CountryId)
           .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve City arasındaki ilişki
            modelBuilder.Entity<UserDetail>()
                .HasOne(pd => pd.City)
                .WithMany() // City içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve District arasındaki ilişki
            modelBuilder.Entity<UserDetail>()
                .HasOne(pd => pd.District)
                .WithMany() // District içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Bill>()
           .HasOne(pd => pd.Country)
           .WithMany() // Country içinde ProductDetail koleksiyonu yok
           .HasForeignKey(pd => pd.CountryId)
           .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve City arasındaki ilişki
            modelBuilder.Entity<Bill>()
                .HasOne(pd => pd.City)
                .WithMany() // City içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.CityId)
                .OnDelete(DeleteBehavior.NoAction);

            // ProductDetail ve District arasındaki ilişki
            modelBuilder.Entity<Bill>()
                .HasOne(pd => pd.District)
                .WithMany() // District içinde ProductDetail koleksiyonu yok
                .HasForeignKey(pd => pd.DistrictId)
                .OnDelete(DeleteBehavior.NoAction);


        }




    }
}
