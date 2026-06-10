    using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Cuenta
    {
        public int ID { get; set; }
        public Persona Titular { get; set; }
        public bool MFA { get; set; }
        public DateTime UCContrase { get; set; }


        public Cuenta(int id, Persona titular, bool mfa, DateTime ucContraseña)
        {
            ID = id;
            Titular = titular;
            MFA = mfa;
            UCContrase = ucContraseña;
        }

        public override string ToString()
        {
            return $"ID Cuenta: {ID}, Titular: {Titular.Nombre}, MFA Activo: {MFA}, Último cambio de contraseña: {UCContrase.ToShortDateString()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Cuenta c && ID.Equals(c.ID);
        }

        public bool EsDeTitular(Persona persona)
        {
            return Titular != null && Titular.Equals(persona);
        }
    }
}
