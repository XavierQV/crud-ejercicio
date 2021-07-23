using crud_ejercicio.Data;
using crud_ejercicio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_ejercicio.Controllers
{
    [Authorize]
    public class Personas2Controller : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public Personas2Controller(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Authorize(Roles= "Jefe,Vendedor")]
        public IActionResult Index()
        {
            List<Persona> DPersona = new List<Persona>();
            DPersona = _applicationDbContext.Persona.ToList();

            return View(DPersona);
        }
        [Authorize(Roles = "Jefe")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Jefe")]
        [HttpPost]
        public IActionResult Create(Persona persona)
        {

            try
            {
                persona.Estado = 1;
                _applicationDbContext.Add(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                return View(persona);

            }
            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Jefe")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == id).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);

        }
        [Authorize(Roles = "Jefe")]
        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                return View(persona);

            }
            return RedirectToAction("Index");

        }

        [Authorize(Roles = "Jefe,Vendedor")]
        public IActionResult Details(int ide)
        {
            if (ide == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == ide).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);
        }
        [Authorize(Roles = "Jefe")]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Jefe")]
        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(q => q.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");

        }

    }
}




