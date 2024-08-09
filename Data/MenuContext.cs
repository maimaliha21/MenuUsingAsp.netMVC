using Microsoft.EntityFrameworkCore;
using Menu.Models;
namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId

            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients)
         .HasForeignKey(d => d.DishId);

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Ingredient).WithMany(di => di.DishIngredients)
      .HasForeignKey(d => d.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Margharitta", Price = 7.50, ImageUrl = "https://www.cnet.com/a/img/resize/36e8e8fe542ad9af413eb03f3fbd1d0e2322f0b2/hub/2023/02/03/afedd3ee-671d-4189-bf39-4f312248fb27/gettyimages-1042132904.jpg?auto=webp&fit=crop&height=1200&width=1200" });


            modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, Name = "Tako souce" },
            new Ingredient { Id = 2, Name = "Mozorella" });

            modelBuilder.Entity<DishIngredient>().HasData(
            new DishIngredient { DishId = 1,IngredientId=1 }, new DishIngredient { DishId = 1, IngredientId = 2 });
           

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
    } }
