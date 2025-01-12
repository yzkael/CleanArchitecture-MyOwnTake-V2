using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Domain.Entities.AuthRelatedEntities;

namespace Clean.Infrastructure.Models
{
    public class Persona : PersonaBase
    {
        public Usuario Usuario { get; set; } = null!;
    }
}