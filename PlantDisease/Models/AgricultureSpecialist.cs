//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlantDisease.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgricultureSpecialist
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public Nullable<int> Rates { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual City City { get; set; }
    }
}
