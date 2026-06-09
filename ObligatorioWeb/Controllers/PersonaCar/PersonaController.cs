using Logica;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_P1;

namespace ObligatorioWeb.Controllers.PersonaCar
{
    public class PersonaController : Controller
    {
        Sistema s = Sistema.Instancia;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registro() {
            return View(new Persona());
        }

        [HttpPost]
        public IActionResult Registro(Persona p) {
            try
            {

                p.Cargo = Cargo.OPERADOR;
                s.altaPersona(p);

                return RedirectToAction("Login", "Home");


            }
            catch 
            { 
                ViewBag.Error = "Error al registrar la persona";
                return View(p);
            }
    }
    }
}
