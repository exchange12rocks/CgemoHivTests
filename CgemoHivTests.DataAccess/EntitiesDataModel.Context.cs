﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CgemoHivTests.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class CgemoHivTestsContext : DbContext
    {
        public CgemoHivTestsContext()
            : base("name=CgemoHivTestsEntities")
        {
        }
        public CgemoHivTestsContext(string connectionName)
            : base(connectionName)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Declarant> Declarants { get; set; }
        public virtual DbSet<PersonAnalysis> Persons { get; set; }
        public virtual DbSet<ResponsesToDeclarant> ResponsesToDeclarants { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UpdateLog> UpdateLogs { get; set; }
    }
}