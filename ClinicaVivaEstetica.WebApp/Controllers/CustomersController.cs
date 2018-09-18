using System;
using ClinicaVivaEstetica.WebApp.Models;
using ClinicaVivaEstetica.WebApp.Utils.RestIntegration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = RestIntegration.Get<ApiReturnList<CustomerResult>>("http://localhost:54878/", "/api/Customers");

            return View(customers?.Items);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerResult model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = RestIntegration.Post<CustomerResult, ApiReturnList<CustomerResult>>("http://localhost:54878/", "/api/Customers", model);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception e)
            {
                return View(model);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(Guid id)
        {
            var customer = RestIntegration.Get<ApiReturnItem<CustomerResult>>("http://localhost:54878/", $"/api/Customers/{id}");
            return View(customer?.Item);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerResult model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = RestIntegration.Put<CustomerResult, ApiReturnList<CustomerResult>>("http://localhost:54878/", "/api/Customers", model);

                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                var customer = RestIntegration.Delete("http://localhost:54878/", $"/api/Customers/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}