using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Phishing : Incidente
    {
       

        public string CanalUsado { get; set; }
        public bool Credenciales { get; set; }
        public bool Transferencias { get; set; }

        public Phishing(int id, DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int impacto, int probabilidad, string canalUsado, bool credenciales, bool transferencias)
            : base(id, fechaReportado, activoAfectado, descripcion, estado, impacto, probabilidad)
        {
            

            CanalUsado = canalUsado;
            Credenciales = credenciales;
            Transferencias = transferencias;
        }

        public override string ToString()
        {
            return $"[Phishing]\n{base.ToString()}\n" +
                   $"Canal usado: {CanalUsado}, Credenciales expuestas: {Credenciales}, Transferencias realizadas: {Transferencias}";
        }


        public void validarCanal() 
        { 
            if (string.IsNullOrWhiteSpace(CanalUsado))
                throw new Exception("El canal usado no puede estar vacío.");
        }
        public override void Validacion()
        {
            base.Validacion();
            validarCanal(); 
        }
    }
}
