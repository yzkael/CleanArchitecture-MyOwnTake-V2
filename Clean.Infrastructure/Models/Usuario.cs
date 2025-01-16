using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Clean.Domain.Entities.AuthRelatedEntities;
using Microsoft.AspNetCore.Identity;

namespace Clean.Infrastructure.Models
{
    public class Usuario : IdentityUser
    {
        public DateOnly FechaCreacion { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public int PersonaId { get; set; }
        public Persona Persona { get; set; } = null!;
    }
}