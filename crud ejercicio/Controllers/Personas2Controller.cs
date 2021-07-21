using crud_ejercicio.Data;
using crud_ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_ejercicio.Controllers
{
    public class Personas2Controller : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Personas2Controller(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            List<Persona> DPersona = new List<Persona>();
            DPersona = _applicationDbContext.Persona.ToList();

            return View(DPersona);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Persona persona)
        {

            try
            {

                _applicationDbContext.Add(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                return View(persona);

            }
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == id).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);

        }
        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {

                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                return View(persona);

            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == id).FirstOrDefault();
            try
            {

                _applicationDbContext.Remove(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");
        }
    }
}




