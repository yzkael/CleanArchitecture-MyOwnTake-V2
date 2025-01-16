using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.Presentation.Migrations
{
    /// <inheritdoc />
    public partial class Migratefuck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonaBase_PersonaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PersonaBase_PersonaId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonaId1",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaBase",
                table: "PersonaBase");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc3504f3-b5b9-4efb-94b0-7c11bdc0c355", "c936fd90-5879-4c4a-badc-e2c9ed035306" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc3504f3-b5b9-4efb-94b0-7c11bdc0c355");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c936fd90-5879-4c4a-badc-e2c9ed035306");

            migrationBuilder.DropColumn(
                name: "PersonaId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "PersonaBase");

            migrationBuilder.RenameTable(
                name: "PersonaBase",
                newName: "Personas");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaBase_Carnet",
                table: "Personas",
                newName: "IX_Personas_Carnet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "77b74af8-3065-4e47-aaf7-1efabb104828", null, "Cargo", "Sudo", "SUDO" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FechaCreacion", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonaId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bba2c7d5-89e7-4ef8-a692-3924282665b6", 0, "a1927d17-2b4d-4aa3-a82b-3e6b6cf86021", null, false, new DateOnly(2025, 1, 16), false, null, null, null, "AQAAAAIAAYagAAAAECARB9oT+OuHx/3jbQjmrt0wK21AJ/4h/RE1G9YiqUR6sdaAdleeOz2WBznPxTghXg==", 1, null, false, "9f906445-d684-434f-9462-0988fb730616", false, "ismael" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator", "FechaAsignacion", "FechaFin" },
                values: new object[] { "77b74af8-3065-4e47-aaf7-1efabb104828", "bba2c7d5-89e7-4ef8-a692-3924282665b6", "CargoAsignado", new DateOnly(2025, 1, 16), null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Personas_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Personas_PersonaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77b74af8-3065-4e47-aaf7-1efabb104828", "bba2c7d5-89e7-4ef8-a692-3924282665b6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b74af8-3065-4e47-aaf7-1efabb104828");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bba2c7d5-89e7-4ef8-a692-3924282665b6");

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "PersonaBase");

            migrationBuilder.RenameIndex(
                name: "IX_Personas_Carnet",
                table: "PersonaBase",
                newName: "IX_PersonaBase_Carnet");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "PersonaBase",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaBase",
                table: "PersonaBase",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "dc3504f3-b5b9-4efb-94b0-7c11bdc0c355", null, "Cargo", "Sudo", "SUDO" });

            migrationBuilder.InsertData(
                table: "PersonaBase",
                columns: new[] { "Id", "ApellidoMaterno", "ApellidoPaterno", "Carnet", "Discriminator", "Nombre", "Telefono" },
                values: new object[] { 1, "Pedraza", "Moron", "12597382", "Persona", "Ismael", "75526864" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FechaCreacion", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonaId", "PersonaId1", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c936fd90-5879-4c4a-badc-e2c9ed035306", 0, "61a74d07-3064-42f4-98fc-e2c748288911", null, false, new DateOnly(2025, 1, 16), false, null, null, null, "AQAAAAIAAYagAAAAEA9R9Of3UJ3aqOhODbR9v+nACmwmL9QHTiP8uOa0CKs5UZjxnPJNeQQgysYsmxQBnw==", 1, null, null, false, "099b3f03-be1e-40ef-bab4-02cf1bdc2666", false, "ismael" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator", "FechaAsignacion", "FechaFin" },
                values: new object[] { "dc3504f3-b5b9-4efb-94b0-7c11bdc0c355", "c936fd90-5879-4c4a-badc-e2c9ed035306", "CargoAsignado", new DateOnly(2025, 1, 16), null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonaId1",
                table: "AspNetUsers",
                column: "PersonaId1",
                unique: true,
                filter: "[PersonaId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonaBase_PersonaId",
                table: "AspNetUsers",
                column: "PersonaId",
                principalTable: "PersonaBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PersonaBase_PersonaId1",
                table: "AspNetUsers",
                column: "PersonaId1",
                principalTable: "PersonaBase",
                principalColumn: "Id");
        }
    }
}
