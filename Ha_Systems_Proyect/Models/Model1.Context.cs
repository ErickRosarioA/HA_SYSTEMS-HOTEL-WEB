﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ha_Systems_Proyect.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HA_SYSTEMSEntities1 : DbContext
    {
        public HA_SYSTEMSEntities1()
            : base("name=HA_SYSTEMSEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLIENTE> CLIENTEs { get; set; }
        public virtual DbSet<CUENTA_POR_COBRAR> CUENTA_POR_COBRAR { get; set; }
        public virtual DbSet<FACTURA> FACTURAs { get; set; }
        public virtual DbSet<HABITACION> HABITACIONs { get; set; }
        public virtual DbSet<HOSPEDAJE> HOSPEDAJEs { get; set; }
        public virtual DbSet<INVENTARIO> INVENTARIOs { get; set; }
        public virtual DbSet<MONITOR_SESSION> MONITOR_SESSION { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }
    }
}