using ConsciousConnections.Contracts;
using ConsciousConnections.Data;
using ConsciousConnections.Models;
using ConsciousConnections.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsciousConnections.Controllers
{
    [Authorize]

    public class ProductController : Controller
    {
        // GET: Product

        //private readonly IProductService _productService;
        ////private 


        //public ProductController(IProductService productService)
        //{
        //    _productService = productService;
        //}



        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            var model = service.GetProducts();

            return View(model);
        }

        public ActionResult Create()
        {
            var ctx = new ApplicationDbContext();
            ViewBag.Companies = ctx.Companies;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "Your product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        //private ProductService CreateProductService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new ProductService(userId);
        //    return service;
        //}


        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    ProductName = detail.ProductName,
                    ProductDescription = detail.ProductDescription,
                    Price = detail.Price,
                    IsGreenSealCertified = detail.IsGreenSealCertified,
                    IsRainForestAllianceCertified = detail.IsRainForestAllianceCertified,
                    IsFairTradeUSACertified = detail.IsFairTradeUSACertified,
                    IsLeapingBunnyCertified = detail.IsLeapingBunnyCertified,
                   // TypeOfCategory = (CategoryType).detail.TypeOfCategory,
                    //CompanyId = detail.CompanyId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "Your product was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your product could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "Your product was deleted";

            return RedirectToAction("Index");
        }

    }
}










