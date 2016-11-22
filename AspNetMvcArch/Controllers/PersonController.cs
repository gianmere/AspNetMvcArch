using System.Net;
using System.Web.Mvc;
using AspNetMvcArch.Domain;
using AspNetMvcArch.Service;
using AspNetMvcArch.Models;
using System.Collections.Generic;
using AutoMapper;

namespace AspNetMvcArch.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _PersonService;
        ICountryService _CountryService;
        public PersonController(IPersonService PersonService, ICountryService CountryService)
        {
            _PersonService = PersonService;
            _CountryService = CountryService;
        }

        // GET: /Person/
        public ActionResult Index()
        {
            var persons = _PersonService.GetAll();
            var model = new List<PersonModel>();
            foreach (var person in persons)
            {
                var personModel = AutoMapper.Mapper.Map<PersonModel>(person);
                model.Add(personModel);
            }

            return View(model);
        }

        // GET: /Person/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id.Value);

            if (person == null)
            {
                return HttpNotFound();
            }

            PersonModel personModel = Mapper.Map<PersonModel>(person);

            return View(personModel);
        }

        // GET: /Person/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: /Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,City,CountryId")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<Person>(personModel);

                _PersonService.Create(person);
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", personModel.CountryId);
            return View(personModel);
        }

        // GET: /Person/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }

            PersonModel personModel = Mapper.Map<PersonModel>(person);

            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(personModel);
        }

        // POST: /Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,City,CountryId")] PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                var person = Mapper.Map<Person>(personModel);
                _PersonService.Update(person);
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", personModel.CountryId);
            return View(personModel);
        }

        // GET: /Person/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            var personModel = Mapper.Map<PersonModel>(person);
            return View(personModel);
        }

        // POST: /Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Person person = _PersonService.GetById(id);
            _PersonService.Delete(person);
            return RedirectToAction("Index");
        }
    }
}
