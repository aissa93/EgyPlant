using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantDisease.Models
{
    public class ObservationSheet
    {

        public int ObservationId { get; set; }
        public string ObservationName { get; set; }
        
        public bool Infected { get; set; }

        public decimal InfectedValue { get; set; }

       public IEnumerable<Factor> Factors { get; set; }



    }

    public class SheetFactor {

        public int FactorId { get; set; }
        public decimal FactorValue { get; set; }

       public string FactorName { get; set; }
    }
    
}