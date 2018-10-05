
using System.Collections.Generic;
using System.Linq;
using CompaniesAndProducts.DAL;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.Tests.Mock {
    public class ProductsRepositoryMock : IRepository<Product> {

        private readonly List<Product> _products = new List<Product>();
        
        public Product Find(int? id) {
            return _products.FirstOrDefault(p => p.ProductKey == id);
        }

        public void Add(Product t) {
            _products.Add(t);
        }

        public void Update(Product t) {
            
        }

        public void Remove(int? id) {
            _products.RemoveAll(p => p.ProductKey == id);
        }

        public void Dispose() { }

        public IQueryable<Product> All => _products.AsQueryable();

    }
}
