using System.Linq;
using Proyecto_Adopcion_Mascota.Models;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Adopcion_Mascota.Controllers
{
    public class MascotaController : Controller
    {
        private AdopcionContext _context { get; }

        public MascotaController(AdopcionContext context) {
            _context = context;
        }

        public IActionResult Listar()
        {
            var mascotas = _context.Mascotas.ToList();

            return View(mascotas);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarMascota(Mascota p)
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
                var mascotaBd = _context.Mascotas.Find(p.Id);

                mascotaBd.Nombre = p.Nombre;
                mascotaBd.Raza = p.Raza;
                mascotaBd.Foto = p.Foto;

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