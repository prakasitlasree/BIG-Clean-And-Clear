﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIG.Clean.Care.DAL
{
    using MODEL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class BIGCCEntities : DbContext
    {
        public BIGCCEntities()
            : base("name=BIGCCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LOGON> LOGON { get; set; }
        public virtual DbSet<PAGE_CONTENT> PAGE_CONTENT { get; set; }
    }
}
