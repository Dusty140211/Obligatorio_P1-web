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


      

        [HttpGet]
        public IActionResult ListadoActivos()
        {
            try
            {
                string rol = HttpContext.Session.GetString("rol");
                string cedula = HttpContext.Session.GetString("cedula");

                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(cedula))
                    return RedirectToAction("Login");

                Persona p = s.ObtenerPersona(cedula);

                if (p == null)
                {
                    ViewBag.Error = "No se encontró la persona";
                    return View(new List<Activo>());
                }

                List<Activo> activos = s.ObtenerActivosDe(p);

                ViewBag.IsAdmin = false;
                ViewBag.CedulaPersona = cedula;

                return View(activos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Activo>());
            }
        }





        [HttpGet]
        public IActionResult ListadoActivosAdmin(int id)
        {
            try
            {
                var rol = HttpContext.Session.GetString("rol");
                if (string.IsNullOrEmpty(rol)) return View();

               

                List<Activo> activos = s.ObtenerActivosCuenta(id);
            

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

        public IActionResult CrearCuenta(string cedulaPersona)
        {
            try
            {

                ViewBag.CedulaPersona = cedulaPersona;

                return View(new Cuenta());

            }
            catch
            {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }
        }
        [HttpPost]
        public IActionResult CrearCuenta(Cuenta c, string id) {
            try
            {
                Persona pBuscada = s.ObtenerPersona(id);
                c.Titular = pBuscada;
                s.altaCuenta(c);

                return RedirectToAction("listarCuentas", new { id = id });
            }
            catch {
                ViewBag.Error = "Error al obtener los activos de la persona";
                return View();
            }

        }

        [HttpGet]
        public IActionResult CrearActivo(int idCuenta, string cedulaPersona)
        {
            ViewBag.IdCuenta = idCuenta;
            ViewBag.CedulaPersona = cedulaPersona;

            return View(new Activo());
        }

        [HttpPost]
        public IActionResult CrearActivo(Activo a, int idCuenta, string cedulaPersona)
        {
            try
            {
                Cuenta cuenta = s.ObtenerCuenta(idCuenta);

                a.Cuenta = cuenta;

                s.altaActivo(a);

                return RedirectToAction("ListadoActivosAdmin", new { id = idCuenta });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.IdCuenta = idCuenta;
                ViewBag.CedulaPersona = cedulaPersona;
                return View(a);
            }
        }

        [HttpGet]
        public IActionResult ListadoIncidentes()
        {
            try
            {
                string rol = HttpContext.Session.GetString("rol");
                string cedula = HttpContext.Session.GetString("cedula");

                if (string.IsNullOrEmpty(rol) || string.IsNullOrEmpty(cedula))
                    return RedirectToAction("Login");
                if (HttpContext.Session.GetString("rol") == "ADMINISTRADOR")
                {

                    List<Incidente> inc = s.ObtenerIncidentes();

     
                    return View(inc);
                }
                return View();
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<Activo>());
            }
        }


    }
}

