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
    
    public partial class PlantDiseaseFactor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlantDiseaseFactor()
        {
            this.PlantDiseaseFeedbacks = new HashSet<PlantDiseaseFeedback>();
        }
    
        public int Id { get; set; }
        public Nullable<int> PlantDiseaseId { get; set; }
        public Nullable<int> FactorId { get; set; }
        public Nullable<decimal> From { get; set; }
        public Nullable<decimal> To { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
    
        public virtual Factor Factor { get; set; }
        public virtual PlantDiseaseJunc PlantDiseaseJunc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlantDiseaseFeedback> PlantDiseaseFeedbacks { get; set; }
    }
}
