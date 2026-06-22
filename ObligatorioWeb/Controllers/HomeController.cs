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
                    HttpContext.Session.SetString("nombre", logeado.Nombre);
                    HttpContext.Session.SetString("rol", logeado.Cargo.ToString());
                    HttpContext.Session.SetString("cedula", logeado.Cedula);

                    return RedirectToAction("Index", "Home");

                }
                else {
                    ViewBag.Error = "Credenciales incorrectas";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

       


        public IActionResult LogOut() {

            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");

        }
    }
}
