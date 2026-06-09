using Microsoft.AspNetCore.Mvc;
using ObligatorioWeb.Models;
using System.Diagnostics;
using Logica;
using Obligatorio_P1;

namespace ObligatorioWeb.Controllers
{
    public class HomeController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass) {

            try
            {
                Persona logeado = s.login(email, pass);

                if (logeado != null)
                {
                    HttpContext.Session.SetString("email", logeado.Nombre);
                    HttpContext.Session.SetString("rol", logeado.Cargo.ToString());

                    return RedirectToAction("Index", "Home");

                }
                else {
                    ViewBag.texto = "Credenciales incorrectas";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.texto = ex.Message;
                return View();
            }
        }

       


        public IActionResult LogOut() {

            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");

        }
    }
}
