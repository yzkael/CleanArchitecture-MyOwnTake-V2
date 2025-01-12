using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Infrastructure.Data.Configurations;
using Clean.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonaConfiguration());

            //Initial Seeder

            var newPersona = new Persona
            {
                Nombre = "Ismael",
                ApellidoPaterno = "Moron",
                ApellidoMaterno = "Pedraza",
                Carnet = "12597382",
                Telefono = "75526864"
            };
            builder.Entity<Persona>().HasData(newPersona);
            var passwordHasher = new PasswordHasher<string>();
            var newUsuario = new Usuario
            {
                UserName = "ismael",
                PasswordHash = passwordHasher.HashPassword(null!, "123456"),
                PersonaId = newPersona.Id
            };
            builder.Entity<Usuario>().HasData(newUsuario);
            var newCargo = new Cargo
            {
                Name = "Sudo",
                NormalizedName = "SUDO"
            };
            builder.Entity<Cargo>().HasData(newCargo);

            var newCargoAsignado = new CargoAsignado
            {
                UserId = newUsuario.Id,
                RoleId = newCargo.Id
            };
            builder.Entity<CargoAsignado>().HasData(newCargoAsignado);

            base.OnModelCreating(builder);
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Cargo> Cargos { get; set; } = null!;
        public DbSet<CargoAsignado> CargoAsignados { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
    }
}