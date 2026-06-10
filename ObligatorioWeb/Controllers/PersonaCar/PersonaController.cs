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

        
        public IActionResult ListadoActivos() {
            return View(); 
        }

        [HttpGet]
        public IActionResult ListadoActivos(string cedula) {

            try
            {
                if (HttpContext.Session.GetString("rol") == "OPERADOR")
                {
                    cedula = HttpContext.Session.GetString("cedula");
                    Persona p = s.ObtenerPersona(cedula);
                    List<Activo> a = s.ObtenerActivosDe(p);

                    return View(a);
                }

                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }

        public IActionResult Perfil() {
            return View(); 
        }

        [HttpGet]
        public IActionResult Perfil(string cedula)
        {
            try
            {
                if (HttpContext.Session.GetString("rol") == "OPERADOR")
                {
                    cedula = HttpContext.Session.GetString("cedula");
                    Persona p = s.ObtenerPersona(cedula);
                    List<Cuenta> c = s.listarCuenta(p);

                    ViewBag.Cuentas = c;
                }
                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener el perfil de la persona";
                return View();


            }

        }

   
}
