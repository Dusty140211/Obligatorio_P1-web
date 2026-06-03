using Obligatorio_P1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public abstract class Incidente
    {
        private int _id;
        private DateTime _fechaReportado; 
        private Activo _activoAfectado;
        private string _descripcion;
        private Estado _estado;
        private int _impacto;
        private int probabilidad; 

        public int ID { get; set; }
        public DateTime FechaReportado { get; set; }
        public Activo ActivoAfectado { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; } 
        public int Impacto { get; set; }
        public int Probabilidad { get; set; }
        public Incidente(int id, DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int impacto, int probabilidad)
        {
            _id = id;
            _fechaReportado = fechaReportado;
            _activoAfectado = activoAfectado;
            _descripcion = descripcion;
            _estado = estado;
            _impacto = impacto;
            this.probabilidad = probabilidad;

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

        public bool AfectaAPersona(Persona persona)
        {
            return ActivoAfectado != null && ActivoAfectado.PerteneceAPersona(persona);
        }

        public override bool Equals(object? obj)
        {
            return obj is Incidente inc && _id.Equals(inc._id);
        }
        
    }
}
