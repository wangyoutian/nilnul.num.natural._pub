﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nilnul.num.natural.prime.db
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbEntities : DbContext
    {
    
    
    
    
        public dbEntities(string connectionString)
            : base(connectionString)
        {
        }
    
    
    
    
        public dbEntities()
            : base("name=dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CompositeCap> CompositeCap { get; set; }
        public virtual DbSet<Prime> Prime { get; set; }
    
        public virtual ObjectResult<PrimeMaxRecord_Result> PrimeMaxRecord()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PrimeMaxRecord_Result>("PrimeMaxRecord");
        }
    }
}
