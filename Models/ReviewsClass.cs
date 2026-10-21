using System;
using System.Collections.Generic;
using System.Text;

namespace GasApp.Models
{
    internal class ReviewsClass
    {
        public int idReview { get; set; }
        public int idcomercio { get; set; }
        public string Review { get; set; } = string.Empty;  
        public float estrellas { get; set; }
        public int IdUserReg { get; set; }
        public DateTime fechareg { get; set; }

    }
}
