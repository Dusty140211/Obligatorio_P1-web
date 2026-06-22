using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public abstract class Incidente
    {
        public int ID { get; set; }
        public DateTime FechaReportado { get; set; }
        public Activo ActivoAfectado { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; } 
        public int Impacto { get; set; }
        public int Probabilidad { get; set; }
        public Incidente(int id, DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int impacto, int probabilidad)
        {
            ID = id;
            FechaReportado = fechaReportado;
            ActivoAfectado = activoAfectado;
            Descripcion = descripcion;
            Estado = estado;
            Impacto = impacto;
            Probabilidad = probabilidad;

            
        }

        public void ValidarDescripcion() 
        {
            if (string.IsNullOrEmpty(Descripcion)) throw new Exception("La descripcion no puede estar vacia");
        }

        public virtual void Validacion() 
        {
            ValidarDescripcion();
        }

        public override string ToString()
        {
            return $"ID: {ID}, Fecha: {FechaReportado}, Estado: {Estado}, " +
                   $"Descripción: {Descripcion}, Impacto: {Impacto}, Probabilidad: {Probabilidad}, " +
                   $"Activo afectado: {ActivoAfectado.ToString()}";
        }

        public virtual int Severidad() {

            int resultado = 0;
            if (resultado <= 100)
            {
                resultado = (Impacto * 12) + (Probabilidad * 8);
                return resultado;
            }
            else
            {
                throw new Exception("la operacion no puede superar el numero 100");
            }

        }

        public bool AfectaAPersona(Persona persona)
        {
            return ActivoAfectado != null && ActivoAfectado.PerteneceAPersona(persona);
        }

        public override bool Equals(object? obj)
        {
            return obj is Incidente inc && ID.Equals(inc.ID);
        }

       
        
    }
}
