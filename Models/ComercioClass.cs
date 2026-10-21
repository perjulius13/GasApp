using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    internal class ComercioClass
    {
        public int IdComer { get; set; }

        public string? Nombre { get; set; }

        public int IdTipoComer { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public bool Habilitado { get; set; }

        public string? Calle { get; set; }

        public string? Colonia { get; set; }

        public string? Cp { get; set; }

        public string? NumeroDir { get; set; }

        public string? NombrePropietario { get; set; }

        public string? LicenciaMercantil { get; set; }

        public int IdUserReg { get; set; }

        public DateTime FechaAlta { get; set; }

        public int Idcat { get; set; }

        public int Idact { get; set; }

    }
}
