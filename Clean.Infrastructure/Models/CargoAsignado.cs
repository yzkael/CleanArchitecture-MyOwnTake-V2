using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Clean.Infrastructure.Models
{
    public class CargoAsignado : IdentityUserRole<string>
    {
        public DateOnly FechaAsignacion { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? FechaFin { get; set; }
    }
}