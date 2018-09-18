using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ClinicaVivaEstetica.WebApp.Models;
using ClinicaVivaEstetica.WebApp.Utils.RestIntegration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicaVivaEstetica.WebApp.Controllers
{
    public class SchedulesController : Controller
    {
        // GET: Schedules
        public ActionResult Index()
        {
            var Schedules = RestIntegration.Get<ApiReturnList<ScheduleResult>>("http://localhost:54878/", "/api/Schedules");

            return View(Schedules?.Items);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            MakeDropdownsViewbags();
            return View();
        }

        // POST: Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScheduleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validate = RestIntegration.Get<ApiReturnItem<Boolean>>("http://localhost:54878/", $"/api/Schedules/Validate/{model.Day.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)}/{model.Hour}");

                    if (!(validate?.Item).GetValueOrDefault(false))
                    {
                        var result = RestIntegration.Post<ScheduleRequest, ApiReturnList<ScheduleResult>>(
                            "http://localhost:54878/", "/api/Schedules", new ScheduleRequest
                            {
                                Day = model.Day.Value,
                                Hour = model.Hour.Value,
                                ScheduleId = model.ScheduleId,
                                ServiceId = model.ServiceId,
                                CustomerId = model.CustomerId
                            });

                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError("Agendamento Existente", "Já existe agendamento no dia e horário escolhido");
                }

                MakeDropdownsViewbags();
                return View(model);

            }
            catch (Exception e)
            {
                MakeDropdownsViewbags(model.Hour, model.CustomerId, model.ServiceId);
                return View(model);
            }
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(Guid id)
        {
            var schedule = RestIntegration.Get<ApiReturnItem<ScheduleResult>>("http://localhost:54878/", $"/api/Schedules/{id}");

            MakeDropdownsViewbags(schedule?.Item?.Hour, schedule?.Item?.Customer?.CustomerId, schedule?.Item?.Service?.ServiceId);
            var model = schedule?.Item;

            return View(new ScheduleViewModel
            {
                Day = model.Day,
                Hour = model.Hour,
                ScheduleId = model.ScheduleId,
                ServiceId = model.ServiceId,
                CustomerId = model.CustomerId,
                Customer = model.Customer,
                Service = model.Service
            });
        }

        // POST: Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScheduleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var validate = RestIntegration.Get<ApiReturnItem<Boolean>>("http://localhost:54878/", $"/api/Schedules/Validate/{model.Day.Value:yyyy-MM-dd}/{model.Hour}/{model.ScheduleId}");

                    if (!(validate?.Item).GetValueOrDefault(false))
                    {
                        var result = RestIntegration.Put<ScheduleRequest, ApiReturnList<ScheduleResult>>(
                            "http://localhost:54878/", "/api/Schedules", new ScheduleRequest
                            {
                                Day = model.Day.Value,
                                Hour = model.Hour.Value,
                                ScheduleId = model.ScheduleId,
                                ServiceId = model.ServiceId,
                                CustomerId = model.CustomerId
                            });

                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError(String.Empty, "Já existe agendamento no dia e horário escolhido");
                }

                MakeDropdownsViewbags(model.Hour, model.CustomerId, model.ServiceId);
                return View(model);
            }
            catch (Exception e)
            {
                MakeDropdownsViewbags(model.Hour, model.CustomerId, model.ServiceId);
                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                var Service = RestIntegration.Delete("http://localhost:54878/", $"/api/Schedules/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public void MakeDropdownsViewbags(TimeSpan? hour = null, Guid? customerId = null, Guid? serviceId = null)
        {
            ViewBag.Hours = MakeHoursDropDownList(hour);
            ViewBag.HalfHours = MakeHalfHoursDropDownList(hour);
            ViewBag.Customers = MakeCustomersDropDownList(customerId);
            ViewBag.Services = MakeServicesDropDownList(serviceId);
        }


        private IEnumerable<SelectListItem> MakeHoursDropDownList(TimeSpan? hour = null)
        {
            var listHours = new List<int>();
            for (int i = 8; i < 17; i++) listHours.Add(i);

            return listHours.Select(s => new SelectListItem
            {
                Text = s.ToString().PadLeft(2, '0') + ":00",
                Selected = hour.HasValue && hour == new TimeSpan(s, 0, 0),
                Value = new TimeSpan(s, 0, 0).ToString()
            });
        }

        private IEnumerable<SelectListItem> MakeHalfHoursDropDownList(TimeSpan? hour = null)
        {
            var listHours = new List<TimeSpan>();
            for (int i = 8; i < 17; i++)
            {
                listHours.Add(new TimeSpan(i, 0, 0));

                if (i != 16)
                    listHours.Add(new TimeSpan(i, 30, 0));
            }

            return listHours.Select(s => new SelectListItem
            {
                Text = s.ToString(@"hh\:mm"),
                Selected = hour.HasValue && hour == s,
                Value = s.ToString()
            });
        }

        private IEnumerable<SelectListItem> MakeCustomersDropDownList(Guid? customerId = null)
        {
            var customers = RestIntegration.Get<ApiReturnList<CustomerResult>>("http://localhost:54878/", "/api/Customers");
            return customers?.Items.Select(s => new SelectListItem
            {
                Text = s.Name,
                Selected = customerId.HasValue && s.CustomerId == customerId,
                Value = s.CustomerId.ToString()
            });
        }

        private IEnumerable<SelectListItem> MakeServicesDropDownList(Guid? serviceId = null)
        {
            var services = RestIntegration.Get<ApiReturnList<ServiceResult>>("http://localhost:54878/", "/api/Services");

            ViewBag.EntityServices = services?.Items ?? new List<ServiceResult>();

            return services?.Items.Select(s => new SelectListItem
            {
                Text = s.Name,
                Selected = serviceId.HasValue && s.ServiceId == serviceId,
                Value = s.ServiceId.ToString()
            });
        }
    }
}