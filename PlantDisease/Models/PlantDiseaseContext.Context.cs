﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PlantDiseaseContext : DbContext
    {
        public PlantDiseaseContext()
            : base("name=PlantDiseaseContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgricultureSpecialist> AgricultureSpecialists { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Factor> Factors { get; set; }
        public virtual DbSet<Observation> Observations { get; set; }
        public virtual DbSet<ObservationFactor> ObservationFactors { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<PlantDiseaseFactor> PlantDiseaseFactors { get; set; }
        public virtual DbSet<PlantDiseaseFeedback> PlantDiseaseFeedbacks { get; set; }
        public virtual DbSet<PlantDiseaseJunc> PlantDiseaseJuncs { get; set; }
        public virtual DbSet<State> States { get; set; }
    }
}
