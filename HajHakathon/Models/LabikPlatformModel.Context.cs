﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HajHakathon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LabickEntities : DbContext
    {
        public LabickEntities()
            : base("name=LabickEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<G_AirLineCompany> G_AirLineCompany { get; set; }
        public virtual DbSet<G_Companies> G_Companies { get; set; }
        public virtual DbSet<G_TawafCompany> G_TawafCompany { get; set; }
        public virtual DbSet<G_TawafCompany_User> G_TawafCompany_User { get; set; }
        public virtual DbSet<Sys_Cities> Sys_Cities { get; set; }
        public virtual DbSet<Sys_Countaries> Sys_Countaries { get; set; }
        public virtual DbSet<Sys_Languages> Sys_Languages { get; set; }
        public virtual DbSet<Sys_Menues> Sys_Menues { get; set; }
        public virtual DbSet<Sys_Roles> Sys_Roles { get; set; }
        public virtual DbSet<Sys_Types> Sys_Types { get; set; }
        public virtual DbSet<Sys_Users> Sys_Users { get; set; }
        public virtual DbSet<Sys_UsersAndRoles> Sys_UsersAndRoles { get; set; }
        public virtual DbSet<G_AirLineCompany_User> G_AirLineCompany_User { get; set; }
        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<EPCs> EPCs { get; set; }
        public virtual DbSet<Sys_Area> Sys_Area { get; set; }
        public virtual DbSet<TagEvents> TagEvents { get; set; }
        public virtual DbSet<Sys_ChekPoints> Sys_ChekPoints { get; set; }
        public virtual DbSet<Sys_Zone> Sys_Zone { get; set; }
        public virtual DbSet<G_Users> G_Users { get; set; }
    }
}
