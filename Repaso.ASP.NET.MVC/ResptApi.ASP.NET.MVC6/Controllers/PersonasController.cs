using asp.net_mvc6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc6.Controllers
{
    public class PersonasController : Controller
    {
        static List<PersonaModel> personas = new List<PersonaModel>
        {
                new (){ DNI=23432324, Nombre="Luis"},
                new (){ DNI=33432224, Nombre="Esteban"},
        };

        // GET: PersonasController
        public ActionResult Index()
        {
            return View(personas);
        }

        /*
        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        */

        // GET: PersonasController/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Crear(IFormCollection collection)
        public ActionResult Crear(PersonaModel nuevo)
        {
            try
            {
                personas.Add(nuevo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /*
        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
