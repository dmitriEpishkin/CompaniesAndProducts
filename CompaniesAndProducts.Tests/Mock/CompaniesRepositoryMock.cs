
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompaniesAndProducts.DAL;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.Tests.Mock {
    public class CompaniesRepositoryMock : IRepository<Company> {

        private readonly List<Company> _companies = new List<Company>();

        public Company Find(int? id) {
            return _companies.FirstOrDefault(p => p.CompanyKey == id);
        }

        public void Add(Company t) {
            _companies.Add(t);
        }

        public void Update(Company t) {
            
        }

        public void Remove(int? id) {
            _companies.RemoveAll(p => p.CompanyKey == id);
        }

        public void Dispose() {

        }

        public IQueryable<Company> All => _companies.AsQueryable();

    }
}
