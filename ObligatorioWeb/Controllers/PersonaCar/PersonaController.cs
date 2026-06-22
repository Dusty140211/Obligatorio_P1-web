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

        public IActionResult listarCuentas(string id)
        {
            try
            {
                List<Cuenta> cuentas;
                if (HttpContext.Session.GetString("rol") == "ADMINISTRADOR")
                {


                    Persona p = s.ObtenerPersona(id);
                    cuentas = s.listarCuenta(p);
                    return View(cuentas);

                }
                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener las cuentas";
                return View();
            }

        }


        public IActionResult ListadoActivos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListadoActivos(string id)
        {

            try
            {

                List<Activo> activos;

                var Rols = HttpContext.Session.GetString("rol");
                if (string.IsNullOrEmpty(Rols)) return View();

                if (HttpContext.Session.GetString("rol") != null)
                {
                    if (string.IsNullOrEmpty(id))
                    {
                        id = HttpContext.Session.GetString("cedula");
                    }

                    if (id == null) return View();

                    Persona p = s.ObtenerPersona(id);
                    activos = s.ObtenerActivosDe(p);

                    ViewBag.IsAdmin = HttpContext.Session.GetString("rol") == "ADMINISTRADOR";

                    return View(activos);
                }

                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }


        public IActionResult ListadoActivosAdmin()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ListadoActivosAdmin(string id)
        {
            try
            {
                var rol = HttpContext.Session.GetString("rol");
                if (string.IsNullOrEmpty(rol)) return View();

                if (string.IsNullOrEmpty(id))
                    id = HttpContext.Session.GetString("cedula");

                if (id == null) return View();

                Persona p = s.ObtenerPersona(id);
                List<Activo> activos = s.ObtenerActivosDe(p);

                ViewBag.IsAdmin = rol == "ADMINISTRADOR";
                ViewBag.CedulaPersona = id;  // ← NUEVO

                return View(activos);
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }

        public IActionResult Eliminar(int id, string cedulaPersona)
        {
            try
            {
                Activo aBuscada = s.ActivoBuscado(id);
                ViewBag.CedulaPersona = cedulaPersona;
                if (aBuscada != null) return View(aBuscada);
                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }

        
        [HttpPost]
        public IActionResult Eliminar(int id, string chequeado, string cedulaPersona)
        {
            try
            {
                if (chequeado == "true")
                {
                    s.BajaActivo(id);
                }
                return RedirectToAction("ListadoActivosAdmin", new { id = cedulaPersona });
            }
            catch {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }

        public IActionResult CrearCuenta(int id, string cedulaPersona) 
        {
            try
            {
                Activo aBuscada = s.ActivoBuscado(id);
                ViewBag.CedulaPersona = cedulaPersona;
                if (aBuscada != null) return View(aBuscada);
                return View();
            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CrearCuenta(Cuenta c,string id, string chequeado, string cedulaPersona) {
            if (chequeado == "true") {
                Persona pBuscada = s.ObtenerPersona(id);
                c.Titular = pBuscada;
                s.altaCuenta(c);
            }
            return RedirectToAction("listarCuentas", new {id = cedulaPersona});
        
        }
    }
}
