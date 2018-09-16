using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantDisease.Models
{
    public class ObservationConfigViewModel
    {
        public int PlantId { get; set; }

        public int DiseaseId { get; set; }

       public IEnumerable<string> Factors { get; set; }

       public string Facts { get; set; }


    }
}