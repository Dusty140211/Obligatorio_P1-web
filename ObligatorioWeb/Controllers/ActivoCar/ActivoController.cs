using Logica;
using Microsoft.AspNetCore.Mvc;
using Obligatorio_P1;

namespace ObligatorioWeb.Controllers.ActivoCar
{
    public class ActivoController : Controller
    {
        Sistema s = Sistema.Instancia;


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
            catch
            {
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

    }
}
