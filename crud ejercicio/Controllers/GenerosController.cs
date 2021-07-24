using crud_ejercicio.Data;
using crud_ejercicio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_ejercicio.Controllers
{
    [Authorize]
    public class GenerosController : Controller
       
    {
        private readonly ApplicationDbContext _context;
        public GenerosController (ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Jefe,Vendedor")]
        // GET: GemerosController1
        public ActionResult Index()
        {
            List<Genero> ltsgenero = _context.Generos.ToList();
            return View(ltsgenero);
        }
        [Authorize(Roles = "Jefe,Vendedor")]
        // GET: GemerosController1/Details/5
        public ActionResult Details(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(q => q.Codigo == id);
            return View(genero);
        }
        [Authorize(Roles = "Jefe")]
        // GET: GemerosController1/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Jefe")]
        // POST: GemerosController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(genero);
                    _context.SaveChanges();
                    return RedirectToAction(("Index"));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "Jefe")]
        // GET: GemerosController1/Edit/5
        public ActionResult Edit(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(q => q.Codigo == id);
            return View();
        }
        [Authorize(Roles = "Jefe")]
        // POST: GemerosController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {

            if (id != genero.Codigo)
            {
                return RedirectToAction(("Index"));
            }
            try
            {
                _context.Update(genero);
                 _context.SaveChanges();
                return RedirectToAction(("Index"));
            }
            catch
            {
                return View(genero);
            }
        }
        [Authorize(Roles = "Jefe")]
        //[Authorize(Roles = "Jefe")]
        public IActionResult Desactivar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero persona = _context.Generos.Where(q => q.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 0;
                _context.Update(persona);
                _context.SaveChanges();
            }
            catch (Exception exc)
            {
                Console.Error.WriteLine(exc.Message);
                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");

        }
        [Authorize(Roles = "Jefe")]
        //[Authorize(Roles = "Jefe")]
        public IActionResult Activar(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Genero persona = _context.Generos.Where(q => q.Codigo == id).FirstOrDefault();
            try
            {
                persona.Estado = 1;
                _context.Update(persona);
                _context.SaveChanges();
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
