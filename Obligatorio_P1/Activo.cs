using Obligatorio_P1;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Activo
    {
        private int _id;
        private string _name;
        private tipoDeActivo _tipo;
        private int _criticidad;
        private Cuenta _cuenta;
        private bool _backup;
        private static int _contador;
        
        public int ID { get; set; }
        public string Name { get; set; }

        public tipoDeActivo Tipo { get; set; }
        public int Criticidad { get; set; }
        public Cuenta Cuenta { get; set; }
        public bool Backup { get; set; }

        public Activo(string nombre, tipoDeActivo tipo, int criticidad, Cuenta cuenta, bool backup)
        {
            _id = _contador++;
            _name = nombre;
            _tipo = tipo;
            _criticidad = criticidad;
            _cuenta = cuenta;
            _backup = backup;

            validacion();
        }


        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(_name)) throw new Exception("El nombre no puede estar vacio");
        }
        public void validacion()
        {
            ValidarNombre();
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Name}, Tipo: {Tipo}, Criticidad: {Criticidad}, Cuenta: {Cuenta}, Backup: {Backup}";
        }



        public bool PerteneceAPersona(Persona persona)
        {
            return Cuenta != null && Cuenta.EsDeTitular(persona);
        }

        public override bool Equals(object? obj)
        {
            return obj is Activo a && _id.Equals(a._id);
        }
    }
}
