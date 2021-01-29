using ConsciousConnections.Contracts;
using ConsciousConnections.Models;
using ConsciousConnections.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsciousConnections.Controllers
{
    public class CompanyController : Controller
    {

        //private readonly ICompanyService _companyService;

        //public CompanyController (ICompanyService companyService)
        //{
        //    _companyService = companyService;
        //}


        // GET: Company
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyService(userId);
            var model = service.GetCompanies();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCompanyService();

            if (service.CreateCompany(model))
            {
                TempData["SaveResult"] = "Your company was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Company could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        private CompanyService CreateCompanyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CompanyService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCompanyService();
            var detail = service.GetCompanyById(id);
            var model =
                new CompanyEdit
                {
                    CompanyId = detail.CompanyId,
                    CompanyName = detail.CompanyName,
                    CompanyDescription = detail.CompanyDescription,
                    StreetAddress = detail.StreetAddress,
                    City = detail.City,
                    State = detail.State,
                    ZipCode = detail.ZipCode,
                    Website = detail.Website,
                    PhoneNumber = detail.PhoneNumber
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CompanyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCompanyService();

            if (service.UpdateCompany(model))
            {
                TempData["SaveResult"] = "Your company was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your company could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCompanyService();
            var model = svc.GetCompanyById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCompanyService();

            service.DeleteCompany(id);

            TempData["SaveResult"] = "Your company was deleted";

            return RedirectToAction("Index");
        }
    }
}