using System.Web.Mvc;
using CompaniesAndProducts.Controllers;
using CompaniesAndProducts.DAL;
using CompaniesAndProducts.Models;
using Unity;
using Unity.Mvc5;

namespace CompaniesAndProducts
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IRepository<Company>, CompaniesRepository>();
            container.RegisterType<IRepository<Product>, ProductsRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}