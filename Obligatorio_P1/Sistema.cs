using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;


namespace Logica
{
    public class Sistema
    {

        //CONSOLA
        // a) Listado de todas las personas, mostrando sus activos asociados en un renglon aparte -
        // b) Dada una persona listar todos los incidentes en la que se vio involucrada -
        // c) alta de la persona - 
        // d) listar los activos que carecen de backup -

        // LO UNICO QUE FALTA ES DAR MAS ALTAS DE CADA UNA DE LAS LISTAS 

        //_________________________________________________________________________________________________________________________________________

        // Atributos
        private List<Persona> _personas = new List<Persona>();
        private List<Cuenta> _cuentas = new List<Cuenta>();
        private List<Activo> _activos = new List<Activo>();
        private List<Incidente> _incidentes = new List<Incidente>();
        private static Sistema _instancia;

        // Propiedades

        public List<Persona> Personas { get { return new List<Persona>(_personas); } }
        public List<Cuenta> Cuentas { get { return new List<Cuenta>(_cuentas); } }
        public List<Activo> Activos { get { return new List<Activo>(_activos); } }
        public List<Incidente> Incidentes { get { return new List<Incidente>(_incidentes); } }


        public Sistema()
        {


            _personas = new List<Persona>();
            _activos = new List<Activo>();
            _cuentas = new List<Cuenta>();
            _incidentes = new List<Incidente>();

            PrecargarDatos();

        }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sistema();
                return _instancia;
            }
        }

        // Listas inicializadas

        // PRECARGAR DE OTRA FORMA QUE NO SEA EN EL CONSTRUCTOR, PARA QUE SE PUEDA USAR EN OTROS LUGARES SI SE QUIERE, O SIMPLEMENTE PARA ORDENAR MEJOR EL CODIGO
        public void PrecargarDatos()
        {

            // PERSONAS
            altaPersona(new Persona("10111111", "Ana Torres", "ana.torres@gmail.com", "Ana1234", 99100001, Cargo.OPERADOR));
            altaPersona(new Persona("10222222", "Luis Gomez", "luis.gomez@gmail.com", "Luis1234", 99100002, Cargo.OPERADOR));
            altaPersona(new Persona("10333333", "Carla Ruiz", "carla.ruiz@gmail.com", "Carla1234", 99100003, Cargo.OPERADOR));
            altaPersona(new Persona("10444444", "Diego Martinez", "diego.martinez@gmail.com", "Diego1234", 99100004, Cargo.OPERADOR));
            altaPersona(new Persona("10555555", "Sofia Lopez", "sofia.lopez@gmail.com", "Sofia1234", 99100005, Cargo.OPERADOR));
            altaPersona(new Persona("10666666", "Pedro Sanchez", "pedro.sanchez@gmail.com", "Pedro1234", 99100006, Cargo.OPERADOR));
            altaPersona(new Persona("10777777", "Lucia Fernandez", "lucia.fernandez@gmail.com", "Lucia1234", 99100007, Cargo.ADMINISTRADOR));
            altaPersona(new Persona("10888888", "Martin Castro", "martin.castro@gmail.com", "Martin1234", 99100008, Cargo.ADMINISTRADOR));
            altaPersona(new Persona("10999999", "Valeria Diaz", "valeria.diaz@gmail.com", "Valeria1234", 99100009, Cargo.ADMINISTRADOR));
            altaPersona(new Persona("11000000", "Javier Morales", "javier.morales@gmail.com", "Javier1234", 99100010, Cargo.ADMINISTRADOR));

            // CUENTAS
            altaCuenta(new Cuenta(1, _personas[0], true, new DateTime(2023, 1, 10)));
            altaCuenta(new Cuenta(2, _personas[1], true, new DateTime(2023, 2, 12)));
            altaCuenta(new Cuenta(3, _personas[2], true, new DateTime(2023, 3, 14)));
            altaCuenta(new Cuenta(4, _personas[3], true, new DateTime(2023, 4, 16)));
            altaCuenta(new Cuenta(5, _personas[4], true, new DateTime(2023, 5, 18)));
            altaCuenta(new Cuenta(6, _personas[5], true, new DateTime(2023, 6, 20)));
            altaCuenta(new Cuenta(7, _personas[6], true, new DateTime(2023, 7, 22)));
            altaCuenta(new Cuenta(8, _personas[7], true, new DateTime(2023, 8, 24)));
            altaCuenta(new Cuenta(9, _personas[8], true, new DateTime(2023, 9, 26)));
            altaCuenta(new Cuenta(10, _personas[9], true, new DateTime(2023, 10, 28)));
            altaCuenta(new Cuenta(11, _personas[0], true, new DateTime(2023, 11, 5)));
            altaCuenta(new Cuenta(12, _personas[1], true, new DateTime(2023, 12, 8)));

            // ACTIVOS
            altaActivo(new Activo("PC Desarrollo 1", tipoDeActivo.PC, 2, _cuentas[0], true));
            altaActivo(new Activo("Servidor Central", tipoDeActivo.SERVER, 5, _cuentas[1], false));
            altaActivo(new Activo("Laptop Ventas", tipoDeActivo.MOVIL, 3, _cuentas[2], true));
            altaActivo(new Activo("PC Contabilidad", tipoDeActivo.PC, 2, _cuentas[3], false));
            altaActivo(new Activo("Servidor Backup", tipoDeActivo.SERVER, 4, _cuentas[4], true));
            altaActivo(new Activo("Tablet Marketing", tipoDeActivo.MOVIL, 1, _cuentas[5], false));
            altaActivo(new Activo("PC Recepcion", tipoDeActivo.PC, 1, _cuentas[6], true));
            altaActivo(new Activo("Servidor Web", tipoDeActivo.SERVER, 5, _cuentas[7], true));
            altaActivo(new Activo("Celular Ejecutivo", tipoDeActivo.MOVIL, 2, _cuentas[8], false));
            altaActivo(new Activo("PC Soporte", tipoDeActivo.PC, 3, _cuentas[9], true));
            altaActivo(new Activo("Servidor DB", tipoDeActivo.SERVER, 5, _cuentas[10], true));
            altaActivo(new Activo("Tablet Logistica", tipoDeActivo.MOVIL, 2, _cuentas[11], true));
            altaActivo(new Activo("PC QA", tipoDeActivo.PC, 2, _cuentas[0], true));
            altaActivo(new Activo("Servidor Apps", tipoDeActivo.SERVER, 4, _cuentas[1], false));
            altaActivo(new Activo("Celular Soporte", tipoDeActivo.MOVIL, 1, _cuentas[2], false));

            // INCIDENTES
            altaIncidente(new Phishing(1, new DateTime(2024, 1, 1), _activos[0], "Correo falso recibido", Estado.ABIERTO, 3, 2, "Email", true, false));
            altaIncidente(new Ransomware(2, new DateTime(2024, 1, 2), _activos[1], "Servidor bloqueado", Estado.EN_ANALISIS, 5, 4, true, true));
            altaIncidente(new Phishing(3, new DateTime(2024, 1, 3), _activos[2], "Link sospechoso", Estado.CERRADO, 2, 1, "SMS", false, true));
            altaIncidente(new Ransomware(4, new DateTime(2024, 1, 4), _activos[3], "Archivos cifrados", Estado.CONTENIDO, 4, 3, true, false));
            altaIncidente(new Phishing(5, new DateTime(2024, 1, 5), _activos[4], "Intento de robo credenciales", Estado.EN_ANALISIS, 3, 2, "Email", true, false));
            altaIncidente(new Ransomware(6, new DateTime(2024, 1, 6), _activos[5], "Dispositivo infectado", Estado.CERRADO, 2, 2, false, true));
            altaIncidente(new Phishing(7, new DateTime(2024, 1, 7), _activos[6], "Correo bancario falso", Estado.ABIERTO, 3, 3, "Email", true, true));
            altaIncidente(new Ransomware(8, new DateTime(2024, 1, 8), _activos[7], "Sistema comprometido", Estado.EN_ANALISIS, 5, 5, true, true));
            altaIncidente(new Phishing(9, new DateTime(2024, 1, 9), _activos[8], "SMS fraudulento", Estado.CERRADO, 1, 1, "SMS", false, false));
            altaIncidente(new Ransomware(10, new DateTime(2024, 1, 10), _activos[9], "PC bloqueada", Estado.CONTENIDO, 4, 3, true, false));
            altaIncidente(new Phishing(11, new DateTime(2024, 1, 11), _activos[10], "Correo IT falso", Estado.EN_ANALISIS, 2, 2, "Email", true, true));
            altaIncidente(new Ransomware(12, new DateTime(2024, 1, 12), _activos[11], "Tablet cifrada", Estado.CERRADO, 3, 2, false, true));
            altaIncidente(new Phishing(13, new DateTime(2024, 1, 13), _activos[12], "Adjunto sospechoso", Estado.ABIERTO, 3, 3, "Email", true, false));
            altaIncidente(new Ransomware(14, new DateTime(2024, 1, 14), _activos[13], "Servidor caido", Estado.EN_ANALISIS, 5, 4, true, true));
            altaIncidente(new Phishing(15, new DateTime(2024, 1, 15), _activos[14], "Intento de estafa", Estado.CERRADO, 2, 1, "SMS", false, false));
            altaIncidente(new Ransomware(16, new DateTime(2024, 1, 16), _activos[0], "Sistema inutilizable", Estado.CONTENIDO, 4, 4, true, true));
            altaIncidente(new Phishing(17, new DateTime(2024, 1, 17), _activos[1], "Correo falso soporte", Estado.EN_ANALISIS, 3, 2, "Email", true, true));
            altaIncidente(new Ransomware(18, new DateTime(2024, 1, 18), _activos[2], "Laptop cifrada", Estado.CERRADO, 2, 2, false, true));
            altaIncidente(new Phishing(19, new DateTime(2024, 1, 19), _activos[3], "Link fraudulento", Estado.ABIERTO, 3, 3, "Email", true, false));
            altaIncidente(new Ransomware(20, new DateTime(2024, 1, 20), _activos[4], "Backup afectado", Estado.EN_ANALISIS, 5, 5, true, true));
            altaIncidente(new Phishing(21, new DateTime(2024, 1, 21), _activos[5], "Mensaje sospechoso", Estado.CERRADO, 1, 1, "SMS", false, false));
            altaIncidente(new Ransomware(22, new DateTime(2024, 1, 22), _activos[6], "Equipo comprometido", Estado.CONTENIDO, 4, 3, true, false));
            altaIncidente(new Phishing(23, new DateTime(2024, 1, 23), _activos[7], "Correo banco falso", Estado.EN_ANALISIS, 3, 2, "Email", true, true));
            altaIncidente(new Ransomware(24, new DateTime(2024, 1, 24), _activos[8], "Celular infectado", Estado.CERRADO, 2, 2, false, true));
            altaIncidente(new Phishing(25, new DateTime(2024, 1, 25), _activos[9], "Adjunto malicioso", Estado.ABIERTO, 3, 3, "Email", true, false));
            altaIncidente(new Ransomware(26, new DateTime(2024, 1, 26), _activos[10], "Base de datos cifrada", Estado.EN_ANALISIS, 5, 5, true, true));
            altaIncidente(new Phishing(27, new DateTime(2024, 1, 27), _activos[11], "SMS engañoso", Estado.CERRADO, 1, 1, "SMS", false, false));
            altaIncidente(new Ransomware(28, new DateTime(2024, 1, 28), _activos[12], "PC inutilizada", Estado.CONTENIDO, 4, 4, true, true));
            altaIncidente(new Phishing(29, new DateTime(2024, 1, 29), _activos[13], "Correo falso admin", Estado.EN_ANALISIS, 3, 2, "Email", true, true));
            altaIncidente(new Ransomware(30, new DateTime(2024, 1, 30), _activos[14], "Movil cifrado", Estado.CERRADO, 2, 2, false, true));

        }

        // CREAR METODOS ALTA UTILIZANDO CONTAINS PARA VER SI YA EXISTE EL ELEMENTO EN LA LISTA, SI EXISTE LANZAR UNA EXCEPCION, SINO AGREGARLO A LA LISTA CORRESPONDIENTE

        public void altaCuenta(Cuenta c)
        {
            if (_cuentas.Contains(c)) throw new Exception("La persona ya existe en el sistema.");
            else _cuentas.Add(c);

        }

        public void altaIncidente(Incidente i)
        {
            if (_incidentes.Contains(i)) throw new Exception("El incidente ya existe en el sistema.");
            else _incidentes.Add(i);
        }

        public void altaActivo(Activo a)
        {
            if (_activos.Contains(a)) throw new Exception("El activo ya existe en el sistema.");
            else _activos.Add(a);
        }



        // a
        // ESTE METODO RECORRE LA LISTA DE ACTIVOS Y POR CADA ACTIVO RECORRE LA LISTA DE PERSONAS, SI EL ACTIVO PERTENECE A LA PERSONA, SE AGREGA A LA LISTA QUE SE DEVOLVERA AL FINAL, ESTA LISTA CONTENDRA LOS ACTIVOS QUE TIENEN PERSONAS ASOCIADAS


        public List<Persona> personasConActivosAgrupadas()
        {
            List<Persona> resultado = new List<Persona>();

            foreach (Persona persona in _personas)
            {
                foreach (Activo act in _activos)  
                {
                    if (act.PerteneceAPersona(persona))
                    {
                        resultado.Add(persona);
                        break;
                    }
                }
            }

            return resultado;
        }

        public List<Activo> ObtenerActivosDe(Persona persona)
        {
            List<Activo> resultado = new List<Activo>();
            foreach (Activo act in _activos)
            {
              if(act.PerteneceAPersona(persona))
                    resultado.Add(act);
            }
            return resultado;
        }

        // Metodo apra obtener todas las personas

        public List<Persona> listarPersonas()
        {

            List<Persona> resultado = new List<Persona>();
            foreach (Persona p in _personas)
            {
                if (p != null)
                {
                    resultado.Add(p);
                }
            }
            return resultado;
        }


        //Metodo que me pasa una persona segun la cedula

        public Persona ObtenerPersona(string cedula) {
            foreach(Persona p in _personas) {
                if (p != null && p.Cedula == cedula) {
                    return p;
                }
              }
            return null; 
        }

        //Metodo que pasa una cuenta segun la cedula
        public List<Cuenta> listarCuenta(Persona p) {
            List<Cuenta> resultado = new List<Cuenta>();
            if (p == null) return resultado; 
            foreach (Cuenta c in _cuentas) {
                if (c != null && c.Titular == p) { 
                    resultado.Add(c);
                }
            }
            return resultado; 
        }

        // c
        // ALTA DE PERSONA

        public void altaPersona(Persona p)
        {
            if (p != null)
            {
                p.validacion();
                if (Personas.Contains(p)) throw new Exception("La persona ya existe en el sistema.");
                else _personas.Add(p);
            }
            else
            {
                throw new Exception("La persona es nula.");
            }

        }

        public Activo ActivoBuscado(int id) {
            
            foreach (Activo a in _activos) {
                if (a.id == id) {
                    return a; 
                }
                
            }
            return null;
        }



        public Persona login(string email, string pass) {

            foreach (Persona per in _personas) {
                if (email == per.Email && pass == per.Contraseña)
                {
                    return per;
                }

            }
            return null; 
        }

        public void BajaActivo(int id)
        {
            Activo a = ActivoBuscado(id);
            if (a == null) throw new Exception("El activo no existe en el sistema.");
            // quitar del listado de activos (sólo ese)
            _activos.Remove(a);
            // opcional: desvincular su cuenta
            if (a.Cuenta != null) a.Cuenta = null;
        }


    }

}
