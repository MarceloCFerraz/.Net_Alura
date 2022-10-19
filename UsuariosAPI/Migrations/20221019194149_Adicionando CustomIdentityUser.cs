using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c7be0316-2c73-406c-b2ee-dff029ad2109");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e6cd11bb-3b24-4b07-bd97-95507a68e5c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cea8b03-d3c8-49e6-8049-66297efab1ca", "AQAAAAEAACcQAAAAEP+X+xW11baegbbL7WGggJdNyMmv+FqgyO3tQ5mSEc6mygQOemwgSijOCUh/rsNbqQ==", "eb0642d8-6f1d-477f-aaf3-7b8962e22084" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "17f160b2-65cc-4e44-967c-710af1281970");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4736319f-1e2a-43f4-9bdb-dca58c61134a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48a7ed4b-36e9-451a-8f07-88fac2356c04", "AQAAAAEAACcQAAAAEH/OXiLI2U4FFUfw+jLgCRaxMkVK0Zq/dePJVPHTmrowluGU/xrszULsC4ny7QBuiQ==", "dc983db1-05bc-4fcd-aa9e-ff0bf9c12a23" });
        }
    }
}
