﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telcel.R9.Estructura.AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AMartinezEstructuraEntities1 : DbContext
    {
        public AMartinezEstructuraEntities1()
            : base("name=AMartinezEstructuraEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
    
        public virtual ObjectResult<DepartamentosGetAll_Result> DepartamentosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentosGetAll_Result>("DepartamentosGetAll");
        }
    
        public virtual int EmpleadoAdd(string nombre, Nullable<int> puestoId, Nullable<int> departamentoId)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var puestoIdParameter = puestoId.HasValue ?
                new ObjectParameter("PuestoId", puestoId) :
                new ObjectParameter("PuestoId", typeof(int));
    
            var departamentoIdParameter = departamentoId.HasValue ?
                new ObjectParameter("DepartamentoId", departamentoId) :
                new ObjectParameter("DepartamentoId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", nombreParameter, puestoIdParameter, departamentoIdParameter);
        }
    
        public virtual int EmpleadoDelete(Nullable<int> empleadoId)
        {
            var empleadoIdParameter = empleadoId.HasValue ?
                new ObjectParameter("EmpleadoId", empleadoId) :
                new ObjectParameter("EmpleadoId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", empleadoIdParameter);
        }
    
        public virtual ObjectResult<EmpleadosPuestosGetAll_Result> EmpleadosPuestosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadosPuestosGetAll_Result>("EmpleadosPuestosGetAll");
        }
    
        public virtual ObjectResult<NombreEmpleadoCoincidenciaGetAll_Result> NombreEmpleadoCoincidenciaGetAll(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NombreEmpleadoCoincidenciaGetAll_Result>("NombreEmpleadoCoincidenciaGetAll", nombreParameter);
        }
    
        public virtual ObjectResult<PuestosGetAll_Result> PuestosGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PuestosGetAll_Result>("PuestosGetAll");
        }
    }
}
