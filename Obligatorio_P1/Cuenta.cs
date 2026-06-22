    using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Cuenta 
    {
        public static int contadorid = 0;
        public int Id { get; }
        public Persona Titular { get; set; }
        public bool MFA { get; set; }
        public DateTime UCContrase { get; set; }

        public Cuenta() 
        {
            Id = contadorid++;
            UCContrase = DateTime.Now; 
        }

        public Cuenta(Persona titular, bool mfa, DateTime ucContraseña)
        {
            Id = contadorid++;
            Titular = titular;
            MFA = mfa;
            UCContrase = ucContraseña;
        }

        public override string ToString()
        {
            return $"ID Cuenta: {Id}, Titular: {Titular.Nombre}, MFA Activo: {MFA}, Último cambio de contraseña: {UCContrase.ToShortDateString()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Cuenta c && Id.Equals(c.Id);
        }

        public bool EsDeTitular(Persona persona)
        {
            return Titular != null &&
                   Titular.Cedula == persona.Cedula;
        }

       
    }
}
