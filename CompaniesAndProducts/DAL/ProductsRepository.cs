
using System.Data.Entity;
using System.Linq;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.DAL {
    public class ProductsRepository : IRepository<Product> {

        private readonly CompaniesAndProductsContext _db = new CompaniesAndProductsContext();

        public Product Find(int? id) {
            return _db.Products.Find(id);
        }

        public void Add(Product product) {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Update(Product product) {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChangesAsync();
        }

        public void Remove(int? id) {
            Product product = _db.Products.Find(id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public IQueryable<Product> All => _db.Products;

        public void Dispose() {
            _db.Dispose();
        }
    }
}