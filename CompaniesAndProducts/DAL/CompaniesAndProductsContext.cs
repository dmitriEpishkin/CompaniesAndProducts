
using System.Data.Entity;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.DAL {
    public class CompaniesAndProductsContext : DbContext {

        public DbSet<Company> Companies { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}