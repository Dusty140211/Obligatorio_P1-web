using Logica;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Registro()
        {
            return View(new Persona());
        }

        [HttpPost]
        public IActionResult Registro(Persona p)
        {
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

        public IActionResult Perfil()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Perfil(string cedula)
        {
            try
            {
                Persona p = null;
                if (HttpContext.Session.GetString("rol") != null)
                {
                    List<Cuenta> cuentas = new List<Cuenta>();


                    cedula = HttpContext.Session.GetString("cedula");
                    p = s.ObtenerPersona(cedula);

                    cuentas = s.listarCuenta(p);

                    ViewBag.Cuenta = cuentas;
                    return View(p);
                }
                return View();

            }
            catch
            {
                ViewBag.Error = "Error al obtener el perfil de la persona";
                return View();


            }

        }




        public IActionResult listarPersonas()
        {

            try
            {
                List<Persona> personas;

                if (HttpContext.Session.GetString("rol") == "ADMINISTRADOR")
                {
                    personas = s.listarPersonas();
                    return View(personas);

                }

                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener las personas";
                return View();
            }
        }

    }
}

