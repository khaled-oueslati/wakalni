using System;
using System.Linq;
using System.Threading.Tasks;
using wakalni.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace wakalni.database
{
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options ) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region seeding Roles DATA
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
                new IdentityRole() { Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole() { Name = "Chef", NormalizedName = "CHEF" }
                );
            #endregion
            #region ItemTypes
            //builder.Entity<BaseEntity>()
            //    .Property(it => it.Id)
            //    .ValueGeneratedOnAdd();
            builder.Entity<ItemType>().HasData(
                new ItemType { Id = 1, Label = "Desert", NormalizedLabel = "DESERT" },
                new ItemType { Id = 2, Label = "Starter", NormalizedLabel = "STARTER" },
                new ItemType { Id = 3, Label = "Dish", NormalizedLabel = "DISH" },
                new ItemType { Id = 4, Label = "Appetizer", NormalizedLabel = "APPETIZER" },
                new ItemType { Id = 5, Label = "Drinks", NormalizedLabel = "DRINKS" },
                new ItemType { Id = 6, Label = "Ham", NormalizedLabel = "HAM" }
                );
            #endregion

            #region Item many to many relations
            builder.Entity<Item_ItemType>().HasKey(x=> new { x.ItemId, x.ItemTypeId});
            builder.Entity<Item_ItemType>()
                .HasOne(itt => itt.Item)
                .WithMany(i => i.ItemTypes)
                .HasForeignKey(itt => itt.ItemId);
            builder.Entity<Item_ItemType>()
                .HasOne(itt => itt.ItemType)
                .WithMany(it => it.Items)
                .HasForeignKey(itt => itt.ItemId);

            builder.Entity<Item>()
                .HasMany(it => it.Images)
                .WithOne(im => im.Item)
                .HasForeignKey(im => im.ItemId);
            #endregion
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<FoodSharingSpace> FoodSharingSpaces { get; set; }

    }
}
