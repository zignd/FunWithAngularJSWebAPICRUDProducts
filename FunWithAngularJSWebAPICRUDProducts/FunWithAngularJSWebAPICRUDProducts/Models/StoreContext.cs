using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithAngularJSWebAPICRUDProducts.Models
{
    /// <summary>
    /// Context for accessing the datastore
    /// </summary>
    /// <remarks>
    /// This class inherits from IdentityDbContext which provides the
    /// DbSet<> for IdentityUser and IdentityRole. We could supply a
    /// custom User type which is a descendant of IdentityUser, and
    /// IdentityDbContext would use that to create the DbSet<>, but
    /// for the purposes of this application it isn't needed, so we
    /// will provide the default IdentityUser
    /// </remarks>
    public class StoreContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Creates a new instance of the context
        /// </summary>
        /// <remarks>
        /// This constructor assumes that the context will be named
        /// "ExampleContext" in your Web.config file.
        /// </remarks>
        public StoreContext()
            : base("StoreContext")
        {
        }

        /// <summary>
        /// Products
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }
        /// <summary>
        /// Categories used on products
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Uses the fluent API to explicitly define some relations in the schema
        /// </summary>
        /// <param name="modelBuilder">Supplied by Entity Framework</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // allow the base we are overriding to do its work
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Category);

            modelBuilder.Entity<Category>();
        }
    }
}
