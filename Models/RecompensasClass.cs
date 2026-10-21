using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    internal class RecompensasClass
    {

        public int IdRecompensa { get; set; }

        public string Titulo { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public int CostoPuntos { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechafin { get; set; }

        public int idcomercio { get; set; }





    }
}
