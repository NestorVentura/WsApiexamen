using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WsApiexamen.Configurations;
using WsApiexamen.Models;

namespace WsApiexamen.Repositorios
{
    public class AplicationContext : DbContext 
    {
        public DbSet<Examen> Examenes { get; set; }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamenConfiguration).Assembly);

        }
    }
}