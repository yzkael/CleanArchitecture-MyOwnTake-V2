using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Infrastructure.Data.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(p => p.Carnet).IsUnique();
            var requiredProperties = new[] { "ApellidoMaterno", "ApellidoPaterno", "Carnet", "Nombre" };

            foreach (var propertyName in requiredProperties)
            {
                builder.Property(propertyName).IsRequired();
            }


            throw new NotImplementedException();
        }
    }
}