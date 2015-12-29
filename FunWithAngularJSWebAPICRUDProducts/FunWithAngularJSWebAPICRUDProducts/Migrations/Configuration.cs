namespace FunWithAngularJSWebAPICRUDProducts.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FunWithAngularJSWebAPICRUDProducts.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoreContext context)
        {
            context.Categories.AddRange(new[]
            {
                new Category { Id = 1, Name = "Category 1", Description = "Description 1", LastUpdated = DateTime.Now },
                new Category { Id = 2, Name = "Category 2", Description = "Description 2", LastUpdated = DateTime.Now }
            });

            context.Products.AddRange(new[]
            {
                new Product { CategoryId = 1, Name = "Product 1", Description = "Description 1", Price = 123.12M, LastUpdated = DateTime.Now },
                new Product { CategoryId = 2, Name = "Product 2", Description = "Description 2", Price = 223.12M, LastUpdated = DateTime.Now },
                new Product { CategoryId = 2, Name = "Product 3", Description = "Description 3", Price = 323.12M, LastUpdated = DateTime.Now }
            });

            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            userManager.Create(new IdentityUser { UserName = "User1" }, "123456");
            userManager.Create(new IdentityUser { UserName = "User2" }, "123456");

            context.SaveChanges();
        }
    }
}
