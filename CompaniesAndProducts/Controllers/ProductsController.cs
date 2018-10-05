
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CompaniesAndProducts.DAL;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.Controllers
{
    public class ProductsController : Controller {
        
        private readonly IRepository<Company> _companiesRepository;
        private readonly IRepository<Product> _productsRepository;

        public ProductsController(IRepository<Company> companiesRepository, IRepository<Product> productsRepository) {
            _companiesRepository = companiesRepository;
            _productsRepository = productsRepository;
        }

        // GET: Products
        public ActionResult Index() {
            return View(_productsRepository.All.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsRepository.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create() {
            ViewBag.CompanyKey = new SelectList(_companiesRepository.All.ToList(), "CompanyKey", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductKey,CompanyKey,Name,Description,Comission")] Product product) {
            if (ValidateProduct(product) && ModelState.IsValid) {
                _productsRepository.Add(product);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyKey = new SelectList(_companiesRepository.All.ToList(), "CompanyKey", "Name", product.CompanyKey);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsRepository.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            ViewBag.CompanyKey = new SelectList(_companiesRepository.All.ToList(), "CompanyKey", "Name", product.CompanyKey);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductKey,CompanyKey,Name,Description,Comission")] Product product) {
            if (ValidateProduct(product) && ModelState.IsValid) {
                _productsRepository.Update(product);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyKey = new SelectList(_companiesRepository.All.ToList(), "CompanyKey", "Name", product.CompanyKey);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productsRepository.Find(id);
            if (product == null) {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            _productsRepository.Remove(id);
            return RedirectToAction("Index");
        }

        private bool ValidateProduct(Product product) {
            if (_productsRepository.All.Any(p => p.Name == product.Name && p.CompanyKey != product.CompanyKey)) {
                ModelState.AddModelError("", "Продукт с таким именем уже существует");
                return false;
            }

            return true;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _companiesRepository.Dispose();
                _productsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
