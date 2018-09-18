using System;
using ClinicaVivaEstetica.WebApp.Models;
using ClinicaVivaEstetica.WebApp.Utils.RestIntegration;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaVivaEstetica.WebApp.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            var Services = RestIntegration.Get<ApiReturnList<ServiceResult>>("http://localhost:54878/", "/api/Services");

            return View(Services?.Items);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceResult model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var result = RestIntegration.Post<ServiceResult, ApiReturnList<ServiceResult>>("http://localhost:54878/", "/api/Services", model);

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

        // GET: Services/Edit/5
        public ActionResult Edit(Guid id)
        {
            var Service = RestIntegration.Get<ApiReturnItem<ServiceResult>>("http://localhost:54878/", $"/api/Services/{id}");
            return View(Service?.Item);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceResult model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = RestIntegration.Put<ServiceResult, ApiReturnList<ServiceResult>>("http://localhost:54878/", "/api/Services", model);

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
                var Service = RestIntegration.Delete("http://localhost:54878/", $"/api/Services/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}