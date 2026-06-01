    using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Cuenta
    {
        private int _id;
        private Persona _titular;
        private bool _mfa;
        private DateTime _ucContraseña;

        public int ID { get; set; }
        public Persona Titular { get; set; }
        public bool MFA { get; set; }
        public DateTime UCContrase { get; set; }


        public Cuenta(int id, Persona titular, bool mfa, DateTime ucContraseña)
        {
            _id = id;
            _titular = titular;
            _mfa = mfa;
            _ucContraseña = ucContraseña;
        }

        public override string ToString()
        {
            return $"ID Cuenta: {ID}, Titular: {Titular.Nombre}, MFA Activo: {MFA}, Último cambio de contraseña: {UCContrase.ToShortDateString()}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Cuenta c && _id.Equals(c._id);
        }

        public bool EsDeTitular(Persona persona)
        {
            return Titular != null && Titular.Equals(persona);
        }
    }
}
