
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CompaniesAndProducts.Controllers;
using CompaniesAndProducts.Models;
using CompaniesAndProducts.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompaniesAndProducts.Tests.Controllers {
    [TestClass]
    public class ProductsControllerTest {

        private ProductsRepositoryMock CreateProductRepo() {

            var productRepo = new ProductsRepositoryMock();
            productRepo.Add(new Product { ProductKey = 1, Name = "1", Description = "1", Comission = "1" });
            productRepo.Add(new Product { ProductKey = 2, Name = "2", Description = "2", Comission = "2" });
            productRepo.Add(new Product { ProductKey = 3, Name = "3", Description = "3", Comission = "3" });
            
            return productRepo;
        }

        private CompaniesRepositoryMock CreateCompaniesRepo() {

            var companiesRepo = new CompaniesRepositoryMock();
            companiesRepo.Add(new Company { CompanyKey = 1, Name = "10", Description = "1", Site = "1" });
            companiesRepo.Add(new Company { CompanyKey = 2, Name = "20", Description = "2", Site = "2" });
            companiesRepo.Add(new Company { CompanyKey = 3, Name = "30", Description = "3", Site = "3" });

            return companiesRepo;
        }

        private ProductsController CreateProductsController() {
            var productsRepository = CreateProductRepo();
            var companiesRepository = CreateCompaniesRepo();
            return new ProductsController(companiesRepository, productsRepository);
        }

        [TestMethod]
        public void IndexReturnsViewResult() {

            var productsController = CreateProductsController();
           
            var result = productsController.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewResultModelIsListOf3Items() {

            var productsController = CreateProductsController();

            var result = productsController.Index() as ViewResult;

            var list = result.Model as List<Product>;
            
            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void DetailsReturnsBadRequestIfIdIsNull() {

            var productsController = CreateProductsController();

            var result = productsController.Details(null) as HttpStatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.BadRequest, (HttpStatusCode)result.StatusCode);
        }

        [TestMethod]
        public void DetailsReturnsHttpNotFoundIfIdIsWrong() {

            var productsController = CreateProductsController();

            var result = productsController.Details(4) as HttpNotFoundResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsReturnsViewResult() {

            var productsController = CreateProductsController();

            var result = productsController.Details(1) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsViewResultModelIsProductWithCorrectId() {

            var productsController = CreateProductsController();

            var result = productsController.Details(1) as ViewResult;

            var product = result.Model as Product;

            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.ProductKey);
        }

        [TestMethod]
        public void CreateReturnsViewResult() {

            var productsController = CreateProductsController();

            var result = productsController.Create() as ViewResult;
            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateViewResultModelIsEmpty() {

            var productsController = CreateProductsController();

            var result = productsController.Create() as ViewResult;

            var model = result.Model;

            Assert.IsNull(model);
        }

        [TestMethod]
        public void CreateViewBagContainsCompanySelectList() {

            var productsController = CreateProductsController();

            productsController.Create();

            var list = productsController.ViewBag.CompanyKey as SelectList;

            Assert.IsNotNull(list);

            var l = list.ToList();

            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("10", l[0].Text);
            Assert.AreEqual("20", l[1].Text);
            Assert.AreEqual("30", l[2].Text);

        }
        
        [TestMethod]
        public void CreateActionAddNewProductToRepository() {

            var productsRepo = CreateProductRepo();
            var companiesRepo = CreateCompaniesRepo();
            var productsController = new ProductsController(companiesRepo, productsRepo);
            
            var product = new Product { ProductKey = 4, Name = "4", Description = "4", Comission = "4" };
        
            productsController.Create(product);

            Assert.AreEqual(4, productsRepo.All.Count());
        }
        
    }
}
