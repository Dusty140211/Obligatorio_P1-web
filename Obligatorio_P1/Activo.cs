using Obligatorio_P1;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Activo
    {
        private static int _contador = 0;
        public int ID { get; set; }
        public string Name { get; set; }

        public tipoDeActivo Tipo { get; set; }
        public int Criticidad { get; set; }
        public Cuenta Cuenta { get; set; }
        public bool Backup { get; set; }

        public Activo(string nombre, tipoDeActivo tipo, int criticidad, Cuenta cuenta, bool backup)
        {
            ID = _contador++;
            Name = nombre;
            Tipo = tipo;
            Criticidad = criticidad;
            Cuenta = cuenta;
            Backup = backup;

            validacion();
        }


        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Name)) throw new Exception("El nombre no puede estar vacio");
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
            return obj is Activo a && ID.Equals(a.ID);
        }
    }
}
