using System.Linq;
using Proyecto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class MascotasController : Controller
    {
        private AdopcionContext _context { get; }

        public MascotasController(AdopcionContext context) {
            _context = context;
        }

        public IActionResult Listar()
        {
            var mascota = _context.Mascotas.ToList();

            return View(mascota);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Mascota p)
        {
            if (ModelState.IsValid) {
                _context.Mascotas.Add(p);
                _context.SaveChanges();

                return RedirectToAction("Listar");
            }

            return View(p);
        }

        public IActionResult Actualizar(int id)
        {
            var p = _context.Mascotas.FirstOrDefault(x => x.Id == id);

            if (p == null) {
                return NotFound();
            }

            return View(p);
        }

        [HttpPost]
        public IActionResult Actualizar(Mascota p)
        {
            if (ModelState.IsValid) {
                var MascotaBd = _context.Mascotas.Find(p.Id);

                MascotaBd.Nombre = p.Nombre;
                MascotaBd.Precio = p.Precio;
                MascotaBd.Foto = p.Foto;

                _context.SaveChanges();

                return RedirectToAction("Listar");
            }

            return View(p);
        }

        public IActionResult Borrar(int id)
        {
            var p = _context.Mascotas.FirstOrDefault(x => x.Id == id);

            if (p != null) {
                _context.Mascotas.Remove(p);
                _context.SaveChanges();
            }

            return RedirectToAction("Listar");
        }

    }
}