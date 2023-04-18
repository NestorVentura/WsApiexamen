using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WsApiexamen.Models;

namespace WsApiexamen.Configurations
{
    public class ExamenConfiguration : IEntityTypeConfiguration<Examen>
    {


        public void Configure(EntityTypeBuilder<Examen> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
           
            builder.Property(p => p.Descripcion).HasMaxLength(30);

        }
    }
    

    
}
