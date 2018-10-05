using System;
using System.Linq;

namespace CompaniesAndProducts.DAL {
    public interface IRepository<T> : IDisposable where T : class {

        T Find(int? id);
        void Add(T t);
        void Update(T t);
        void Remove(int? id);

        IQueryable<T> All { get; }

    }
}
