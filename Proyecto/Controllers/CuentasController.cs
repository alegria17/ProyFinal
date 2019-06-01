using Proyecto.Models;
using Proyecto.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto.Controllers
{
    public class CuentasController : Controller
    {
        private AdopcionContext _context;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        public CuentasController(
            AdopcionContext c,
            UserManager<IdentityUser> um,
            SignInManager<IdentityUser> sim
        ) {
            _context = c;
            _userManager = um;
            _signInManager = sim;
        }

        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistroViewModel model) {
            if (ModelState.IsValid) {
                var user = new IdentityUser();
                user.UserName = model.Usuario;
                user.Email = model.Email;

                var resultado = _userManager.CreateAsync(user, model.Password);

                if (resultado.Result == IdentityResult.Success) {
                    //FUNCIONALIDAD AUN NO CORRE
                    //_signInManager.SignInAsync(user, false);

                    return RedirectToAction("index", "home");
                }
                else {
                    foreach (var error in resultado.Result.Errors) {
                        ModelState.AddModelError("error", error.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var resultado = _signInManager.PasswordSignInAsync(model.Usuario, model.Password, false, false);

                if (resultado.Result.Succeeded) {
                    return RedirectToAction("index", "home");
                }
                else {
                    ModelState.AddModelError("error", "Usuario o contraseña incorrectos");
                
                }
            }

            return View(model);
        }

        public IActionResult Logout() {
            _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }
    }
}