
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CompaniesAndProducts.DAL;
using CompaniesAndProducts.Models;

namespace CompaniesAndProducts.Controllers {
    public class CompaniesController : Controller {

        private readonly IRepository<Company> _companiesRepository;

        public CompaniesController(IRepository<Company> companiesRepository) {
            _companiesRepository = companiesRepository;
        }

        // GET: Companies
        public ActionResult Index() {
            return View(_companiesRepository.All.ToList());
        }
        
        // GET: Companies/Details/5
        public ActionResult Details(int? id) {

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Company company = _companiesRepository.Find(id);

            if (company == null) {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyKey,Name,Description,Site")] Company company) {

            if (ValidateCompany(company) && ModelState.IsValid) {
                _companiesRepository.Add(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _companiesRepository.Find(id);
            if (company == null) {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyKey,Name,Description,Site")] Company company) {
            if (ValidateCompany(company) && ModelState.IsValid) {
                _companiesRepository.Update(company);
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = _companiesRepository.Find(id);
            if (company == null) {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            _companiesRepository.Remove(id);
            return RedirectToAction("Index");
        }

        private bool ValidateCompany(Company company) {
            if (_companiesRepository.All.Any(c => c.Name == company.Name && c.CompanyKey != company.CompanyKey)) {
                ModelState.AddModelError("", "Компания с таким именем уже существует");
                return false;
            }
            if (_companiesRepository.All.Any(c => c.Site == company.Site && c.CompanyKey != company.CompanyKey)) {
                ModelState.AddModelError("", "Компания с таким сайтом уже существует");
                return false;
            }

            return true;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _companiesRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
