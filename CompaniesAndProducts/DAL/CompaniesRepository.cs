
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.DAL {
    public class CompaniesRepository : IRepository<Company> {

        private readonly CompaniesAndProductsContext _db = new CompaniesAndProductsContext();
        
        public Company Find(int? id) {
            return _db.Companies.Find(id);
        }

        public void Add(Company company) {
            _db.Companies.Add(company);
            _db.SaveChanges();
        }

        public void Update(Company company) {
            _db.Entry(company).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(int? id) {
            Company company = _db.Companies.Find(id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
        }

        public IQueryable<Company> All => _db.Companies;

        public void Dispose() {
            _db.Dispose();
        }
    }
}