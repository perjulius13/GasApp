using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    internal class HistorialPuntos
    {
        public int Id { get; set; }

        public int Iduser { get; set; }
        public int IdComercio { get; set; }
        public string Detalle { get; set; } = string.Empty; 

        public int Cantidad { get; set; }

        public DateTime FechaReg { get; set; }

        public int IduserReg { get; set; }

    }
}
