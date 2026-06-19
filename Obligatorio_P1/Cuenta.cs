    using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Cuenta : IComparable<Cuenta>
    {
        public int Id { get; set; }
        public Persona Titular { get; set; }
        public bool MFA { get; set; }
        public DateTime UCContrase { get; set; }


        public Cuenta(int idCuenta, Persona titular, bool mfa, DateTime ucContraseña)
        {
            Id = idCuenta   ;
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
            return Titular != null && Titular.Equals(persona);
        }

        public int CompareTo(Cuenta c) {

            return Id.CompareTo(c.Id); 

        }
    }
}
