using System.Web.Mvc;
using AspNetMvcArch.Domain;
using AspNetMvcArch.Service;
using AutoMapper;
using AspNetMvcArch.Models;
using System.Collections.Generic;

namespace AspNetMvcArch.Controllers
{
    public class CountryController : Controller
    {
        //initialize service object
        ICountryService _CountryService;

        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }

        //
        // GET: /Country/
        public ActionResult Index()
        {
            var countries = _CountryService.GetAll();
            var model = new List<CountryModel>();
            foreach (var country in countries)
            {
                var countryModel = Mapper.Map<CountryModel>(country);
                model.Add(countryModel);
            }

            return View(model);
        }

        //
        // GET: /Country/Details/5
        public ActionResult Details(int id)
        {
            

            return View();
        }

        //
        // GET: /Country/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Country/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountryModel countryModel)
        {

            // TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                var country = Mapper.Map<Country>(countryModel);
                _CountryService.Create(country);
                return RedirectToAction("Index");
            }
            return View(countryModel);

        }

        //
        // GET: /Country/Edit/5
        public ActionResult Edit(int id)
        {            
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }

            var countryModel = Mapper.Map<CountryModel>(country);
            return View(countryModel);
        }

        //
        // POST: /Country/Edit/5
        [HttpPost]
        public ActionResult Edit(CountryModel countryModel)
        {

            if (ModelState.IsValid)
            {
                var country = Mapper.Map<Country>(countryModel);
                _CountryService.Update(country);
                return RedirectToAction("Index");
            }
            return View(countryModel);

        }

        //
        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            var countryModel = Mapper.Map<CountryModel>(country);
            return View(countryModel);
        }

        //
        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            Country country = _CountryService.GetById(id);
            _CountryService.Delete(country);
            return RedirectToAction("Index");
        }
    }
}
