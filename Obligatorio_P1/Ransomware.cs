using System;
using System.Collections.Generic;
using System.Text;

namespace Logica
{
    public class Ransomware : Incidente
    {
     
        public bool Encriptados { get; set; }
        public bool Exfiltraciones { get; set; }

        public Ransomware(int id, DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int impacto, int probabilidad, bool encriptados, bool exfiltracion)
            : base(id, fechaReportado, activoAfectado, descripcion, estado, impacto, probabilidad)
        {

            Encriptados = encriptados;
            Exfiltraciones = exfiltracion;
        }

        public override string ToString()
        {
            return $"[Ransomware]\n{base.ToString()}\n" +
                   $"Datos encriptados: {Encriptados}, Hubo exfiltración: {Exfiltraciones}";
        }

    }
}
